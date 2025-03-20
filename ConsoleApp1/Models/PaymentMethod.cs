namespace MyApp.Models;

public interface IPaymentMethod
{
    bool ProcessPayment(decimal amount);
}

public class PaymentMethod : IPaymentMethod
{
   public string Name { get; private set; }
   
   public PaymentMethod(string name)
   {
       Name = name;
   }
   
   public virtual bool ProcessPayment(decimal amount)
   {
       Console.WriteLine($"Processing payment of €{amount} using {Name}");
       return true;
   }
   
   public override string ToString()
   {
       return Name;
   }
}