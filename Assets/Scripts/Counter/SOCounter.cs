using UnityEngine;
using Util.GameEvents;
using Util.Variables;

namespace Pong
{
    [CreateAssetMenu(fileName = "Score Counter", menuName = "Pong/Score Counter")]
    public class SOCounter : ScriptableObject
    {
        public ICounter Counter { get; private set; }

        [SerializeField]
        private IntReference maxScore = null;

        [SerializeField]
        private IntEvent OnScoreChangedEvent = null;

        private void OnEnable()
        {
            InitialiseVariables();
            Counter.OnCountChanged += ScoreChanged;
        }

        private void InitialiseVariables()
        {
            Counter = new Counter(maxScore.Value);
        }

        public void ResetCounter() => Counter.Reset();

        private void ScoreChanged(int newScore) => OnScoreChangedEvent?.Raise(newScore);

        private void OnDisable()
        {
            Counter.OnCountChanged -= ScoreChanged;
        }
    }
}