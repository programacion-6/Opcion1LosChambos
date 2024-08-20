using LosChambos.Entities;
using LosChambos.Entities.Concretes;
using LosChambos.SearchCriteria.Patrons;
using LosChambos.UInterface.CommandInterface;
using LosChambos.UInterface.Menu;

namespace LosChambos.UInterface.ConcreteCommands.Books.Search;

public class SearchPatronByNameCommand : ICommand
{
    private readonly Library _library;

    public SearchPatronByNameCommand(Library library)
    {
        _library = library;
    }

    public void Execute()
    {
        SearchMenuUInterface<Patron>.ShowSearchedData(
            "Enter patron name: ",
            name => new NameSearchCriteria(name),
            _library.PatronManager
        );
    }
}
