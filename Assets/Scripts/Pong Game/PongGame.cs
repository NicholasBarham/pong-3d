using System;

namespace Pong
{
    public class PongGame : IPongGame
    {
        public bool IsPlaying { get; private set; }

        private ICounter _playerOne;
        private ICounter _playerTwo;

        public event Action OnPlayerOneWins;
        public event Action OnPlayerTwoWins;
        public event Action OnGameStart;
        public event Action OnGameEnd;
        public event Action OnGameForfeit;

        public PongGame(ICounter playerOne, ICounter playerTwo)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;

            IsPlaying = false;
        }

        public void StartGame()
        {
            if (!IsPlaying)
            {
                SubscribeToPlayers();
                ResetPlayers();
                IsPlaying = true;
                OnGameStart?.Invoke();
            }
        }

        public void ResetGame()
        {
            if (IsPlaying)
            {
                UnsubscribeToPlayers();
                ResetPlayers();
                SubscribeToPlayers();
            }
        }

        public void EndGame()
        {
            if (IsPlaying)
            {
                UnsubscribeToPlayers();
                IsPlaying = false;
            

                OnGameEnd?.Invoke();

                if (HasMatchForfeited())
                    OnGameForfeit?.Invoke();
                else if (HasPlayerOneWon)
                    OnPlayerOneWins?.Invoke();
                else if (HasPlayerTwoWon)
                    OnPlayerTwoWins?.Invoke();
            }
        }

        private void SubscribeToPlayers()
        {
            _playerOne.OnMaxCountReached += EndGame;
            _playerTwo.OnMaxCountReached += EndGame;
        }

        private void UnsubscribeToPlayers()
        {
            _playerOne.OnMaxCountReached -= EndGame;
            _playerTwo.OnMaxCountReached -= EndGame;
        }

        private void ResetPlayers()
        {
            _playerOne.Reset();
            _playerTwo.Reset();
        }

        private bool HasMatchForfeited()
        {
            return _playerOne.CurrentCount != _playerOne.MaxCount
                && _playerTwo.CurrentCount != _playerTwo.MaxCount;
        }

        private bool HasPlayerOneWon => CheckWin(_playerOne);

        private bool HasPlayerTwoWon => CheckWin(_playerTwo);

        private bool CheckWin(ICounter playerCounter) => playerCounter.CurrentCount == playerCounter.MaxCount;
    }
}