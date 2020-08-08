using UnityEngine;
using Util.Variables;

namespace Pong
{
    public class HorizontalInput : MonoBehaviour
    {
        [SerializeField]
        private FloatVariable inputVariable = null;

        [SerializeField]
        private FloatReference inputSensitivity = null;

        void Update()
        {
            inputVariable.Value = Input.GetAxisRaw("Horizontal") * inputSensitivity.Value;
        }
    }
}