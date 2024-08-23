using LosChambos.Entities.Concretes;

namespace LosChambos.SearchCriteria.Books;

public class ISBNSearchCriteria : ISearchCriteria<Book>
{
    public string ISBN { get; set; }

    public ISBNSearchCriteria(string isbn)
    {
        ISBN = isbn;
    }

    public bool Matches(Book book)
    {
        return book.ISBN.Equals(ISBN, StringComparison.OrdinalIgnoreCase);
    }
}
