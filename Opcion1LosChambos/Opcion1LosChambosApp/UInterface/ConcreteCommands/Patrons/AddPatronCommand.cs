using LosChambos.DataLoader;
using LosChambos.Entities;
using LosChambos.Entities.Concretes;
using LosChambos.UInterface.CommandInterface;
using LosChambos.Validators.Concretes;

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
        var name = GetValidName();
        var membershipNumber = TryParseMembershipNumber();
        var contactDetails = GetValidContactDetails();

        var patron = new Patron(name, membershipNumber, contactDetails);

        bool success = _library.PatronManager.Add(patron);
        LocalData.SavePatronsToJson(_library.PatronManager.Items);
        UserInterface.ShowMessage(success ? "Patron added successfully." : "Failed to add patron.");
    }

    private static int TryParseMembershipNumber()
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

    private static string GetValidName()
    {
        var name = UserInterface.GetUserInput("Enter patron name: ");
        if (!string.IsNullOrWhiteSpace(name))
        {
            return name;
        }
        else
        {
            UserInterface.ShowMessage("Name cannot be empty.");
            return GetValidName();
        }
    }

    private static string GetValidContactDetails()
    {
        var contactDetails = UserInterface.GetUserInput("Enter contact details: ");
        if (!string.IsNullOrWhiteSpace(contactDetails))
        {
            return contactDetails;
        }
        else
        {
            UserInterface.ShowMessage("Contact details cannot be empty.");
            return GetValidContactDetails();
        }
    }
}
