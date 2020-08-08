using UnityEngine;
using Util.Variables;

namespace Pong
{
    public class BallServe : MonoBehaviour, IServe
    {
        [SerializeField]
        private Rigidbody rb = null;

        [SerializeField]
        private FloatReference ballSpeed = null;

        [SerializeField]
        private BoolVariable serveDirection = null;

        private void Awake()
        {
            if (rb == null)
                rb = GetComponent<Rigidbody>();
        }

        public void SetupServe()
        {
            if(serveDirection != null)
                Serve(serveDirection.Value);
        }

        public void Serve(bool serveToPlayer)
        {
            Vector3 direction = serveToPlayer ? Vector3.back : Vector3.forward;

            rb.velocity = direction * ballSpeed.Value;
        }

        public void SetServeDirection(bool serveToPlayer) => serveDirection.Value = serveToPlayer;
    }
}