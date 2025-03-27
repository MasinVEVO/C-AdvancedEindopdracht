using System;
using ConsoleApp1.BonusPatterns.Command;
using ConsoleApp1.BonusPatterns.Memento;
using ConsoleApp1.Concurrency.ProducerConsumer;
using ConsoleApp1.Concurrency.ThreadPool;
using ConsoleApp1.Patterns.Creational.FactoryMethod;
using ConsoleApp1.Patterns.Creational.Singleton;
using ConsoleApp1.Structural.Decorator;
using ConsoleApp1.Structural.Facade;
using MyApp.Models;
using VendingMachineApp.Models;
using VendingMachineApp.Services;
using IProduct = MyApp.Models.IProduct;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ✅ Vooraf gedefinieerde producten via Singleton & Factory Patterns
            var inventory = InventoryManager.Instance;
            var productFactory = new ProductFactory();
            inventory.AddProduct((Product)productFactory.CreateProduct("Coca-Cola", 2.50m, 10));
            inventory.AddProduct((Product)productFactory.CreateProduct("Sprite", 2.20m, 8));
            inventory.AddProduct((Product)productFactory.CreateProduct("Chips", 1.80m, 15));
            

            var vendingMachine = new VendingMachine();
            var facade = new VendingMachineFacade();
            var orderQueue = new OrderProcessingQueue(10);
            var taskManager = new TaskManager(10);
            VendingMachineMemento savedState = null;

            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== Vending Machine Menu ===");
                Console.WriteLine("1. Toon producten (Singleton)");
                Console.WriteLine("2. Voeg geld toe (State)");
                Console.WriteLine("3. Selecteer product (State)");
                Console.WriteLine("4. Geef product uit (Facade & Decorator)");
                Console.WriteLine("5. Voorraad aanvullen (Producer-Consumer)");
                Console.WriteLine("6. Restitutie uitvoeren (Command & Memento)");
                Console.WriteLine("7. Stoppen");
                Console.Write("Kies een optie: ");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1": // Singleton
                        inventory.ShowInventory();
                        break;

                    case "2": // State
                        Console.Write("Voer het bedrag in: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                            vendingMachine.InsertMoney(amount);
                        else
                            Console.WriteLine("Ongeldig bedrag.");
                        break;

                    case "3": // State
                        Console.Write("Voer de productnaam in: ");
                        vendingMachine.SelectProduct(Console.ReadLine());
                        break;

                    case "4": // Facade & Decorator
                        Console.Write("Voer de productnaam in voor uitgifte: ");
                        var productName = Console.ReadLine();

                        var originalProduct = InventoryManager.Instance.GetProduct(productName);

                        if (originalProduct != null)
                        {
                            // Pas decorator toe op bestaand product
                            PremiumProductDecorator decoratedProduct = new PremiumProductDecorator(
                                new BasicProduct(originalProduct.Name, originalProduct.Price));

                            facade.PurchaseProduct(decoratedProduct.GetName(), decoratedProduct.GetPrice());
                        }
                        else
                        {
                            Console.WriteLine("Product niet gevonden in voorraad.");
                        }
                        break;

                    case "5": // Producer-Consumer
                        Console.Write("Voer de productnaam in: ");
                        var refillProduct = Console.ReadLine();
                        Console.Write("Voer de hoeveelheid in: ");
                        if (int.TryParse(Console.ReadLine(), out int quantity))
                        {
                            orderQueue.AddTask(new OrderingProcessingTask(refillProduct, quantity));
                        }
                        else
                        {
                            Console.WriteLine("Ongeldige hoeveelheid.");
                        }
                        break;

                    case "6": // Command & Memento
                        if (vendingMachine.SelectedProduct != null)
                        {
                            savedState ??= vendingMachine.CreateMemento();
                            var refundCommand = new RefundCommand(vendingMachine);
                            refundCommand.Execute();
                            vendingMachine.RestoreState(savedState);
                        }
                        else
                        {
                            Console.WriteLine("Je hebt geen product geselecteerd. Selecteer eerst een product om een restitutie uit te voeren.");
                        }
                        break;


                    case "7":
                        running = false;
                        Console.WriteLine("Programma afgesloten.");
                        break;

                    default:
                        Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
                        break;
                }

                Console.WriteLine("\nDruk op een toets om door te gaan...");
                Console.ReadKey();
            }
        }
    }
}
