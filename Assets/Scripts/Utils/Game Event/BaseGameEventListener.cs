using UnityEngine;
using UnityEngine.Events;

namespace Util.GameEvents
{
    public abstract class BaseGameEventListener<T, E, UER> : MonoBehaviour, IBaseGameEventListener<T>
        where E : IBaseGameEvent<T> where UER : UnityEvent<T>
    {
        [SerializeField]
        private E _gameEvent = default;
        public E GameEvent { get { return _gameEvent; } }

        [SerializeField]
        private UER _unityEventResponse = null;

        private void OnEnable() => _gameEvent?.RegisterListener(this);
        public void OnEventRaised(T item) => _unityEventResponse?.Invoke(item);
        private void OnDisable() => _gameEvent?.UnregisterListener(this);
    }
}