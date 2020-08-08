using UnityEngine;
using Util.GameEvents;

namespace Pong
{
    public class MBPongGame : MonoBehaviour
    {
        private IPongGame _game = null;

        [SerializeField]
        private SOCounter playerCounter = null;

        [SerializeField]
        private SOCounter enemyCounter = null;

        [SerializeField]
        private VoidEvent OnGameStarted = null;
        [SerializeField]
        private VoidEvent OnGameForfeit = null;
        [SerializeField]
        private VoidEvent OnGameEnded = null;
        [SerializeField]
        private VoidEvent OnPlayerWins = null;
        [SerializeField]
        private VoidEvent OnEnemyWins = null;

        private void Awake()
        {
            _game = new PongGame(playerCounter.Counter, enemyCounter.Counter);
        }

        private void OnEnable()
        {
            _game.OnGameStart += TriggerStartGame;
            _game.OnGameForfeit += TriggerForfeitGame;
            _game.OnGameEnd += TriggerEndGame;
            _game.OnPlayerOneWins += TriggerPlayerWins;
            _game.OnPlayerTwoWins += TriggerEnemyWins;
        }

        public void NewGame() => _game.StartGame();

        public void EndGame() => _game.EndGame();

        private void TriggerPlayerWins() => OnPlayerWins?.Raise();

        private void TriggerEnemyWins() => OnEnemyWins?.Raise();

        private void TriggerEndGame() => OnGameEnded?.Raise();

        private void TriggerForfeitGame() => OnGameForfeit?.Raise();

        public void TriggerStartGame() => OnGameStarted?.Raise();

        private void OnDisable()
        {
            _game.OnGameStart -= TriggerStartGame;
            _game.OnGameForfeit -= TriggerForfeitGame;
            _game.OnGameEnd -= TriggerEndGame;
            _game.OnPlayerOneWins -= TriggerPlayerWins;
            _game.OnPlayerTwoWins -= TriggerEnemyWins;
        }
    }
}