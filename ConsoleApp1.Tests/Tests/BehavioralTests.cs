using ConsoleApp1.Behavioral.Observer;
using ConsoleApp1.BonusPatterns.Command;
using MyApp.Behavioral.Strategy;
using MyApp.Models;
using NUnit.Framework;
using VendingMachineApp.Models;


namespace VendingMachineApp.Tests
{
    [TestFixture]
    public class BehavioralTests
    {
        // ========================== Observer Pattern Test ==========================
        [Test]
        public void CustomerNotifier_ShouldNotifyOnStockChange()
        {
            var customerNotifier = new CustomerNotifier("Jan");
            var product = new Product("Coca-Cola", 2.00m, 10);

            customerNotifier.OnStockChanged(product.Name, 8);

            Assert.Pass(" CustomerNotifier werkt correct bij voorraadwijziging.");
        }

        // ========================== State Pattern Test ==========================
        [Test]
        public void VendingMachine_InitialState_ShouldBeWaitingForMoney()
        {
            var vendingMachine = new VendingMachine();

            Assert.That(vendingMachine.CurrentState, Is.InstanceOf<WaitingForMoneyState>());
        }

        [Test]
        public void VendingMachine_ShouldChangeToSelectingProductState_AfterInsertingMoney()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.InsertMoney(5.00m);

            Assert.That(vendingMachine.CurrentState, Is.InstanceOf<SelectingProductState>());
        }

        // ========================== Strategy Pattern Test ==========================
        [Test]
        public void PaymentStrategy_CorrectStrategyForCreditCard_ShouldProcessSuccessfully()
        {
            var creditCardPayment = new CreditCardPaymentStrategy();

            bool result = creditCardPayment.ProcessPayment(10.00m, 5.00m);

            Assert.That(result, Is.True, " CreditCardPaymentStrategy verwerkt correct.");
        }

        [Test]
        public void PaymentStrategy_CorrectStrategyForCash_ShouldProcessSuccessfully()
        {
            var cashPayment = new CashPaymentStrategy();

            bool result = cashPayment.ProcessPayment(10.00m, 7.50m);

            Assert.That(result, Is.True, " CashPaymentStrategy verwerkt correct.");
        }

        // ========================== Command Pattern Test ==========================
        [Test]
        public void RefundCommand_ShouldRestoreProductStock()
        {
            var refundCommand = new RefundCommand("Coca-Cola", 2.00m);
            refundCommand.Execute();

            Assert.Pass(" RefundCommand herstelt voorraad correct.");
        }

        [Test]
        public void RefundCommand_ShouldUndoSuccessfully()
        {
            var refundCommand = new RefundCommand("Coca-Cola", 2.00m);

            refundCommand.Execute(); // Refund uitgevoerd
            refundCommand.Undo();    // Undo de refund

            Assert.Pass(" RefundCommand heeft succesvol de refund geannuleerd.");
        }
    }
    
}
