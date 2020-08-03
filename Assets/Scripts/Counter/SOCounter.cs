using UnityEngine;
using UnityEngine.Events;

namespace Pong
{
    [CreateAssetMenu(fileName = "Score Counter", menuName = "Pong/Score Counter")]
    public class SOCounter : ScriptableObject
    {
        public ICounter Counter { get; private set; }

        [SerializeField]
        private ScriptableObject maxScore = null;
        private IIntGetter _maxScore = null;

        [HideInInspector]
        public UnityEvent OnWin;
        [HideInInspector]
        public IntUnityEvent OnScoreChanged;

        private void OnEnable()
        {
            InitialiseVariables();
            Counter.OnMaxCountReached += Win;
            Counter.OnCountChanged += ScoreChanged;
        }

        private void InitialiseVariables()
        {
            _maxScore = (IIntGetter)maxScore;
            Counter = new Counter(_maxScore.Value);
        }

        private void Win()
        {
            OnWin?.Invoke();
        }

        private void ScoreChanged(int newScore)
        {
            OnScoreChanged?.Invoke(newScore);
        }

        private void OnDisable()
        {
            Counter.OnMaxCountReached -= Win;
            Counter.OnCountChanged -= ScoreChanged;
        }
    }
}