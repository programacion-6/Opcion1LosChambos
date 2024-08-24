using LosChambos.Entities.Concretes;
using LosChambos.SearchCriteria.Books;

namespace Opcion1LosChambosTest.SearchCriteria.Books;

public class AuthorSearchCriteriaTests
{
    [Fact]
    public void Matches_ReturnsTrue_WhenAuthorMatchesExactly()
    {
        var book = new Book("Sample Title", "John Doe", "1234567890", "Fiction", 2024);
        var criteria = new AuthorSearchCriteria("John Doe");

        var result = criteria.Matches(book);

        Assert.True(result);
    }

    [Theory]
    [InlineData("john doe", "John Doe")]
    [InlineData("JOHN DOE", "John Doe")]
    public void Matches_ReturnsTrue_WhenAuthorMatchesCaseInsensitive(
        string bookAuthor,
        string searchAuthor
    )
    {
        var book = new Book("Sample Title", bookAuthor, "1234567890", "Fiction", 2024);
        var criteria = new AuthorSearchCriteria(searchAuthor);

        var result = criteria.Matches(book);

        Assert.True(result);
    }

    [Theory]
    [InlineData("Johnathan Doe", "John")]
    [InlineData("Jonathan Doe", "Jon")]
    public void Matches_ReturnsTrue_WhenAuthorMatchesPartially(
        string bookAuthor,
        string searchAuthor
    )
    {
        var book = new Book("Sample Title", bookAuthor, "1234567890", "Fiction", 2024);
        var criteria = new AuthorSearchCriteria(searchAuthor);

        var result = criteria.Matches(book);

        Assert.True(result);
    }

    [Fact]
    public void Matches_ReturnsFalse_WhenAuthorDoesNotMatch()
    {
        var book = new Book("Sample Title", "John Doe", "1234567890", "Fiction", 2024);
        var criteria = new AuthorSearchCriteria("Harper Lee");

        var result = criteria.Matches(book);

        Assert.False(result);
    }
}
