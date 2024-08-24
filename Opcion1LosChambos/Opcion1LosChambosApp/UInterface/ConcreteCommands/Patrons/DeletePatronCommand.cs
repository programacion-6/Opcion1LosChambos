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
        var patron = UserInterface.DisplaySelectableListResult(_library.PatronManager.Items); 

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
