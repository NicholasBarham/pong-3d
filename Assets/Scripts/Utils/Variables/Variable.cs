using System;
using UnityEngine;

namespace Util.Variables
{
    public abstract class Variable<T> : ScriptableObject, ISerializationCallbackReceiver
    {
        public T InitValue;

        [NonSerialized]
        public T Value;

        public virtual void OnAfterDeserialize() => Value = InitValue;

        public virtual void OnBeforeSerialize() { }
    }
}