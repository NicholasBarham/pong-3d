using System.Threading;
using UnityEngine;

namespace Pong
{
    public class PaddleMovementAI : MonoBehaviour
    {
        [SerializeField]
        private Transform paddle = null;
        [SerializeField]
        private Collider paddleCollider = null;
        [SerializeField]
        private Transform ballTransform = null;
        [SerializeField]
        private Rigidbody ballRB = null;

        [SerializeField]
        private ScriptableObject floatSetter = null;
        private IFloatSetter _floatSetter = null;

        [SerializeField]
        private ScriptableObject inputSensitivity = null;
        private IFloatGetter _inputSensitivity = null;

        private void Awake()
        {
            _floatSetter = (IFloatSetter)floatSetter;
            _inputSensitivity = (IFloatGetter)inputSensitivity;
        }

        private void Update()
        {
            ProcessDirectionToMove();
        }

        private void ProcessDirectionToMove()
        {
            if (ballRB.velocity.z <= 0f)
            {
                _floatSetter.Value = 0f;
                return;
            }

            float ballX = ballTransform.position.x;
            float paddleX = paddle.position.x;

            if (paddleX < ballX)
                _floatSetter.Value = _inputSensitivity.Value;
            else if (paddleX > ballX)
                _floatSetter.Value = -_inputSensitivity.Value;
        }
    }
}