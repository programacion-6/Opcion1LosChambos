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
        var book = _library.BookManager.Items.Find(b => b.Id == TryParseId());

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

    private Guid TryParseId()
    {
        if(Guid.TryParse(UserInterface.GetUserInput("Enter Id of the book to delete: "), out Guid inputParsed))
        {
            return inputParsed;
        }
        else
        {
            UserInterface.ShowMessage("Invalid Id Format");
            return TryParseId();
        }
    }
}
