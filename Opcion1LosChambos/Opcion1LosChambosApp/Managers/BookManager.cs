using LosChambos.Entities.Concretes;
using LosChambos.ErrorHandling;
using LosChambos.ErrorHandling.Exceptions;
using LosChambos.Validators.Concretes;

namespace LosChambos.Managers;

public class BookManager : AManager<Book>
{
    public BookManager()
        : base(new BookValidator()) { }

    public BookManager(List<Book> items)
        : base(items, new BookValidator()) { }

    public override bool Update(Book book)
    {
        try
        {
            if (Validator.Validate(book))
            {
                var existingBook = Items.FirstOrDefault(b => b.Id == book.Id);
                if (existingBook == null)
                    return false;

                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Genre = book.Genre;
                existingBook.PublicationYear = book.PublicationYear;
                return true;
            }
        }
        catch (ValidationException exception)
        {
            ErrorHandler.HandleError(exception);
        }
        return false;
    }
}
