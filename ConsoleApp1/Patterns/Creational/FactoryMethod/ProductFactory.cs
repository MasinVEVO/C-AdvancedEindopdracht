using VendingMachineApp.Models;
using System;
using MyApp.Models;


namespace MyApp.Patterns.Creational.FactoryMethod;
public static class ProductFactory
{
    public static IProduct CreateProduct(string type)
    {
        switch (type.ToLower())
        {
            case "cola":
                return new Product("Coca-Cola", 2.00m, 10);
            case "chips":
                return new Product("Chips", 1.50m, 5);
            case "water":
                return new Product("Water", 1.00m, 8);
            default:
                throw new ArgumentException($" Onbekend producttype: {type}");
        }
    }
}