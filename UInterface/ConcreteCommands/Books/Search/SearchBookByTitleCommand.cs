using LosChambos.Entities;
using LosChambos.SearchCriteria.Books;
using LosChambos.UInterface.CommandInterface;
using LosChambos.UInterface.Menu;

namespace LosChambos.UInterface.ConcreteCommands.Books.Search;

public class SearchBookByTitleCommand : ICommand
{
    private readonly Library _library;

    public SearchBookByTitleCommand(Library library)
    {
        _library = library;
    }

    public void Execute()
    {
        SearchMenuUInterface<Book>.ShowSearchedData(
            "Enter book title: ",
            title => new TitleSearchCriteria(title),
            _library.BookManager
        );
    }
}
