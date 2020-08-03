using System.Collections.Generic;
using UnityEngine;

namespace Util.GameEvents
{
    public abstract class BaseGameEvent<T> : ScriptableObject, IBaseGameEvent<T>
    {
        private readonly List<IBaseGameEventListener<T>> _listeners = new List<IBaseGameEventListener<T>>();

        public void RegisterListener(IBaseGameEventListener<T> listener)
        {
            if (!_listeners.Contains(listener))
                _listeners.Add(listener);
        }

        public void UnregisterListener(IBaseGameEventListener<T> listener)
        {
            if (_listeners.Contains(listener))
                _listeners.Remove(listener);
        }

        public void Raise(T item)
        {
            for (int i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].OnEventRaised(item);
            }
        }
    }
}