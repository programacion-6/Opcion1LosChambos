using LosChambos.Entities;
using LosChambos.Entities.Concretes;
using LosChambos.SearchCriteria.BorrowingTransactions;
using LosChambos.UInterface.CommandInterface;
using LosChambos.UInterface.Menu;

namespace LosChambos.UInterface.ConcreteCommands.BorrowingTransactions.Search;

public class SearchBorrowedTransactionsHistoryCommand : ICommand
{
    private readonly Library _library;

    public SearchBorrowedTransactionsHistoryCommand(Library library)
    {
        _library = library;
    }

    public void Execute()
    {
        var patron = UserInterface.DisplaySelectableListResult(_library.PatronManager.Items);

        SearchMenuUInterface<BorrowingTransaction>.ShowSearchedDataWithoutPrompt(
            new PatronBorrowingHistorySearchCriteria(patron),
            _library.BorrowingTransactionsManager
        );
    }
}
