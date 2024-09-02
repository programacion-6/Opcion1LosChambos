using LosChambos.DataLoader;
using LosChambos.Entities;
using LosChambos.UInterface.CommandInterface;

namespace LosChambos.UInterface.ConcreteCommands.Patrons;

public class UpdatePatronCommand : ICommand
{
    private readonly Library _library;

    public UpdatePatronCommand(Library library)
    {
        _library = library;
    }

    public void Execute()
    {
        var patron = UserInterface.DisplaySelectableListResult(_library.PatronManager.Items); 

        if (patron != null)
        {
            patron.Name = UserInterface.GetUserInput("Enter new name: ");
            patron.ContactDetails = UserInterface.GetUserInput("Enter new contact details: ");

            bool success = _library.PatronManager.Update(patron);
            LocalData.SavePatronsToJson(_library.PatronManager.Items);
            UserInterface.ShowMessage(
                success ? "Patron updated successfully." : "Failed to update patron."
            );
        }
        else
        {
            UserInterface.ShowMessage("Patron not found.");
        }
    }
}
