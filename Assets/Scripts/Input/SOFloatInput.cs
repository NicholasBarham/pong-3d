using UnityEngine;

namespace Pong
{
    [CreateAssetMenu(fileName = "Float Variable", menuName = "Pong/Variables/Float")]
    public class SOFloatInput : ScriptableObject, IFloatGetter, IFloatSetter
    {
        [SerializeField]
        private float _value;

        public float Value { get => _value; set => _value = value; }
    }
}