using System;

namespace ConsoleApp1.Concurrency.ProducerConsumer

{
    public class ConsumerTask : IConsumerTask
    {
        private readonly Action _action;

        public ConsumerTask(Action action)
        {
            _action = action;
        }

        public void Execute()
        {
            _action();
        }
    }
}