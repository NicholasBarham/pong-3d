namespace Util.GameEvents
{
    public interface IBaseGameEventListener<T>
    {
        void OnEventRaised(T item);
    }
}