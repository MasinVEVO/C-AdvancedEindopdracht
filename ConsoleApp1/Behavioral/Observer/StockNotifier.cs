namespace MyApp.Behavioral.Observer
{
    
    // Deze Design Pattern is bedoeld om een lijst van objecten te observeren en zo een overzicht 
    // te geven over de veranderingen in een ander object.
    
    public class StockNotifier
    {
        private readonly List<IStockObserver> _observers = new();

        public void Subscribe(IStockObserver observer)
        {
            _observers.Add(observer);
        }
        
        public void Unsubscribe(IStockObserver observer)
        {
            _observers.Remove(observer);
        }
        
        public void Notify(string productName, int stock)
        {
            foreach (var observer in _observers)
            {
                observer.Update(productName, stock);
            }
        }
    } 
}

