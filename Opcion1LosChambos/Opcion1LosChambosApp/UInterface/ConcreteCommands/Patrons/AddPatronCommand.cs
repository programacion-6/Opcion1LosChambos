using LosChambos.DataLoader;
using LosChambos.Entities;
using LosChambos.Entities.Concretes;
using LosChambos.UInterface.CommandInterface;
using LosChambos.Validators.Concretes;

namespace LosChambos.UInterface.ConcreteCommands.Patrons;

public class AddPatronCommand : ICommand
{
    private readonly Library _library;
    private readonly PatronValidator _validator;

    public AddPatronCommand(Library library)
    {
        _library = library;
        _validator = new PatronValidator();
    }

    public void Execute()
    {
        string name = GetValidatedInput("Enter patron name: ", _validator.ValidateName, "Name must contain only letters.");
        int membershipNumber = GetValidatedNumber("Enter membership number: ", "Membership number must be a positive integer.");
        string contactDetails = GetValidatedInput("Enter contact details: ", _validator.ValidateContactDetails, "Contact details must be a valid email address.");

        var patron = new Patron(name, membershipNumber, contactDetails);
        bool success = _library.PatronManager.Add(patron);
        LocalData.SavePatronsToJson(_library.PatronManager.Items);
        UserInterface.ShowMessage(success ? "Patron added successfully." : "Failed to add patron.");
    }

    private string GetValidatedInput(string prompt, Func<string, bool> validationFunc, string errorMessage)
    {
        string input;
        while (true)
        {
            input = UserInterface.GetUserInput(prompt);
            if (validationFunc(input))
                break;

            UserInterface.ShowMessage(errorMessage);
        }
        return input;
    }

    private int GetValidatedNumber(string prompt, string errorMessage)
    {
        int number;
        while (true)
        {
            string input = UserInterface.GetUserInput(prompt);
            if (int.TryParse(input, out number) && number > 0)
                break;

            UserInterface.ShowMessage(errorMessage);
        }
        return number;
    }
}
