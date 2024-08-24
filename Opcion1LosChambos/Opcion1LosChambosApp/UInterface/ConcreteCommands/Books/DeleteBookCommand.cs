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
        var bookId = UserInterface.GetUserInput("Enter Id of the book to delete: ");
        var guid  = Guid.TryParse(bookId, out Guid inputParsed);

        if(!guid)
        {
            UserInterface.ShowMessage("Invalid Id Format");
            return;
        }
        
        var book = _library.BookManager.Items.Find(book => book.Id == inputParsed);

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
