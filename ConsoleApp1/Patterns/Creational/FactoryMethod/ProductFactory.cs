using MyApp.Models;

namespace ConsoleApp1.Patterns.Creational.FactoryMethod
{
    public class ProductFactory
    {
        public IProduct CreateProduct(string name, decimal price, int quantity)
        {
            return new Product(name, price, quantity);
        }
    }
}