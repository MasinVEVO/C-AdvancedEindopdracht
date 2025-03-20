namespace MyApp.Behavioral.Observer;

public interface IStockObserver
{
    void Update(string productName, int stock);
}