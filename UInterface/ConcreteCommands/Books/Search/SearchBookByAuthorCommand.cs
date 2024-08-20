using LosChambos.Entities;
using LosChambos.Entities.Concretes;
using LosChambos.SearchCriteria.Books;
using LosChambos.UInterface.CommandInterface;
using LosChambos.UInterface.Menu;

namespace LosChambos.UInterface.ConcreteCommands.Books.Search;

public class SearchBookByAuthorCommand : ICommand
{
    private readonly Library _library;

    public SearchBookByAuthorCommand(Library library)
    {
        _library = library;
    }

    public void Execute()
    {
        SearchMenuUInterface<Book>.ShowSearchedData(
            "Enter book author: ",
            author => new AuthorSearchCriteria(author),
            _library.BookManager
        );
    }
}
