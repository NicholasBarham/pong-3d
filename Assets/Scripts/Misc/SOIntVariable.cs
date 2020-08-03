using UnityEngine;

namespace Pong
{
    [CreateAssetMenu(fileName = "Int Variable", menuName = "Pong/Variables/Int")]
    public class SOIntVariable : ScriptableObject, IIntGetter, IIntSetter
    {
        [SerializeField]
        private int _value;

        public int Value { get => _value; set => _value = value; }
    }
}