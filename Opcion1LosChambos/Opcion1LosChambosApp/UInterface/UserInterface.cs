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

    private readonly LocalData _localData;

    private readonly MainMenuUInterface _mainMenuUInterface;

    public UserInterface()
    {
        var library = new Library();
        var bookStorage = new FileStorage<Book>("DataLoader/Books.json");
        var patronStorage = new FileStorage<Patron>("DataLoader/Patrons.json");
        _localData = new LocalData(patronStorage, bookStorage, library);
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
        const int pageSize = 3;
        var items = choices.ToList();
        int totalPages = ChoicesPaginator.CalculateTotalPages(items.Count, pageSize);
        int currentPage = 0;

        while (true)
        {
            var pageItems = ChoicesPaginator.GetPageItems(items, currentPage, pageSize);
            var options = ChoicesPaginator.BuildOptionsList(pageItems, currentPage, totalPages);

            var selectedChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"[yellow]Select an option (Page {currentPage + 1}/{totalPages})[/]")
                    .PageSize(pageSize + 2)
                    .AddChoices(options)
            );

            if (ChoicesPaginator.HandleSpecialChoices(selectedChoice, ref currentPage, totalPages))
                continue;

            return ChoicesPaginator.GetSelectedItem(items, selectedChoice);
    }
}

}