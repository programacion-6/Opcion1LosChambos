using LosChambos.Entities;
using LosChambos.UInterface.CommandInterface;

namespace LosChambos.UInterface.ConcreteCommands.Books;

public class UpdateBookCommand : ICommand
{
    private readonly Library _library;

    public UpdateBookCommand(Library library)
    {
        _library = library;
    }

    public void Execute()
    {
        var book = UserInterface.DisplaySelectableListResult(_library.BookManager.Items); 

        if (book != null)
        {
            book.Title = UserInterface.GetUserInput("Enter new title: ");
            book.Author = UserInterface.GetUserInput("Enter new author: ");
            book.Genre = UserInterface.GetUserInput("Enter new genre: ");
            book.PublicationYear = tryParsePublicationYear();

            bool success = _library.BookManager.Update(book);
            UserInterface.ShowMessage(
                success ? "Book updated successfully." : "Failed to update book."
            );
        }
        else
        {
            UserInterface.ShowMessage("Book not found.");
        }
    }

    private Guid TryParseId()
    {
        if(Guid.TryParse(UserInterface.GetUserInput("Enter Id of the book to update: "), out Guid inputParsed))
        {
            return inputParsed;
        }
        else
        {
            UserInterface.ShowMessage("Enter a correct value.");
            return TryParseId();
        }
    }

    private int tryParsePublicationYear()
    {
        if(int.TryParse(UserInterface.GetUserInput("Enter new publication year: "), out int inputParsed))
        {
            return inputParsed;
        }
        else
        {
            UserInterface.ShowMessage("Enter a correct value.");
            return tryParsePublicationYear();
        }
    }
}
