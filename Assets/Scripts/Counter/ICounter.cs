using System;

namespace Pong
{
    public interface ICounter
    {
        int CurrentCount { get; }
        int MaxCount { get; }
        event Action<int> OnCountChanged;
        event Action OnMaxCountReached;
        void Increment();
        void Decrement();
        void Reset();
    }
}