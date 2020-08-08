namespace Pong
{
    public class Goal : IGoal
    {
        private ICounter _counter;

        public Goal(ICounter counter)
        {
            _counter = counter;
        }

        public void Score() => _counter.Increment();
    }
}