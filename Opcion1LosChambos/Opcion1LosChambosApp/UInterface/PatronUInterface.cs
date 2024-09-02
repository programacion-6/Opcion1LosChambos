using LosChambos.Entities.Concretes;
using LosChambos.UInterface;
using LosChambos.UInterface.CommandInterface;
using LosChambos.UInterface.ConcreteCommands.Patrons;
using LosChambos.UInterface.ConcreteCommands.Patrons.Search;
using LosChambos.UInterface.ConcreteCommands.Search;
using LosChambos.UInterface.Menu;

namespace LosChambos.Entities;

public class PatronUInterface : BaseUInterface<Patron>
{
    public PatronUInterface(Library library)
        : base(library, "Patron") { }

    protected override SearchMenuUInterface<Patron> CreateSearchInterface()
    {
        var searchCommands = new Dictionary<string, ICommand>
        {
            { "1", new SearchPatronByNameCommand(_library) },
            { "2", new SearchPatronByMembershipNumberCommand(_library) },
        };

        var searchLabels = new List<string> { "Name", "Membership Number" };

        return new SearchMenuUInterface<Patron>(
            searchCommands,
            searchLabels,
            _menuTitle,
            _library.PatronManager
        );
    }

    protected override MainMenuUInterface CreateMainMenuInterface()
    {
        var menuCommands = new Dictionary<string, ICommand>
        {
            { "1", new AddPatronCommand(_library) },
            { "2", new DeletePatronCommand(_library) },
            { "3", new UpdatePatronCommand(_library) },
            { "4", new SearchMenuCommand(_searchInterface) },
            { "5", new ListPatronsCommand(_library) },
        };

        var menuLabels = new List<string>
        {
            "Add Patron",
            "Delete Patron",
            "Update Patron",
            "Search Patron",
            "List all Patrons"
        };

        return new MainMenuUInterface(menuCommands, menuLabels, _menuTitle);
    }
}
