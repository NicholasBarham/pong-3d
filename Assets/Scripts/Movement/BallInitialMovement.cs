using UnityEngine;

namespace Pong
{
    public class BallInitialMovement : MonoBehaviour
    {
        private Rigidbody rb;

        public void FireBall()
        {
            rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.forward * -5f;
        }
    }
}