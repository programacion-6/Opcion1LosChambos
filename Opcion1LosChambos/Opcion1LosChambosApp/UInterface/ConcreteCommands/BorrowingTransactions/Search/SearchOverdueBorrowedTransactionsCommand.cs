using LosChambos.Entities;
using LosChambos.Entities.Concretes;
using LosChambos.SearchCriteria.BorrowingTransactions;
using LosChambos.UInterface.CommandInterface;
using LosChambos.UInterface.Menu;

namespace LosChambos.UInterface.ConcreteCommands.BorrowingTransactions.Search;

public class SearchOverdueBorrowedTransactionsCommand : ICommand
{
    private readonly Library _library;

    public SearchOverdueBorrowedTransactionsCommand(Library library)
    {
        _library = library;
    }

    public void Execute()
    {
        var patron = UserInterface.DisplaySelectableListResult(_library.PatronManager.Items);

        SearchMenuUInterface<BorrowingTransaction>.ShowSearchedDataWithoutPrompt(
            new OverdueBorrowedBooksSearchCriteria(patron),
            _library.BorrowingTransactionsManager
        );
    }
}
