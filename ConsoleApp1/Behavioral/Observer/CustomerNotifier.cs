using System;
using MyApp.Behavioral.Observer;

namespace ConsoleApp1.Behavioral.Observer
{
    
    internal class CustomerNotifier : IStockObserver
    {
        private readonly string _customerName;

        public CustomerNotifier(string customerName)
        {
            _customerName = customerName;
        }
        

        public void Update(string productName, int stock)
        {
            Console.WriteLine($" {_customerName}, update: {productName} stock is now {stock}.");
        }

        public void OnStockChanged(string productName, int newStock)
        {
            Console.WriteLine($" {_customerName}, update: {productName} stock is now {newStock}.");
        }
    }
}