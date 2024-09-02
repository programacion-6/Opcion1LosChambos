using LosChambos.DataLoader;
using LosChambos.Entities;
using LosChambos.Entities.Concretes;
using LosChambos.Pagination;
using LosChambos.UInterface.CommandInterface;
using LosChambos.UInterface.ConcreteCommands.UserInterfaces;
using LosChambos.UInterface.Menu;
using Spectre.Console;

namespace LosChambos.UInterface;

public class UserInterface
{
    private readonly BookUInterface _bookUInterface;
    private readonly PatronUInterface _patronUInterface;
    private readonly BorrowingTransactionUInterface _transactionUInterface;

    private readonly MainMenuUInterface _mainMenuUInterface;

    public UserInterface()
    {
        var library = new Library();
        LocalData.LoadData(library);
        _bookUInterface = new BookUInterface(library);
        _patronUInterface = new PatronUInterface(library);
        _transactionUInterface = new BorrowingTransactionUInterface(library);

        var menuCommands = new Dictionary<string, ICommand>
        {
            { "1", new HandleMenuCommand<Book>(_bookUInterface) },
            { "2", new HandleMenuCommand<Patron>(_patronUInterface) },
            { "3", new HandleMenuCommand<BorrowingTransaction>(_transactionUInterface) },
        };

        var menuLabels = new List<string>
        {
            "Manage Books",
            "Manage Patrons",
            "Manage Borrowing Transactions"
        };

        _mainMenuUInterface = new MainMenuUInterface(menuCommands, menuLabels, "Library");
    }

    public void HandleUserInput()
    {
        _mainMenuUInterface.HandleMenu();
    }

    public static string GetUserInput(string prompt)
    {
        return AnsiConsole.Ask<string>($"[green]{prompt}[/]");
    }

    public static void ShowMessage(string message)
    {
        AnsiConsole.MarkupLine($"[cyan]{message}[/]");
    }

    public static void DisplayListResult<T>(IEnumerable<T> results)
    {
        var resultsList = results.ToList();
        if (resultsList.Any())
        {
            var paginator = new Paginator<T>(resultsList);
            paginator.DisplayPaginatedList();
        }
        else
        {
            AnsiConsole.MarkupLine("[red]No data found.[/]");
        }
    }

    public static T DisplaySelectableListResult<T>(IEnumerable<T> choices)
        where T : notnull
    {
        var selectedChoice = AnsiConsole.Prompt(
            new SelectionPrompt<T>()
                .Title("[yellow]Select an option[/]")
                .PageSize(3)
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .AddChoices(choices)
        );

        return selectedChoice;
    }

    public static string GetValidUserInput(Func<string, bool> validateFunc, string prompt, string errorMessage)
    {
        string input;
        do
        {
            input = GetUserInput(prompt);
            if (!validateFunc(input))
            {
                ShowMessage(errorMessage);
            }
        } while (!validateFunc(input));

        return input;
    }
}
