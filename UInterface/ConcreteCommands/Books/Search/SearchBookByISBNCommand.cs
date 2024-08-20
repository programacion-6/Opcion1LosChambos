using LosChambos.Entities;
using LosChambos.SearchCriteria.Books;
using LosChambos.UInterface.CommandInterface;
using LosChambos.UInterface.Menu;

namespace Opcion1FabianRomero.src.UInterface.ConcreteCommands.Books.Search;

public class SearchBookByISBNCommand : ICommand
{
    private readonly Library _library;

    public SearchBookByISBNCommand(Library library)
    {
        _library = library;
    }

    public void Execute()
    {
        SearchMenuUInterface<Book>.ShowSearchedData(
            "Enter book ISBN: ",
            isbn => new ISBNSearchCriteria(isbn),
            _library.BookManager
        );
    }
}
