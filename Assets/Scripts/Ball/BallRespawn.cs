using UnityEngine;

namespace Pong
{
    public class BallRespawn : MonoBehaviour, IRespawn
    {
        [SerializeField]
        private IBallVelocity ballVelocity = null;

        private void Awake()
        {
            if (ballVelocity == null)
                ballVelocity = GetComponent<IBallVelocity>();
        }

        public void Respawn()
        {
            transform.localPosition = Vector3.zero;
            ballVelocity.SetVelocity(Vector3.zero);
        }
    }
}