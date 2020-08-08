using TMPro;
using UnityEngine;

namespace Pong
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI uIText = null;

        private void Awake()
        {
            if (uIText == null)
                uIText = GetComponent<TextMeshProUGUI>();
        }

        public void ScoreToText(int number)
        {
            uIText?.SetText(number.ToString());
        }
    }
}