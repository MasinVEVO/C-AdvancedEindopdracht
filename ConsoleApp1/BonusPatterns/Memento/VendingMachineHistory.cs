namespace ConsoleApp1.BonusPatterns.Memento;

public class VendingMachineHistory
{
    
        // Stack om de geschiedenis van VendingMachine staten op te slaan
        private readonly Stack<VendingMachineMemento> _history = new();

        // Methode om de huidige staat van de VendingMachine op te slaan
        public void SaveState(VendingMachineMemento memento)
        {
            _history.Push(memento);
        }

        // Methode om de laatst opgeslagen staat van de VendingMachine te herstellen
        public VendingMachineMemento? RestoreState()
        {
            if (_history.Count > 0)
            {
                return _history.Pop();
            }

            // Als er geen eerdere staat beschikbaar is, print een bericht en retourneer null
            Console.WriteLine("Geen eerdere status om te herstellen");
            return null;
        }

        // Methode om de laatst opgeslagen staat op te halen zonder deze uit de geschiedenis te verwijderen
        public VendingMachineMemento GetLastState()
        {
            if (_history.Count > 0)
            {
                return _history.Peek();
            }

            // Als er geen eerdere staat beschikbaar is, print een bericht en retourneer null
            Console.WriteLine("Geen eerdere status om op te halen");
            return null;
        }
}