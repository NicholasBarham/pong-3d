using UnityEngine;
using Util.Variables;

namespace Pong
{
    public class PaddleBounce : MonoBehaviour
    {
        private BoxCollider paddleCollider = null;

        [SerializeField]
        private FloatReference ballSpeed = null;

        private void Awake()
        {
            paddleCollider = GetComponent<BoxCollider>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            float pointX = collision.GetContact(0).point.x;

            Vector3 localPositionOfContact = transform.InverseTransformPoint(pointX, 0f, 0f);

            Rigidbody ballRigidbody = collision.collider.attachedRigidbody;

            Vector3 ballVelocity = ballRigidbody.velocity;

            float paddleXExtent = paddleCollider.bounds.extents.x;

            float xPercentage = localPositionOfContact.x / paddleXExtent - 1f;

            ballRigidbody.velocity = new Vector3(xPercentage, 0f, ballVelocity.normalized.z) * ballSpeed.Value;
        }
    }
}