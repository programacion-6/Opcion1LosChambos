using LosChambos.entities.concretes;

namespace LosChambos.SearchCriteria.Books;

public class TitleSearchCriteria : ISearchCriteria<Book>
{
    public string Title { get; set; }

    public TitleSearchCriteria(string title)
    {
        Title = title;
    }

    public bool Matches(Book book)
    {
        return book.Title.Contains(Title, StringComparison.OrdinalIgnoreCase);
    }
}
