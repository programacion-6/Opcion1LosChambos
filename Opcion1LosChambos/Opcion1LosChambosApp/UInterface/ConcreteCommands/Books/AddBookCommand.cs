using LosChambos.DataLoader;
using LosChambos.Entities;
using LosChambos.Entities.Concretes;
using LosChambos.UInterface.CommandInterface;
using LosChambos.Validators.Concretes;
using LosChambos.ErrorHandling.Exceptions;

namespace LosChambos.UInterface.ConcreteCommands.Books;

public class AddBookCommand : ICommand
{
    private readonly Library _library;
    private readonly BookValidator _bookValidator;

    public AddBookCommand(Library library)
    {
        _library = library;
        _bookValidator = new BookValidator();
    }

    public void Execute()
    {
        string title, author, isbn, genre;
        int publicationYear;
        
        do
        {
            title = UserInterface.GetUserInput("Enter book title: ");
            author = UserInterface.GetUserInput("Enter book author: ");
            isbn = UserInterface.GetUserInput("Enter book ISBN: ");
            genre = UserInterface.GetUserInput("Enter book genre: ");
            publicationYear = TryParsePublicationYear();

            var book = new Book(title, author, isbn, genre, publicationYear);

            try
            {
                _bookValidator.Validate(book);
                bool success = _library.BookManager.Add(book);
                LocalData.SaveBooksToJson(_library.BookManager.Items);
                UserInterface.ShowMessage(success ? "Book added successfully." : "Failed to add book.");
                break; 
            }
            catch (ValidationException ex)
            {
                UserInterface.ShowMessage(ex.Message);
            }

        } while (true); 
    }


    private int TryParsePublicationYear()
    {
        while (true)
        {
            if (int.TryParse(UserInterface.GetUserInput("Enter publication year: "), out int inputParsed) && inputParsed > 0)
            {
                return inputParsed;
            }
            UserInterface.ShowMessage("Enter a correct value.");
        }
    }
}
