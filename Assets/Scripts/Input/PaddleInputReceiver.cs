using UnityEngine;

namespace Pong
{
    public class PaddleInputReceiver : MonoBehaviour
    {
        [SerializeField]
        private GameObject paddle = null;
        private IMove _paddle = null;

        [SerializeField]
        private ScriptableObject input = null;
        private IFloatGetter _input = null;

        private void Awake()
        {
            _input = (IFloatGetter)input;
            _paddle = paddle.GetComponent<IMove>();
        }

        private void Update()
        {
            _paddle.Move(_input.Value);
        }
    }
}