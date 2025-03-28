using ConsoleApp1.Concurrency.ProducerConsumer;
using ConsoleApp1.Concurrency.ThreadPool;
using NUnit.Framework;


namespace VendingMachineApp.Tests
{
    [TestFixture]
    public class ConcurrencyTests
    {
        // ========================== ThreadPool Pattern Test ==========================
        [Test]
        public void TaskManager_ShouldProcessTasksSuccessfully()
        {
            var taskManager = new TaskManager(10);
            bool taskCompleted = false;

            taskManager.StartProcessing(); 

            taskManager.EnqueueTask(() => taskCompleted = true);

            Thread.Sleep(500);

            Assert.That(taskCompleted, Is.True, "TaskManager verwerkt taak correct.");
        }

        [Test]
        public void TaskManager_ShouldHandleMultipleTasksSuccessfully()
        {
            var taskManager = new TaskManager(10);
            int counter = 0;

            taskManager.EnqueueTask(() => counter++);
            taskManager.EnqueueTask(() => counter++);
            taskManager.StartProcessing();

            Assert.That(counter, Is.EqualTo(2), " TaskManager verwerkt meerdere taken correct.");
        }

        // ========================== Producer-Consumer Pattern Test ==========================
        [Test]
        public void OrderProcessingQueue_ShouldAddAndProcessOrderSuccessfully()
        {
            var orderQueue = new OrderProcessingQueue(10);
            bool orderProcessed = false;

            orderQueue.AddTask(new ConsumerTask(() => orderProcessed = true));
            orderQueue.ProcessTasks();

            Assert.That(orderProcessed, Is.True, " OrderProcessingQueue verwerkt bestelling correct.");
        }

        [Test]
        public void OrderProcessingQueue_ShouldHandleMultipleOrdersSuccessfully()
        {
            var orderQueue = new OrderProcessingQueue(10);
            bool orderProcessed = false;

            orderQueue.AddTask(new ConsumerTask(() => orderProcessed = true));
            orderQueue.ProcessTasks();

            Assert.That(orderProcessed, Is.True, " OrderProcessingQueue verwerkt bestelling correct.");
        }
    }
}
