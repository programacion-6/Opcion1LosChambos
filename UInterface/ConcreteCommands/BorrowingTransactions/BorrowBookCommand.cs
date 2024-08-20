using LosChambos.Entities;
using LosChambos.Entities.Concretes;
using LosChambos.UInterface.CommandInterface;
using LosChambos.UInterface.Menu;

namespace LosChambos.UInterface.ConcreteCommands.BorrowingTransactions;

public class BorrowBookCommand : ICommand
{
    private readonly Library _library;

    public BorrowBookCommand(Library library)
    {
        _library = library;
    }

    public void Execute()
    {
        var patron = GetPatronFromUser();
        if (patron == null)
            return;

        var book = GetBookFromUser();
        if (book == null)
            return;

        var dueDate = DateTime.TryParse(
            UserInterface.GetUserInput("Enter due date (yyyy-MM-dd): "),
            out DateTime resultDueDate
        );

        if (!dueDate)
        {
            UserInterface.ShowMessage("Invalid date");
            return;
        }
        var transaction = new BorrowingTransaction(book, patron, resultDueDate);
        bool success = _library.BorrowingTransactionsManager.Add(transaction);

        UserInterface.ShowMessage(
            success ? "Book borrowed successfully." : "Failed to borrow book."
        );
    }

    private Book? GetBookFromUser()
    {
        var book = SearchMenuUInterface<Book>.ShowSearchedItemById(_library.BookManager, "Book");
        if (book == null)
        {
            UserInterface.ShowMessage("Book not found.");
            return null;
        }
        return (Book)book;
    }

    private Patron? GetPatronFromUser()
    {
        var patron = SearchMenuUInterface<Patron>.ShowSearchedItemById(
            _library.PatronManager,
            "Patron"
        );
        if (patron == null)
        {
            UserInterface.ShowMessage("Patron not found.");
            return null;
        }
        return (Patron)patron;
    }
}
