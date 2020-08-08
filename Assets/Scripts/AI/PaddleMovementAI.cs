using UnityEngine;
using Util.Variables;

namespace Pong
{
    public class PaddleMovementAI : MonoBehaviour
    {
        [SerializeField]
        private Transform paddle = null;
        [SerializeField]
        private Transform ballTransform = null;
        [SerializeField]
        private Rigidbody ballRB = null;

        [SerializeField]
        private FloatVariable movementInput = null;

        [SerializeField]
        private FloatReference inputSensitivity = null;

        private void Update()
        {
            ProcessDirectionToMove();
        }

        private void ProcessDirectionToMove()
        {
            if (ballRB.velocity.z <= 0f)
            {
                movementInput.Value = 0f;
                return;
            }

            float ballX = ballTransform.position.x;
            float paddleX = paddle.position.x;

            if (paddleX < ballX)
                movementInput.Value = inputSensitivity.Value;
            else if (paddleX > ballX)
                movementInput.Value = -inputSensitivity.Value;
        }
    }
}