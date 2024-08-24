using LosChambos.Entities;
using LosChambos.UInterface.CommandInterface;

namespace LosChambos.UInterface.ConcreteCommands.Books;

public class DeleteBookCommand : ICommand
{
    private readonly Library _library;

    public DeleteBookCommand(Library library)
    {
        _library = library;
    }

    public void Execute()
    {
        var book = UserInterface.DisplaySelectableListResult(_library.BookManager.Items); 

        if (book != null)
        {
            bool success = _library.BookManager.Remove(book);
            UserInterface.ShowMessage(
                success ? "Book deleted successfully." : "Failed to delete book."
            );
        }
        else
        {
            UserInterface.ShowMessage("Book not found.");
        }
    }
}
