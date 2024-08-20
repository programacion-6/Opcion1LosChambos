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
        var id = UserInterface.GetUserInput("Enter Id number of the patron to delete: ");
        var patron = _library.PatronManager.Items.Find(p => p.Id == Guid.Parse(id));

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
