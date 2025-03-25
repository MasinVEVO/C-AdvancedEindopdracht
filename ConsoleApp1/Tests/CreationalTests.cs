using ConsoleApp1.Patterns.Creational.FactoryMethod;
using ConsoleApp1.Patterns.Creational.Singleton;
using NUnit.Framework;
using VendingMachineApp.Models;

namespace VendingMachineApp.Tests
{
    [TestFixture]
    public class CreationalTests
    {
        [Test]
        public void InventoryManager_ShouldBeSingleton()
        {
            var instance1 = InventoryManager.Instance;
            var instance2 = InventoryManager.Instance;

            Assert.That(instance1, Is.SameAs(instance2), " InventoryManager is een Singleton.");
        }

        [Test]
        public void ProductFactory_ShouldCreateProductSuccessfully()
        {
            var factory = new ProductFactory();
            var product = factory.CreateProduct("Coca-Cola", 2.00m, 10);

            Assert.That(product, Is.Not.Null, " ProductFactory creëert correct een product.");
            Assert.That(product.Name, Is.EqualTo("Coca-Cola"));
        }
    }
}