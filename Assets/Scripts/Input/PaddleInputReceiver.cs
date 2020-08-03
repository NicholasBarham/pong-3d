using UnityEngine;
using Util.Variables;

namespace Pong
{
    public class PaddleInputReceiver : MonoBehaviour
    {
        [SerializeField]
        private GameObject paddle = null;
        private IMove _paddle = null;

        [SerializeField]
        private FloatReference input = null;

        private void Awake()
        {
            _paddle = paddle.GetComponent<IMove>();
        }

        private void Update()
        {
            _paddle?.Move(input.Value);
        }
    }
}