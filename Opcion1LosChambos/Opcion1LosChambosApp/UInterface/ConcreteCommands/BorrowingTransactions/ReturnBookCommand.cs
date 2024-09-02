using LosChambos.Entities;
using LosChambos.UInterface.CommandInterface;

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
        if (_library.BorrowingTransactionsManager.Items.Count > 0)
        {
            var transaction = UserInterface.DisplaySelectableListResult(
                _library.BorrowingTransactionsManager.Items
            );
            if (transaction == null)
            {
                UserInterface.ShowMessage("Transaction not found.");
                return;
            }
            else
            {
                transaction.ReturnBook();
                bool success = _library.BorrowingTransactionsManager.Update(transaction);

                UserInterface.ShowMessage(
                    success ? "Book returned successfully." : "Failed to return book."
                );

                _library.FineManager.CalculateFine(transaction);
                UserInterface.ShowMessage(transaction.ToString() ?? "Transaction not found.");
            }
        }
        else 
        {
            UserInterface.ShowMessage("Transactions not found.");
            return;
        }
    }
}
