using NUnit.Framework;
using Pong;

namespace Tests
{
    public class Test_Countdown
    {
        [Test]
        public void Constructor_Initialises_Correctly()
        {
            var countdown = new Countdown(3f);
            Assert.AreEqual(3f, countdown.StartTime);
            Assert.AreEqual(3f, countdown.CurrentTime);
            Assert.IsFalse(countdown.IsComplete);
        }

        [Test]
        public void Countdown_Ticks_Correctly()
        {
            var countdown = new Countdown(3f);

            countdown.Tick(1f);
            Assert.AreEqual(2f, countdown.CurrentTime);

            countdown.Tick(0.5f);
            Assert.AreEqual(1.5f, countdown.CurrentTime);
        }

        [Test]
        public void Countdown_Ticks_With_Negative_Numbers()
        {
            var countdown = new Countdown(3f);

            countdown.Tick(-1f);
            Assert.AreEqual(2f, countdown.CurrentTime);

            countdown.Tick(-0.5f);
            Assert.AreEqual(1.5f, countdown.CurrentTime);
        }

        [Test]
        public void Countdown_Tick_Triggers_OnTick_Event()
        {
            var countdown = new Countdown(3f);
            float tick = -1f;

            countdown.OnCountdownTick += value => tick = value;

            countdown.Tick(1f);
            Assert.AreEqual(2f, tick);

            countdown.Tick(0.5f);
            Assert.AreEqual(1.5f, tick);
        }

        [Test]
        public void Countdown_Completes_Correctly()
        {
            var countdown = new Countdown(3f);
            Assert.IsFalse(countdown.IsComplete);

            countdown.Tick(1f);
            Assert.IsFalse(countdown.IsComplete);

            countdown.Tick(2f);
            Assert.IsTrue(countdown.IsComplete);
        }

        [Test]
        public void Countdown_Cannot_Over_Tick()
        {
            var countdown = new Countdown(3f);

            countdown.Tick(20f);
            Assert.AreEqual(0f, countdown.CurrentTime);
        }

        [Test]
        public void Countdown_Complete_Triggers_OnComplete_Event()
        {
            var countdown = new Countdown(3f);
            bool completed = false;

            countdown.OnCountdownComplete += () => completed = true;

            Assert.IsFalse(completed);

            countdown.Tick(10f);
            Assert.IsTrue(completed);
        }

        [Test]
        public void Countdown_Can_Reset_Before_Complete()
        {
            var countdown = new Countdown(3f);

            countdown.Tick(1f);
            Assert.AreEqual(2f, countdown.CurrentTime);
            Assert.IsFalse(countdown.IsComplete);

            countdown.Reset();
            Assert.AreEqual(countdown.CurrentTime, countdown.StartTime);
            Assert.IsFalse(countdown.IsComplete);
        }

        [Test]
        public void Countdown_Can_Reset_After_Complete()
        {
            var countdown = new Countdown(3f);

            countdown.Tick(10f);
            Assert.AreEqual(0f, countdown.CurrentTime);
            Assert.IsTrue(countdown.IsComplete);

            countdown.Reset();
            Assert.IsFalse(countdown.IsComplete);
        }

        [Test]
        public void Countdown_Reset_When_Not_Complete_Triggers_OnReset_Event()
        {
            var countdown = new Countdown(3f);
            bool hasResetBeenTriggered = false;

            countdown.OnCountdownReset += () => hasResetBeenTriggered = true;

            countdown.Tick(1f);
            Assert.IsFalse(countdown.IsComplete);
            Assert.IsFalse(hasResetBeenTriggered);

            countdown.Reset();
            Assert.IsTrue(hasResetBeenTriggered);
        }

        [Test]
        public void Countdown_Reset_When_Complete_Triggers_OnReset_Event()
        {
            var countdown = new Countdown(3f);
            bool hasResetBeenTriggered = false;

            countdown.OnCountdownReset += () => hasResetBeenTriggered = true;

            countdown.Tick(20f);
            Assert.IsTrue(countdown.IsComplete);
            Assert.IsFalse(hasResetBeenTriggered);

            countdown.Reset();
            Assert.IsTrue(hasResetBeenTriggered);
        }
    }
}
