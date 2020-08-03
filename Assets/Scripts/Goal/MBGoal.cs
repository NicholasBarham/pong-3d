using UnityEngine;

namespace Pong
{
    public class MBGoal : MonoBehaviour
    {
        [SerializeField]
        private SOCounter scoreObject = null;
        private ICounter _scoreObject = null;

        private IGoal _goal = null;

        private void Awake()
        {
            _scoreObject = scoreObject.Counter;

            _goal = new Goal(_scoreObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ball"))
                Score();
        }

        public void Score() => _goal.Score();
    }
}