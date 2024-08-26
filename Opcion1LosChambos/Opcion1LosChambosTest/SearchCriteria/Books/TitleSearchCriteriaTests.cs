using LosChambos.Entities.Concretes;
using LosChambos.SearchCriteria.Books;

namespace Opcion1LosChambosTest.SearchCriteria.Books;

public class TitleSearchCriteriaTests
{
    [Fact]
    public void Matches_ReturnsTrue_WhenTitleMatchesExactly()
    {
        var book = new Book("C# Programming", "Sample Author", "1234567890", "Fiction", 2024);
        var criteria = new TitleSearchCriteria("C# Programming");

        var result = criteria.Matches(book);

        Assert.True(result);
    }

    [Theory]
    [InlineData("c# programming", "C# Programming")]
    [InlineData("C# PROGRAMMING", "C# Programming")]
    [InlineData("C# programming", "C# PROGRAMMING")]
    public void Matches_ReturnsTrue_WhenTitleMatchesCaseInsensitive(
        string bookTitle,
        string searchTitle
    )
    {
        var book = new Book(bookTitle, "Sample Author", "1234567890", "Fiction", 2024);
        var criteria = new TitleSearchCriteria(searchTitle);

        var result = criteria.Matches(book);

        Assert.True(result);
    }

    [Theory]
    [InlineData("Advanced C# Programming", "C# Programming")]
    [InlineData("Learn C# Programming in Depth", "C#")]
    public void Matches_ReturnsTrue_WhenTitleMatchesPartially(string bookTitle, string searchTitle)
    {
        var book = new Book(bookTitle, "Sample Author", "1234567890", "Fiction", 2024);
        var criteria = new TitleSearchCriteria(searchTitle);

        var result = criteria.Matches(book);

        Assert.True(result);
    }

    [Fact]
    public void Matches_ReturnsFalse_WhenTitleDoesNotMatch()
    {
        var book = new Book("C# Programming", "Sample Author", "1234567890", "Fiction", 2024);
        var criteria = new TitleSearchCriteria("Romeo");

        var result = criteria.Matches(book);

        Assert.False(result);
    }
}
