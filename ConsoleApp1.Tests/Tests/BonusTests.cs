using ConsoleApp1.BonusPatterns.Command;
using ConsoleApp1.BonusPatterns.Memento;
using NUnit.Framework;
using VendingMachineApp.Models;

namespace VendingMachineApp.Tests
{
    [TestFixture]
    public class BonusTests
    {
        // ========================== Memento Pattern Test ==========================
        [Test]
        public void VendingMachineHistory_ShouldRestorePreviousState()
        {
            var vendingMachine = new VendingMachine();
            var history = new VendingMachineHistory();

            vendingMachine.Balance = 5.00m;
            history.SaveState(vendingMachine.CreateMemento());

            vendingMachine.Balance = 0.00m; // Wijzig de balans
            vendingMachine.RestoreState(history.GetLastState());

            Assert.That(vendingMachine.Balance, Is.EqualTo(5.00m), "✅ VendingMachineHistory herstelt vorige staat correct.");
        }

        [Test]
        public void VendingMachineHistory_ShouldHandleEmptyHistoryGracefully()
        {
            var vendingMachine = new VendingMachine();
            var history = new VendingMachineHistory();

            Assert.DoesNotThrow(() => vendingMachine.RestoreState(history.GetLastState()),
                "✅ VendingMachineHistory verwerkt een lege geschiedenis correct.");
        }

        // ========================== RefundCommand Test ==========================
        [Test]
        public void RefundCommand_ShouldRefundCorrectAmount()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.Balance = 10.00m;

            var refundCommand = new RefundCommand(vendingMachine);
            refundCommand.Execute();

            Assert.That(vendingMachine.Balance, Is.EqualTo(0.00m), "✅ RefundCommand verwerkt restitutie correct.");
        }

        [Test]
        public void RefundCommand_ShouldNotCrashOnZeroBalance()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.Balance = 0.00m;

            var refundCommand = new RefundCommand(vendingMachine);

            Assert.DoesNotThrow(() => refundCommand.Execute(),
                "✅ RefundCommand verwerkt nul-balans correct zonder crash.");
        }
    }
}
