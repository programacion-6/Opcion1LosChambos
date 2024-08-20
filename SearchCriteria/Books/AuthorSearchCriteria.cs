using LosChambos.Entities.Concretes;

namespace LosChambos.SearchCriteria.Books;

public class AuthorSearchCriteria : ISearchCriteria<Book>
{
    public string Author { get; set; }

    public AuthorSearchCriteria(string author)
    {
        Author = author;
    }

    public bool Matches(Book book)
    {
        return book.Author.Contains(Author, StringComparison.OrdinalIgnoreCase);
    }
}
