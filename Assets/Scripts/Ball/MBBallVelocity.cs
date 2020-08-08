using UnityEngine;

namespace Pong
{
    public class MBBallVelocity : MonoBehaviour, IBallVelocity
    {
        [SerializeField]
        private Rigidbody ballRigidbody;

        private Vector3 _lastGivenVelocity;

        public Vector3 LastGivenVelocity { get => _lastGivenVelocity; }

        private void Awake()
        {
            if (ballRigidbody == null)
                ballRigidbody = GetComponent<Rigidbody>();
        }

        public void SetVelocity(Vector3 velocity)
        {
            _lastGivenVelocity = velocity;

            if (ballRigidbody != null)
                ballRigidbody.velocity = _lastGivenVelocity;
        }
    }
}