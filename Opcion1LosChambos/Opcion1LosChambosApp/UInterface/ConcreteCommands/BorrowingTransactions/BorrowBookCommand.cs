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
        UserInterface.ShowMessage("SELECT A PATRON");
        var patron = UserInterface.DisplaySelectableListResult(_library.PatronManager.Items); 

        UserInterface.ShowMessage("SELECT A BOOK");
        var book = UserInterface.DisplaySelectableListResult(_library.BookManager.Items); 

        var dueDate = DateTime.TryParse(
            UserInterface.GetUserInput("Enter due date (yyyy-MM-dd): "),
            out DateTime resultDueDate
        );

        if (!dueDate)
        {
            UserInterface.ShowMessage("Invalid date");
            return;
        }

        var borrowedDate = DateTime.Now;

        if (borrowedDate > resultDueDate)
        {
            UserInterface.ShowMessage("The due date must be after or equal to the borrow date.");
            return;
        }

        var transaction = new BorrowingTransaction(book, patron, resultDueDate);

        if (!_library.BorrowingTransactionsManager.Items.Any(t => t.Book.Id == book.Id && !t.Returned))
        {
            bool success = _library.BorrowingTransactionsManager.Add(transaction);

            UserInterface.ShowMessage(success ? "Book borrowed successfully." : "Failed to borrow book.");
        }
        else
        {
            UserInterface.ShowMessage("Failed. Book is currently borrowed.");
        }
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
