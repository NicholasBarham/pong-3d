using NUnit.Framework;
using Pong;
using NSubstitute;
using System;

namespace Tests
{
    public class Test_PongGame
    {
        ICounter p1, p2;
        PongGame game;

        [SetUp]
        public void Setup()
        {
            p1 = Substitute.For<ICounter>();
            p2 = Substitute.For<ICounter>();
            game = new PongGame(p1, p2);
        }

        [Test]
        public void Constructor_Initialises_Is_Playing_Correctly()
        {
            Assert.IsFalse(game.IsPlaying);
        }

        [Test]
        public void StartGame_Begins_Game()
        {
            bool gameHasStarted = false;
            Action action = () => gameHasStarted = true;
            game.OnGameStart += action;

            game.StartGame();

            Assert.IsTrue(game.IsPlaying);
            Assert.IsTrue(gameHasStarted);
        }

        [Test]
        public void StartGame_Resets_Players()
        {
            game.StartGame();

            p1.Received(1).Reset();
            p2.Received(1).Reset();
        }

        [Test]
        public void EndGame_Ends_Game()
        {
            bool gameHasStopped = false;
            Action action = () => gameHasStopped = true;
            game.OnGameEnd += action;

            game.StartGame();
            Assert.IsTrue(game.IsPlaying);

            game.EndGame();
            Assert.IsFalse(game.IsPlaying);
            Assert.IsTrue(gameHasStopped);
        }

        [Test]
        public void EndGame_Forfeit_Game()
        {
            p1.MaxCount.ReturnsForAnyArgs(5);
            p2.MaxCount.ReturnsForAnyArgs(5);

            bool gameHasForfeit = false;
            Action action = () => gameHasForfeit = true;
            game.OnGameForfeit += action;

            game.StartGame();
            Assert.IsTrue(game.IsPlaying);

            game.EndGame();
            Assert.IsFalse(game.IsPlaying);
            Assert.IsTrue(gameHasForfeit);
        }

        [Test]
        public void ResetGame_Resets_Players()
        {
            game.ResetGame();

            p1.DidNotReceive().Reset();
            p2.DidNotReceive().Reset();

            game.StartGame();

            game.ResetGame();
            p1.Received(2).Reset();
            p2.Received(2).Reset();
        }

        [Test]
        public void Player_Win_Triggers_EndGame()
        {
            game.StartGame();
            Assert.IsTrue(game.IsPlaying);

            p1.OnMaxCountReached += Raise.Event<Action>();
            Assert.IsFalse(game.IsPlaying);
        }

        [Test]
        public void PlayerOneWin_Event_Triggers()
        {
            bool hasPlayerOneWon = false;
            Action action = () => hasPlayerOneWon = true;
            game.OnPlayerOneWins += action;

            game.StartGame();

            p2.CurrentCount.Returns(1);
            p2.MaxCount.Returns(5);

            p1.CurrentCount.Returns(5);
            p1.MaxCount.Returns(5);

            p1.OnMaxCountReached += Raise.Event<Action>();

            Assert.IsTrue(hasPlayerOneWon);
        }

        [Test]
        public void PlayerTwoWin_Event_Triggers()
        {
            bool hasPlayerTwoWon = false;
            Action action = () => hasPlayerTwoWon = true;
            game.OnPlayerTwoWins += action;

            game.StartGame();

            p1.CurrentCount.Returns(1);
            p1.MaxCount.Returns(5);

            p2.CurrentCount.Returns(5);
            p2.MaxCount.Returns(5);
            p2.OnMaxCountReached += Raise.Event<Action>();

            Assert.IsTrue(hasPlayerTwoWon);
        }
    }
}
