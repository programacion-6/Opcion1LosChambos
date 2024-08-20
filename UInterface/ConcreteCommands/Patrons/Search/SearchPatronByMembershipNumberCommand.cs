using LosChambos.Entities;
using LosChambos.Entities.Concretes;
using LosChambos.SearchCriteria.Patrons;
using LosChambos.UInterface.CommandInterface;
using LosChambos.UInterface.Menu;

namespace LosChambos.UInterface.ConcreteCommands.Patrons.Search;

public class SearchPatronByMembershipNumberCommand : ICommand
{
    private readonly Library _library;

    public SearchPatronByMembershipNumberCommand(Library library)
    {
        _library = library;
    }

    public void Execute()
    {
        SearchMenuUInterface<Patron>.ShowSearchedData(
            "Enter patron membership number: ",
            input =>
            {
                if (int.TryParse(input, out var membershipNumber))
                    return new MembershipNumberSearchCriteria(membershipNumber);
                else
                    UserInterface.ShowMessage("Invalid membership number format.");
                return null;
            },
            _library.PatronManager
        );
    }
}
