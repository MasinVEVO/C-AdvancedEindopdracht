namespace ConsoleApp1.BonusPatterns.Memento;

public class VendingMachineHistory
{
    private readonly Stack<VendingMachineMemento> _history = new();
    
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
        throw new NotImplementedException();
    }
}