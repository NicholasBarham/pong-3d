using System;

namespace Pong
{
    public interface ICountdown
    {
        float StartTime { get; }
        float CurrentTime { get; }
        bool IsComplete { get; }

        event Action OnCountdownReset;
        event Action OnCountdownComplete;
        event Action<float> OnCountdownTick;

        void Tick(float amount);
        void Reset();
    }
}