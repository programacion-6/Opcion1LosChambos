
using LosChambos.Entities.Concretes;

namespace LosChambos.Validators.Concretes;

public class BookValidator : Validator<Book>
{
    protected override void InitializeValidations()
    {
        Validations.Add("Title is required.", book => !string.IsNullOrEmpty(book.Title));
        Validations.Add("Title must consist of alphabetic characters, spaces, or hyphens only.", 
            book => System.Text.RegularExpressions.Regex.IsMatch(book.Title, @"^[a-zA-Z\s-]+$"));
        Validations.Add("Author is required.", book => !string.IsNullOrEmpty(book.Author));
        Validations.Add("Author name must consist of alphabetic characters, spaces, or hyphens only.", 
            book => System.Text.RegularExpressions.Regex.IsMatch(book.Author, @"^[a-zA-Z\s-]+$"));
        Validations.Add("ISBN is required.", book => !string.IsNullOrEmpty(book.ISBN));
        Validations.Add("Genre is required.", book => !string.IsNullOrEmpty(book.Genre));
        Validations.Add("Genre must consist of alphabetic characters, spaces, or hyphens only.", 
            book => System.Text.RegularExpressions.Regex.IsMatch(book.Genre, @"^[a-zA-Z\s-]+$"));
        Validations.Add("Publication year must be positive.", book => book.PublicationYear > 0);
    }
}
