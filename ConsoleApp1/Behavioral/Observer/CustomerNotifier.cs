using System;
using MyApp.Behavioral.Observer;

namespace ConsoleApp1.Behavioral.Observer
{
    
    /// <summary>
    /// Klasse die klanten notificeert over voorraadwijzigingen volgens het Observer patroon.
    /// </summary>
    internal class CustomerNotifier : IStockObserver
    {
        
        // De naam van de klant die genotificeerd moet worden
        private readonly string _customerName;
        
        /// <summary>
        /// Constructor voor het maken van een nieuwe klantnotificatie-instantie.
        /// </summary>
        /// <param name="customerName">De naam van de klant</param>
        
        public CustomerNotifier(string customerName)
        {
            _customerName = customerName;
        }
        
        /// <summary>
        /// Wordt aangeroepen wanneer de voorraad van een product wijzigt.
        /// </summary>
        /// <param name="productName">Naam van het product</param>
        /// <param name="stock">Nieuwe voorraadaantal</param>
        public void Update(string productName, int stock)
        {
            Console.WriteLine($" {_customerName}, update: {productName} stock is now {stock}.");
        }
        
        /// <summary>
        /// Wordt aangeroepen bij voorraadwijzigingen (dubbele implementatie van Update).
        /// </summary>
        /// <param name="productName">Naam van het product</param>
        /// <param name="newStock">Nieuwe voorraadaantal</param>
        public void OnStockChanged(string productName, int newStock)
        {
            Console.WriteLine($" {_customerName}, update: {productName} stock is now {newStock}.");
        }
    }
}