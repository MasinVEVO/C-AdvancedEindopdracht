﻿namespace MyApp.Behavioral.Strategy;

public class CreditCardPaymentStrategy : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paying {amount} using Credit Card.");
    }

    public bool ProcessPayment(decimal amountPaid, decimal productPrice)
    {
        return amountPaid >= productPrice;
    }
    
    
    
}