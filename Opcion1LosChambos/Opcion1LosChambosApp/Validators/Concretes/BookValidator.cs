
using LosChambos.Entities.Concretes;

namespace LosChambos.Validators.Concretes;

public class BookValidator : Validator<Book>
{
    protected override void InitializeValidations()
    {
        Validations.Add("Title is required.", book => !string.IsNullOrEmpty(book.Title));
        Validations.Add("Author is required.", book => !string.IsNullOrEmpty(book.Author) && book.Author.All(char.IsLetter));
        Validations.Add("ISBN is required.", book => !string.IsNullOrEmpty(book.ISBN));
        Validations.Add("Genre is required.", book => !string.IsNullOrEmpty(book.Genre) && book.Genre.All(char.IsLetter));
        Validations.Add("Publication year must be positive.", book => book.PublicationYear > 0);
    }

    public bool ValidateValue(string value) => 
        !string.IsNullOrEmpty(value) && value.All(char.IsLetter);
}
