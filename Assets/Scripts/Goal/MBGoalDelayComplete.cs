using UnityEngine;
using Util.GameEvents;

namespace Pong
{
    public class MBGoalDelayComplete : MonoBehaviour
    {
        [SerializeField]
        private VoidEvent startServeEvent = null;

        private bool isGamePlaying = false;

        public void Serve()
        {
            if(isGamePlaying)
                startServeEvent?.Raise();
        }

        public void SetGamePlaying(bool isPlaying)
        {
            isGamePlaying = isPlaying;
        }
    }
}