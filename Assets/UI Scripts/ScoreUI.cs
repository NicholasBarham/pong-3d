using TMPro;
using UnityEngine;

namespace Pong
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI uIText = null;

        [SerializeField]
        private SOCounter score = null;

        private void Awake()
        {
            if(score != null)
                NumberToText(score.Counter.CurrentCount);
        }

        private void OnEnable()
        {
            score?.OnScoreChanged.AddListener(NumberToText);
        }

        public void NumberToText(int number)
        {
            uIText?.SetText(number.ToString());
        }

        private void OnDisable()
        {
            score?.OnScoreChanged.RemoveListener(NumberToText);
        }
    }
}