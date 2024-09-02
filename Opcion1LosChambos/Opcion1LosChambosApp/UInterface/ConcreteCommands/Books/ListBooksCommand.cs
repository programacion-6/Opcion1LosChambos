using LosChambos.Entities;
using LosChambos.Entities.Concretes;
using LosChambos.Pagination;
using LosChambos.UInterface.CommandInterface;

namespace LosChambos.UInterface.ConcreteCommands.Books;

public class ListBooksCommand : ICommand
{
    private readonly Library _library;
    public ListBooksCommand(Library library)
    {
        _library = library;
    }
    public void Execute()
    {
        var list = _library.BookManager.Items;
        var paginator = new Paginator<Book>(list);
        paginator.DisplayPaginatedList();
    }
}