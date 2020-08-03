namespace Util.GameEvents
{
    public interface IBaseGameEvent<T>
    {
        void RegisterListener(IBaseGameEventListener<T> listener);
        void UnregisterListener(IBaseGameEventListener<T> listener);
        void Raise(T item);
    }
}