using UnityEngine;

namespace Pong
{
    public class PaddleMovement : MonoBehaviour, IMove
    {
        [SerializeField]
        private Rigidbody paddleRigidbody;

        private void Awake()
        {
            if (paddleRigidbody == null)
                paddleRigidbody = GetComponent<Rigidbody>();
        }

        public void Move(float input) => paddleRigidbody.velocity = new Vector2(input, 0f);
    }
}