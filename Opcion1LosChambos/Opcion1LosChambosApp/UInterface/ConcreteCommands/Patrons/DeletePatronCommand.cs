using LosChambos.Entities;
using LosChambos.UInterface.CommandInterface;

namespace LosChambos.UInterface.ConcreteCommands.Patrons;

public class DeletePatronCommand : ICommand
{
    private readonly Library _library;

    public DeletePatronCommand(Library library)
    {
        _library = library;
    }

    public void Execute()
    {
        var patronId = UserInterface.GetUserInput("Enter Id number of the patron to delete: ");
        var guid = Guid.TryParse(patronId, out Guid inputParsed);

        if(!guid)
        {
            UserInterface.ShowMessage("Invalid Id format.");
            return;
        }

        var patron = _library.PatronManager.Items.Find(patron => patron.Id == inputParsed);

        if (patron != null)
        {
            bool success = _library.PatronManager.Remove(patron);
            UserInterface.ShowMessage(
                success ? "Patron deleted successfully." : "Failed to delete patron."
            );
        }
        else
        {
            UserInterface.ShowMessage("Patron not found.");
        }
    }
}
