using LosChambos.Entities;
using LosChambos.Entities.Concretes;
using LosChambos.UInterface.CommandInterface;
using LosChambos.UInterface.ConcreteCommands.BorrowingTransactions;
using LosChambos.UInterface.Menu;

namespace LosChambos.UInterface;

public class BorrowingTransactionUInterface : BaseUInterface<BorrowingTransaction>
{
    public BorrowingTransactionUInterface(Library library)
        : base(library, "Borrowing Transaction") { }

    protected override SearchMenuUInterface<BorrowingTransaction> CreateSearchInterface()
    {
        var searchCommands = new Dictionary<string, ICommand>
        {
            { "1", new SearchBorrowedTransactionsHistoryCommand(_library) },
            { "2", new SearchBorrowedTransactionsHistoryCommand(_library) },
            { "3", new SearchOverdueBorrowedTransactionsCommand(_library) },
        };

        var searchLabels = new List<string>
        {
            "Patron's Currently Borrowed Books",
            "Patron's Borrowing History",
            "Patron's Overdue Borrowed Books",
        };

        return new SearchMenuUInterface<BorrowingTransaction>(
            searchCommands,
            searchLabels,
            _menuTitle,
            _library.BorrowingTransactionsManager
        );
    }

    protected override MainMenuUInterface CreateMainMenuInterface()
    {
        var menuCommands = new Dictionary<string, ICommand>
        {
            { "1", new BorrowBookCommand(_library) },
            { "2", new ReturnBookCommand(_library) },
            { "3", new SearchMenuCommand(_searchInterface) },
        };

        var menuLabels = new List<string> { "Borrow Book", "Return Book", "Search Transaction" };

        return new MainMenuUInterface(menuCommands, menuLabels, _menuTitle);
    }
    public static Patron? GetPatronFromUser(Library _library, string patronId)
    {
        var guid = Guid.TryParse(patronId, out var resultPatronId);
        var patron = _library.PatronManager.GetItemById(resultPatronId);

        if (patron == null)
        {
            UserInterface.ShowMessage("Patron not Found");
            return null;
        }
        return patron;
    }
}
