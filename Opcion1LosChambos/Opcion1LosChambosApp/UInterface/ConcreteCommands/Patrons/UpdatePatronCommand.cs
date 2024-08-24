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
        var patron = _library.PatronManager.Items.Find(patron => patron.Id == TryParseId());

        if (patron != null)
        {
            patron.Name = UserInterface.GetUserInput("Enter new name: ");
            patron.ContactDetails = UserInterface.GetUserInput("Enter new contact details: ");

            bool success = _library.PatronManager.Update(patron);
            UserInterface.ShowMessage(
                success ? "Patron updated successfully." : "Failed to update patron."
            );
        }
        else
        {
            UserInterface.ShowMessage("Patron not found.");
        }
    }

    private Guid TryParseId()
    {
        if(Guid.TryParse(UserInterface.GetUserInput("Enter Id of the patron to update: "), out Guid inputParsed))
        {
            return inputParsed;
        }
        else
        {
            UserInterface.ShowMessage("Invalid Id format.");
            return TryParseId();
        }
    }
}
