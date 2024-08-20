using LosChambos.Entities;
using LosChambos.UInterface.CommandInterface;

namespace LosChambos.UInterface.ConcreteCommands.Books;

public class AddBookCommand : ICommand
{
    private readonly Library _library;

    public AddBookCommand(Library library)
    {
        _library = library;
    }

    public void Execute()
    {
        var title = UserInterface.GetUserInput("Enter book title: ");
        var author = UserInterface.GetUserInput("Enter book author: ");
        var isbn = UserInterface.GetUserInput("Enter book ISBN: ");
        var genre = UserInterface.GetUserInput("Enter book genre: ");
        var publicationYear = int.Parse(UserInterface.GetUserInput("Enter publication year: "));

        var book = new Book(title, author, isbn, genre, publicationYear);

        bool success = _library.BookManager.Add(book);
        UserInterface.ShowMessage(success ? "Book added successfully." : "Failed to add book.");
    }
}
