using LosChambos.Entities;
using LosChambos.UInterface.CommandInterface;
using LosChambos.UInterface.Menu;

namespace LosChambos.UInterface.ConcreteCommands.BorrowingTransactions;

public class ReturnBookCommand : ICommand
{
    private readonly Library _library;

    public ReturnBookCommand(Library library)
    {
        _library = library;
    }

    public void Execute()
    {
        var transactionId = UserInterface.GetUserInput("Enter Transaction Id: ");
        var guid = Guid.TryParse(transactionId, out Guid resultGuid);
        if (!guid)
        {
            UserInterface.ShowMessage("Invalid Id format");
            return;
        }
        var transaction = _library.BorrowingTransactionsManager.GetItemById(resultGuid);

        if (transaction == null)
        {
            UserInterface.ShowMessage("Transaction not found.");
            return;
        }

        transaction.ReturnBook();
        bool success = _library.BorrowingTransactionsManager.Update(transaction);

        UserInterface.ShowMessage(
            success ? "Book returned successfully." : "Failed to return book."
        );

        _library.FineManager.CalculateFine(transaction);
        UserInterface.ShowMessage(transaction.ToString());
    }
}
