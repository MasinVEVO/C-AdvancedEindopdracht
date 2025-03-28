using System.Collections.Generic;

namespace MyApp.Behavioral.Command
{
    /// <summary>
    /// De VendingMachineInvoker klasse fungeert als de aanroeper binnen het Command patroon.
    /// Deze klasse houdt een lijst van commando's bij en voert ze uit wanneer nodig.
    /// </summary>
    public class VendingMachineInvoker
    {
        // Lijst van commando's die wachten om uitgevoerd te worden
        private readonly List<ICommand> _commands = new();

        /// <summary>
        /// Voegt een nieuw commando toe aan de wachtrij van uit te voeren commando's
        /// </summary>
        /// <param name="command">Het commando dat toegevoegd moet worden</param>
        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
        }

        /// <summary>
        /// Voert alle commando's in de wachtrij uit en maakt de lijst daarna leeg.
        /// Dit zorgt ervoor dat alle geregistreerde acties worden uitgevoerd en dat 
        /// de invoker klaar is voor een nieuwe reeks commando's.
        /// </summary>
        public void ExecuteCommands()
        {
            foreach (var command in _commands)
            {
                command.Execute();
            }
            _commands.Clear();
        }
    }
}