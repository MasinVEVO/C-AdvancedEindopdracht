using MyApp.Models;

namespace ConsoleApp1.BonusPatterns.Memento;

public class VendingMachineMemento
{
    public decimal Balance { get; }
    public Product? SelectedProduct { get; }
    public int ProductStock { get; }

    public VendingMachineMemento(decimal balance, Product? selectedProduct, int productStock)
    {
        Balance = balance;
        SelectedProduct = selectedProduct;
        ProductStock = productStock;
    }
}