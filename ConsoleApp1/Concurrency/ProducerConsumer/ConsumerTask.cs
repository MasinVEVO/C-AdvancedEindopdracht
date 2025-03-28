using System;

namespace ConsoleApp1.Concurrency.ProducerConsumer
{
    /// <summary>
    /// Represents a task that can be executed by a consumer in a producer-consumer pattern.
    /// This class encapsulates an action to be performed when the task is executed.
    /// </summary>
    public class ConsumerTask : IConsumerTask
    {
        private readonly Action _action;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumerTask"/> class.
        /// </summary>
        /// <param name="action">The action to be executed by the consumer.</param>
        public ConsumerTask(Action action)
        {
            _action = action;
        }

        /// <summary>
        /// Executes the consumer task by invoking the encapsulated action.
        /// </summary>
        public void Execute()
        {
            _action();
        }
    }
}