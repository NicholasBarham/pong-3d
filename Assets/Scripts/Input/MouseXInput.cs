using UnityEngine;

namespace Pong
{
    public class MouseXInput : MonoBehaviour
    {
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

        void Update()
        {
            _floatSetter.Value = Input.GetAxis("Mouse X") * _inputSensitivity.Value;
        }
    }
}