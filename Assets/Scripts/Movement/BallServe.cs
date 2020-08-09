using UnityEngine;
using Util.Variables;

namespace Pong
{
    public class BallServe : MonoBehaviour, IServe
    {
        [SerializeField]
        private IBallVelocity ballVelocity = null;

        [SerializeField]
        private FloatReference ballSpeed = null;

        [SerializeField]
        private BoolVariable serveDirection = null;

        private void Awake()
        {
            if (ballVelocity == null)
                ballVelocity = GetComponent<IBallVelocity>();
        }

        public void SetupServe()
        {
            if(serveDirection != null)
                Serve(serveDirection.Value);
        }

        public void Serve(bool serveToPlayer)
        {
            Vector3 direction = serveToPlayer ? Vector3.back : Vector3.forward;

            ballVelocity.SetVelocity(direction * ballSpeed.Value);
        }

        public void SetServeDirection(bool serveToPlayer) => serveDirection.Value = serveToPlayer;
    }
}