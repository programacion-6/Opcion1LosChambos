using LosChambos.DataLoader;
using LosChambos.Entities;
using LosChambos.Entities.Concretes;
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
        
        var publicationYear = TryParsePublicationYear();

        var book = new Book(title, author, isbn, genre, publicationYear);

        bool success = _library.BookManager.Add(book);
        LocalData.SaveBooksToJson(_library.BookManager.Items);
        UserInterface.ShowMessage(success ? "Book added successfully." : "Failed to add book.");
    }

    private int TryParsePublicationYear()
    {
        if(int.TryParse(UserInterface.GetUserInput("Enter publication year: "), out int inputParsed))
        {
            return inputParsed;
        }
        else
        {
           UserInterface.ShowMessage("Enter a correct value.");
            return TryParsePublicationYear();
        }
    }
}
