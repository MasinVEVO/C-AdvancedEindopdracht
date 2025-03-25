using System;

namespace VendingMachineApp.Services
{
   
    public class PaymentService
    {
        public bool ProcessPayment(decimal amountPaid, decimal productPrice)
        {
            if (amountPaid >= productPrice)
            {
                Console.WriteLine($"Betaling van €{amountPaid:F2} succesvol verwerkt.");
                return true;
            }

            Console.WriteLine($" Onvoldoende saldo. Betaald: €{amountPaid:F2}, vereist: €{productPrice:F2}");
            return false;
        }
        
        
    }
}
