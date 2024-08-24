using LosChambos.Entities;
using LosChambos.Entities.Concretes;
using LosChambos.UInterface.CommandInterface;

namespace LosChambos.UInterface.ConcreteCommands.Patrons;

public class AddPatronCommand : ICommand
{
    private readonly Library _library;

    public AddPatronCommand(Library library)
    {
        _library = library;
    }

    public void Execute()
    {
        var name = UserInterface.GetUserInput("Enter patron name: ");
        var membershipNumber = TryParseMembershipNumber();
        var contactDetails = UserInterface.GetUserInput("Enter contact details: ");

        var patron = new Patron(name, membershipNumber, contactDetails);

        bool success = _library.PatronManager.Add(patron);
        UserInterface.ShowMessage(success ? "Patron added successfully." : "Failed to add patron.");
    }

    private int TryParseMembershipNumber()
    {
        if(int.TryParse(UserInterface.GetUserInput("Enter membership number: "), out int inputParsed))
        {
            return inputParsed;
        }
        else
        {
            UserInterface.ShowMessage("Enter a correct value.");
            return TryParseMembershipNumber();
        }
    }
}
