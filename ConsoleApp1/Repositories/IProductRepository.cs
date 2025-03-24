using MyApp.Models;

namespace ConsoleApp1.Repositories;

public interface IProductRepository
{
    // Haal een product op uit de repository op basis van naam.
    void AddProduct(Product product); 
    
    // Haal een lijst op van alle producten.
    Product? GetProduct(string name);
    
    // Werkt een bestaand product bij
    void UpdateProduct(Product product);
    
    // Verwijder een product uit de repository op basis van naam.
    void RemoveProduct(string name);
}