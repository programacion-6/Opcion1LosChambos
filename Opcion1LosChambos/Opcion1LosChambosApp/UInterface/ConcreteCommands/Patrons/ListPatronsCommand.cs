using LosChambos.Entities;
using LosChambos.Entities.Concretes;
using LosChambos.Pagination;
using LosChambos.UInterface.CommandInterface;

namespace LosChambos.UInterface.ConcreteCommands.Patrons;

public class ListPatronsCommand : ICommand
{
    private readonly Library _library;
    public ListPatronsCommand(Library library)
    {
        _library = library;
    }
    public void Execute()
    {
        var list = _library.PatronManager.Items;
        var paginator = new Paginator<Patron>(list);
        paginator.DisplayPaginatedList();
    }
}