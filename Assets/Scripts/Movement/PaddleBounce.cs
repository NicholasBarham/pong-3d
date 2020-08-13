using UnityEngine;
using Util.GameEvents;
using Util.Variables;

namespace Pong
{
    public class PaddleBounce : MonoBehaviour
    {
        private BoxCollider paddleCollider = null;

        [SerializeField]
        private FloatReference ballSpeed = null;

        [SerializeField]
        private FloatEvent InduceCameraShake = null;

        private void Awake()
        {
            paddleCollider = GetComponent<BoxCollider>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            BounceBall(collision);

            TriggerCameraShake(collision);
        }

        private void BounceBall(Collision collision)
        {
            IBallVelocity ballVelocity = collision.gameObject.GetComponent<IBallVelocity>();

            if (ballVelocity == null)
                return;

            float pointX = collision.GetContact(0).point.x;

            CalculateBounceVelocity(ballVelocity, pointX);
        }

        private void CalculateBounceVelocity(IBallVelocity ballVelocity, float collisionPointX)
        {
            float paddleCenterX = paddleCollider.bounds.center.x;

            float collisionDistanceToCenter = collisionPointX - paddleCenterX;

            float xAngleStrength = collisionDistanceToCenter / paddleCollider.bounds.extents.x;
            xAngleStrength = Mathf.Clamp(xAngleStrength, -1f, 1f);

            float xVelocity = CreateXVelocity(ballVelocity.LastGivenVelocity.x, xAngleStrength);

            Vector3 newBallVelocity = new Vector3(xVelocity, ballVelocity.LastGivenVelocity.y, ballVelocity.LastGivenVelocity.z * -1f);

            ballVelocity.SetVelocity(newBallVelocity);
        }

        private float CreateXVelocity(float lastGivenXVelocity, float xVelocityStrength)
        {
            float addedXVelocity = lastGivenXVelocity + (xVelocityStrength * ballSpeed.Value);
            return Mathf.Clamp(addedXVelocity, -ballSpeed.Value, ballSpeed.Value);
        }

        private void TriggerCameraShake(Collision collision)
        {
            IBallWeight ballWeight = collision.gameObject.GetComponent<IBallWeight>();
            
            if(ballWeight != null)
                InduceCameraShake?.Raise(ballWeight.GetWeight());
        }
    }
}