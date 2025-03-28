namespace MyApp.Behavioral.Observer
{
    
    
    /// <summary>
    /// Deze klasse implementeert het Observer pattern voor voorraadnotificaties.
    /// Het houdt een lijst van observers bij die geïnteresseerd zijn in voorraadwijzigingen
    /// en stelt deze op de hoogte wanneer er veranderingen plaatsvinden.
    /// </summary>
    /// 
    public class StockNotifier
    {
        // Lijst van observers die voorraadwijzigingen willen ontvangen

        private readonly List<IStockObserver> _observers = new();
        
        /// <summary>
        /// Voegt een nieuwe observer toe aan de lijst van geabonneerden.
        /// </summary>
        /// <param name="observer">De observer die toegevoegd moet worden</param>
        
        public void Subscribe(IStockObserver observer)
        {
            _observers.Add(observer);
        }
        
        /// <summary>
        /// Verwijdert een observer uit de lijst van geabonneerden.
        /// </summary>
        /// <param name="observer">De observer die verwijderd moet worden</param>
        /// 
        public void Unsubscribe(IStockObserver observer)
        {
            _observers.Remove(observer);
        }
        
        /// <summary>
        /// Informeert alle geabonneerde observers over een voorraadwijziging.
        /// </summary>
        /// <param name="productName">De naam van het product waarvan de voorraad is gewijzigd</param>
        /// <param name="stock">Het nieuwe voorraadniveau</param>
        public void Notify(string productName, int stock)
        {
            foreach (var observer in _observers)
            {
                observer.Update(productName, stock);
            }
        }
    } 
}

