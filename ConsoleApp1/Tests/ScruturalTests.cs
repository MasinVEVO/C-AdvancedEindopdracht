using NUnit.Framework;
using ConsoleApp1.Structural.Facade;
using ConsoleApp1.Structural.Decorator;
using VendingMachineApp.Models;
using VendingMachineApp.Services;

namespace VendingMachineApp.Tests
{
    [TestFixture]
    public class StructuralTests
    {
        // ========================== Facade Pattern Test ==========================
        [Test]
        public void VendingMachineFacade_ShouldStartWithoutErrors()
        {
            var facade = new VendingMachineFacade();

            Assert.DoesNotThrow(() => facade.StartVendingMachine(),
                " VendingMachineFacade start correct zonder fouten.");
        }

        [Test]
        public void VendingMachineFacade_ShouldHandlePurchaseSuccessfully()
        {
            var facade = new VendingMachineFacade();

            Assert.DoesNotThrow(() => facade.PurchaseProduct("Coca-Cola", 10.00m),
                " VendingMachineFacade verwerkt aankoop correct.");
        }

        // ========================== Payment Processor Test ==========================
        [Test]
        public void PaymentProcessor_ShouldProcessPaymentSuccessfully()
        {
            var paymentProcessor = new PaymentProcessor();
            bool result = paymentProcessor.ProcessPayment(10.00m);

            Assert.That(result, Is.True, " PaymentProcessor verwerkt betaling correct.");
        }

        [Test]
        public void PaymentProcessor_ShouldFailOnInvalidPayment()
        {
            var paymentProcessor = new PaymentProcessor();
            bool result = paymentProcessor.ProcessPayment(0.00m);

            Assert.That(result, Is.False, " PaymentProcessor herkent ongeldige betaling correct.");
        }

        // ========================== Decorator Pattern Tests ==========================
        [Test]
        public void BasicProduct_ShouldHaveCorrectPrice()
        {
            var product = new BasicProduct("Product Name", 10.00m);

            Assert.That(product.GetPrice(), Is.EqualTo(10.00m),
                " BasicProduct heeft de verwachte prijs van €10.");
        }

        [Test]
        public void DiscountedProductDecorator_ShouldApplyDiscountCorrectly()
        {
            var product = new BasicProduct("Product Name", 10.00m);
            var discountedProduct = new DiscountedProductDecorator(product);

            Assert.That(discountedProduct.GetPrice(), Is.EqualTo(5.00m),
                " DiscountedProductDecorator past korting correct toe.");
        }

        [Test]
        public void PremiumProductDecorator_ShouldApplyPremiumFeaturesCorrectly()
        {
            var product = new BasicProduct("Product Name", 10.00m);
            var premiumProduct = new PremiumProductDecorator(product);

            Assert.That(premiumProduct.GetPrice(), Is.EqualTo(30.00m),
                " PremiumProductDecorator past premiumprijs correct toe.");
        }

        // ========================== Adapter Pattern Test ==========================
        [Test]
        public void PaymentService_ShouldProcessPaymentSuccessfully()
        {
            var paymentService = new PaymentService();
            bool result = paymentService.ProcessPayment(10.00m, 2.00m);

            Assert.That(result, Is.True, " PaymentService verwerkt betaling correct.");
        }

        [Test]
        public void PaymentService_ShouldFailOnInvalidPayment()
        {
            var paymentService = new PaymentService();
            bool result = paymentService.ProcessPayment(1.00m, 5.00m);

            Assert.That(result, Is.False, " PaymentService herkent ongeldige betaling correct.");
        }
    }
}
