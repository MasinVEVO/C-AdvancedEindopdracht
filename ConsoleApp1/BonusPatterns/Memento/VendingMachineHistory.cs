namespace ConsoleApp1.BonusPatterns.Memento;

public class VendingMachineHistory
{
    private readonly Stack<VendingMachineMemento> _history = new();
    
    // Memento Pattern gebruik je om de status van vending machine op te slaan en te herstellen indien nodig.
    // (Bijvoorbeeld bij Undo-acties of terugbetalingen)
    
    public void SaveState(VendingMachineMemento memento)
    {
        _history.Push(memento);
    }

    public VendingMachineMemento? RestoreState()
    {
        if (_history.Count > 0)
        {
            return _history.Pop();
        }

        Console.WriteLine("Geen eerdere status om te herstellen");
        return null;
    }

    public VendingMachineMemento GetLastState()
    {
        if (_history.Count > 0)
        {
            return _history.Peek();
        }

        Console.WriteLine("No previous state to retrieve");
        return null;
    }
}