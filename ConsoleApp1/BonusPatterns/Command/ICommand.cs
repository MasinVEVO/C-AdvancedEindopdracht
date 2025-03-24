namespace ConsoleApp1.BonusPatterns.Command;

public interface ICommand
{
    void Execute();
    void Undo();
}