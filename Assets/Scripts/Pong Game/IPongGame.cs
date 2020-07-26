using System;

namespace Pong
{
    public interface IPongGame
    {
        bool IsPlaying { get; }

        event Action OnPlayerOneWins;
        event Action OnPlayerTwoWins;
        event Action OnGameStart;
        event Action OnGameEnd;
        event Action OnGameForfeit;

        void StartGame();
        void EndGame();
        void ResetGame();
    }
}