namespace VendingMachineApp.Services
{
   
    /// <summary>
    /// Verwerkt betalingen voor producten in de automaat.
    /// Controleert of het betaalde bedrag voldoende is voor de aankoop.
    /// </summary>
    public class PaymentService
    {
        /// <summary>
        /// Verwerkt een betaling en controleert of het betaalde bedrag voldoende is.
        /// </summary>
        /// <param name="amountPaid">Het betaalde bedrag door de klant</param>
        /// <param name="productPrice">De prijs van het product</param>
        /// <returns>True als de betaling succesvol is, anders False</returns>
        public bool ProcessPayment(decimal amountPaid, decimal productPrice)
        {
            if (amountPaid >= productPrice)
            {
                decimal change = amountPaid - productPrice;
                Console.WriteLine($"Betaling van €{amountPaid:F2} succesvol verwerkt.");
                
                if (change > 0)
                {
                    Console.WriteLine($"Wisselgeld: €{change:F2}");
                }
                
                return true;
            }

            Console.WriteLine($"Onvoldoende saldo. Betaald: €{amountPaid:F2}, vereist: €{productPrice:F2}");
            return false;
        }
    }
}
