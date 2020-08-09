using UnityEngine;

namespace Pong
{
    public class WallBounce : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            IBallVelocity ballVelocity = collision.gameObject.GetComponent<IBallVelocity>();

            if (ballVelocity == null)
                return;

            ballVelocity.SetVelocity(new Vector3(
                ballVelocity.LastGivenVelocity.x * -1f,
                ballVelocity.LastGivenVelocity.y,
                ballVelocity.LastGivenVelocity.z));
        }
    }
}