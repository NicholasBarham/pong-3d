using System;

namespace Pong
{
    public class Counter : ICounter
    {
        private int _currentCount;

        public int CurrentCount
        {
            get => _currentCount;

            private set
            {
                if (value != _currentCount)
                {
                    _currentCount = value;
                    OnCountChanged?.Invoke(_currentCount);

                    if (_currentCount == MaxCount)
                        OnMaxCountReached?.Invoke();
                }
            }
        }

        public int MaxCount { get; private set; }

        public event Action<int> OnCountChanged;
        public event Action OnMaxCountReached;

        public Counter(int maxCount)
        {
            CurrentCount = 0;
            MaxCount = maxCount;
        }

        public void Decrement()
        {
            if (CurrentCount - 1 >= 0)
                CurrentCount--;
        }

        public void Increment()
        {
            if (CurrentCount + 1 <= MaxCount)
                CurrentCount++;
        }

        public void Reset() => CurrentCount = 0;
    }
}