using LosChambos.Entities;
using LosChambos.Entities.Concretes;
using LosChambos.SearchCriteria.BorrowingTransactions;
using LosChambos.UInterface.CommandInterface;
using LosChambos.UInterface.Menu;

namespace LosChambos.UInterface.ConcreteCommands.BorrowingTransactions.Search;

public class SearchCurrentlyBorrowedTransactionsCommand : ICommand
{
    private readonly Library _library;

    public SearchCurrentlyBorrowedTransactionsCommand(Library library)
    {
        _library = library;
    }

    public void Execute()
    {
        SearchMenuUInterface<BorrowingTransaction>.ShowSearchedData(
            "Enter patron Id: ",
            patronId =>
            {
                var patron = BorrowingTransactionUInterface.GetPatronFromUser(_library, patronId);
                if (patron == null)
                    return null;
                return new CurrentlyBorrowedBooksSearchCriteria(patron);
            },
            _library.BorrowingTransactionsManager
        );
    }
}
