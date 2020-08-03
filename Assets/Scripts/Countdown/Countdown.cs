using System;

namespace Pong
{
    public class Countdown : ICountdown
    {
        public float StartTime { get; private set; }

        public float CurrentTime { get; private set; }

        public bool IsComplete { get; private set; }

        public event Action OnCountdownReset;
        public event Action OnCountdownComplete;
        public event Action<float> OnCountdownTick;

        public Countdown(float startTime)
        {
            StartTime = startTime;
            CurrentTime = startTime;
            IsComplete = false;
        }

        public void Reset()
        {
            CurrentTime = StartTime;
            IsComplete = false;
            OnCountdownReset?.Invoke();
        }

        public void Tick(float amount)
        {
            if (IsComplete)
                return;

            CurrentTime -= Math.Abs(amount);

            if (CurrentTime <= 0f)
            {
                CurrentTime = 0f;
                IsComplete = true;
                OnCountdownComplete?.Invoke();
            }

            OnCountdownTick?.Invoke(CurrentTime);
        }
    }
}