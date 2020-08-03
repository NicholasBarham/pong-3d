using UnityEngine;

namespace Pong
{
    public class MBPongGame : MonoBehaviour
    {
        private IPongGame _game = null;

        [SerializeField]
        private SOCounter playerCounter = null;

        [SerializeField]
        private SOCounter enemyCounter = null;

        [SerializeField]
        private MBCountdown countdown = null;

        private void Awake()
        {
            _game = new PongGame(playerCounter.Counter, enemyCounter.Counter);

            if (countdown == null)
                countdown = GetComponent<MBCountdown>();
        }

        public void BeginNewGame()
        {
            countdown?.StartCountdown();
        }
    }
}