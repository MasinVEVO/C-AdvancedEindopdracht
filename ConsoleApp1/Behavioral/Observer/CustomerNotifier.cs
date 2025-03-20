using System;
using MyApp.Behavioral.Observer;

namespace ConsoleApp1.Behavioral.Observer
{
    /// <summary>
    /// Observer that notifies customers when stock changes.
    /// </summary>
    internal class CustomerNotifier : IStockObserver
    {
        private readonly string _customerName;

        public CustomerNotifier(string customerName)
        {
            _customerName = customerName;
        }

        public void Update(string productName, int stock)
        {
            Console.WriteLine($"🔔 {_customerName}, update: {productName} stock is now {stock}.");
        }
    }
}