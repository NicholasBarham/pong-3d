using UnityEngine;

namespace Pong
{
    public class PaddleBounce : MonoBehaviour
    {
        BoxCollider paddleCollider = null;

        [SerializeField]
        private ScriptableObject ballSpeed = null;
        private IFloatGetter _ballSpeed = null;

        private void Awake()
        {
            paddleCollider = GetComponent<BoxCollider>();
            _ballSpeed = (IFloatGetter)ballSpeed;
        }

        private void OnCollisionEnter(Collision collision)
        {
            float pointX = collision.GetContact(0).point.x;
            Vector3 localPositionOfContact = transform.InverseTransformPoint(pointX, 0f, 0f);

            Rigidbody ballRigidbody = collision.collider.attachedRigidbody;

            Vector3 ballVelocity = ballRigidbody.velocity;

            float paddleXExtent = paddleCollider.bounds.extents.x;

            float xPercentage = localPositionOfContact.x / paddleXExtent - 1f;

            ballRigidbody.velocity = new Vector3(xPercentage, 0f, ballVelocity.normalized.z) * _ballSpeed.Value;
        }
    }
}