using LosChambos.Entities.Concretes;
using LosChambos.SearchCriteria.Books;

namespace Opcion1LosChambosTest.SearchCriteria.Books;

public class ISBNSearchCriteriaTests
{
    [Fact]
    public void Matches_ReturnsTrue_WhenISBNMatchesExactly()
    {
        var book = new Book("Sample Title", "Sample Author", "1234567890de", "Fiction", 2024);
        var criteria = new ISBNSearchCriteria("1234567890de");

        var result = criteria.Matches(book);

        Assert.True(result);
    }

    [Theory]
    [InlineData("Ab-1234567890", "ab-1234567890")]
    [InlineData("AB-1234567890", "ab-1234567890")]
    [InlineData("ab-1234567890", "AB-1234567890")]
    public void Matches_ReturnsTrue_WhenISBNMatchesCaseInsensitive(
        string bookISBN,
        string searchISBN
    )
    {
        var book = new Book("Sample Title", "Sample Author", bookISBN, "Fiction", 2024);
        var criteria = new ISBNSearchCriteria(searchISBN);

        var result = criteria.Matches(book);

        Assert.True(result);
    }

    [Theory]
    [InlineData("123-456-7890", "123")]
    [InlineData("123-456-7890", "123-456")]
    public void Matches_ReturnsTrue_WhenISBNMatchesPartially(string bookISBN, string searchISBN)
    {
        var book = new Book("Sample Title", "Sample Author", bookISBN, "Fiction", 2024);
        var criteria = new ISBNSearchCriteria(searchISBN);

        var result = criteria.Matches(book);

        Assert.True(result);
    }

    [Fact]
    public void Matches_ReturnsFalse_WhenISBNDoesNotMatch()
    {
        var book = new Book("Sample Title", "Sample Author", "1234567890", "Fiction", 2024);
        var criteria = new ISBNSearchCriteria("1234567890a");

        var result = criteria.Matches(book);

        Assert.False(result);
    }
}
