using VendingMachineApp.Models;

namespace MyApp.Behavioral.Command;

public class RefillProductCommand : ICommand
{
    // Referentie naar de automaat waarop de actie uitgevoerd wordt
    private readonly VendingMachine _vendingMachine;
    
    // Het product dat bijgevuld moet worden
    private readonly string _product;
    
    // De hoeveelheid die bijgevuld moet worden
    private readonly int _quantity;

    // Constructor initialiseert alle benodigde gegevens voor het uitvoeren van het commando
    public RefillProductCommand(VendingMachine vendingMachineApp, string product, int quantity)
    {
        _vendingMachine = vendingMachineApp;
        _product = product;
        _quantity = quantity;
    }

    // De Execute methode voert het daadwerkelijke commando uit
    // In dit geval wordt de RefillProduct methode van de automaat aangeroepen
    public void Execute()
    {
        _vendingMachine.RefillProduct(_product, _quantity);
    }
}