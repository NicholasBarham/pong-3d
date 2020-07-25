using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Pong;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Test_Counter
    {
        [Test]
        public void Constructor_Initialises_Correctly()
        {
            var counter = new Counter(5);

            Assert.AreEqual(5, counter.MaxCount);
            Assert.AreEqual(0, counter.CurrentCount);
        }

        [Test]
        public void Counter_Increments()
        {
            var counter = new Counter(5);
            
            counter.Increment();
            counter.Increment();

            Assert.AreEqual(2, counter.CurrentCount);
        }

        [Test]
        public void Counter_Decrements()
        {
            var counter = new Counter(5);

            counter.Increment();
            counter.Increment();
            counter.Increment();

            counter.Decrement();

            Assert.AreEqual(2, counter.CurrentCount);
        }

        [Test]
        public void Counter_Cannot_Go_Below_Zero()
        {
            var counter = new Counter(5);

            counter.Decrement();
            counter.Decrement();

            Assert.AreEqual(0, counter.CurrentCount);
        }

        [Test]
        public void Counter_Cannot_Go_Above_Max()
        {
            var counter = new Counter(1);

            counter.Increment();
            counter.Increment();

            Assert.AreEqual(1, counter.CurrentCount);
        }

        [Test]
        public void Counter_Resets()
        {
            var counter = new Counter(5);

            counter.Increment();
            counter.Increment();

            counter.Reset();

            Assert.AreEqual(0, counter.CurrentCount);
        }

        [Test]
        public void Counter_OnCountChanged_Is_Triggered()
        {
            var counter = new Counter(5);

            int number = 0;

            Action<int> action = it => number = it;
            counter.OnCountChanged += action;

            counter.Increment();
            Assert.AreEqual(1, number);

            counter.Increment();
            Assert.AreEqual(2, number);

            counter.Decrement();
            Assert.AreEqual(1, number);

            counter.Decrement();
            Assert.AreEqual(0, number);

            counter.OnCountChanged -= action;
        }

        [Test]
        public void Counter_OnMaxCountReached_Is_Triggered()
        {
            var counter = new Counter(2);

            bool isMaxedOut = false;

            Action action = () => isMaxedOut = true;
            counter.OnMaxCountReached += action;

            counter.Increment();
            Assert.IsFalse(isMaxedOut);

            counter.Increment();
            Assert.IsTrue(isMaxedOut);

            counter.OnMaxCountReached -= action;
        }
    }
}
