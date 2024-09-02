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
        string title = UserInterface.GetUserInput("Enter book title: ");
        string author = GetValidatedInput("Enter book author: ", _bookValidator.ValidateValue, "Author must contain only letters");
        string isbn = UserInterface.GetUserInput("Enter book ISBN: ");
        string genre = GetValidatedInput("Enter book genre: ", _bookValidator.ValidateValue, "Genre must contain only letters");
        int publicationYear= TryParsePublicationYear();

        var book = new Book(title, author, isbn, genre, publicationYear);
        bool success = _library.BookManager.Add(book);
        UserInterface.ShowMessage(success ? "Book added successfully." : "Failed to add book.");
    }

    private string GetValidatedInput(string prompt, Func<string, bool> validationFunc, string errorMessage)
    {
        string input;
        while (true)
        {
            input = UserInterface.GetUserInput(prompt);
            if (validationFunc(input))
                break;

            UserInterface.ShowMessage(errorMessage);
        }
        return input;
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
