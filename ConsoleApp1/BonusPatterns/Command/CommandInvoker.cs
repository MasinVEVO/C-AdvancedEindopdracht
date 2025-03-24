namespace ConsoleApp1.BonusPatterns.Command;

public class CommandInvoker
{
    private readonly Stack<ICommand> _commandHistory = new();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _commandHistory.Push(command);
    }
    
    public void UndoLastCommand()
    {
        if (_commandHistory.Count == 0)
        {
            ICommand lastcommand = _commandHistory.Pop();
            lastcommand.Undo();
        }
        else
        {
            Console.WriteLine("Er zijn geen commando's om ongedaan te maken.");
        }
    }
}