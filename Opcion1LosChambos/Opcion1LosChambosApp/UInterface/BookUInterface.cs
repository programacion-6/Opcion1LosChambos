using LosChambos.Entities;
using LosChambos.Entities.Concretes;
using LosChambos.UInterface.CommandInterface;
using LosChambos.UInterface.ConcreteCommands.Books;
using LosChambos.UInterface.ConcreteCommands.Books.Search;
using LosChambos.UInterface.ConcreteCommands.Search;
using LosChambos.UInterface.Menu;

namespace LosChambos.UInterface;

public class BookUInterface : BaseUInterface<Book>
{
    public BookUInterface(Library library)
        : base(library, "Book") { }

    protected override SearchMenuUInterface<Book> CreateSearchInterface()
    {
        var searchActions = new Dictionary<string, ICommand>
        {
            { "1", new SearchBookByTitleCommand(_library) },
            { "2", new SearchBookByISBNCommand(_library) },
            { "3", new SearchBookByAuthorCommand(_library) },
        };

        var searchLabels = new List<string> { "Name", "ISBN", "Author" };

        return new SearchMenuUInterface<Book>(
            searchActions,
            searchLabels,
            _menuTitle,
            _library.BookManager
        );
    }

    protected override MainMenuUInterface CreateMainMenuInterface()
    {
        var menuCommands = new Dictionary<string, ICommand>
        {
            { "1", new AddBookCommand(_library) },
            { "2", new DeleteBookCommand(_library) },
            { "3", new UpdateBookCommand(_library) },
            { "4", new SearchMenuCommand(_searchInterface) },
            { "5", new ListBooksCommand(_library) },
        };

        var menuLabels = new List<string>
        {
            "Add Book",
            "Delete Book",
            "Update Book",
            "Search Book",
            "List all Books"
        };

        return new MainMenuUInterface(menuCommands, menuLabels, _menuTitle);
    }
}
