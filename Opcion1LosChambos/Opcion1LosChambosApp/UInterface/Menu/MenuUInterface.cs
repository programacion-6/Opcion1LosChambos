using LosChambos.UInterface.CommandInterface;
using Spectre.Console;

namespace LosChambos.UInterface.Menu;

public class MenuUInterface
{
    protected readonly Dictionary<string, ICommand> _commands;
    protected readonly List<string> _labels;
    protected readonly string _menuInstruction;

    protected MenuUInterface(
        Dictionary<string, ICommand> commands,
        List<string> labels,
        string menuInstruction
    )
    {
        _commands = commands;
        _labels = labels;
        _menuInstruction = menuInstruction;
    }

    public void DisplayMenu()
    {
        AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title($"[yellow]{_menuInstruction}[/]")
                .PageSize(10) 
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .AddChoices(_labels));
    }

    public void HandleMenu()
    {
        bool running = true;
        while (running)
        {
            var options = new List<string>(_labels) { "Exit" };
            var selectedOption = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"[yellow]{_menuInstruction}[/]")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                    .AddChoices(options));

            if (selectedOption == "Exit")
            {
                AnsiConsole.MarkupLine("[red]Exiting...[/]");
                running = false;
            }
            else
            {
                var selectedIndex = options.IndexOf(selectedOption) + 1;

                if (_commands.TryGetValue(selectedIndex.ToString(), out ICommand? command))
                {
                    command.Execute();
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Invalid option, please try again.[/]");
                }
            }
        }
    }
}