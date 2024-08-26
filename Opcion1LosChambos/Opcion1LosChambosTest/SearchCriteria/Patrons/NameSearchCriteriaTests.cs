using LosChambos.Entities.Concretes;
using LosChambos.SearchCriteria.Patrons;

namespace Opcion1LosChambosTest.SearchCriteria.Patrons;

public class NameSearchCriteriaTests
{
    [Theory]
    [InlineData("John Doe", "John Doe")]
    public void Matches_ReturnsTrue_WhenNameMatchesExactly(string patronName, string searchName)
    {
        var patron = new Patron(patronName, 12345, "john.doe@example.com");
        var criteria = new NameSearchCriteria(searchName);

        var result = criteria.Matches(patron);

        Assert.True(result);
    }

    [Theory]
    [InlineData("john doe", "John Doe")]
    [InlineData("JOHN DOE", "John Doe")]
    [InlineData("John DOE", "john doe")]
    public void Matches_ReturnsTrue_WhenNameMatchesCaseInsensitive(
        string patronName,
        string searchName
    )
    {
        var patron = new Patron(patronName, 12345, "john.doe@example.com");
        var criteria = new NameSearchCriteria(searchName);

        var result = criteria.Matches(patron);

        Assert.True(result);
    }

    [Theory]
    [InlineData("Johnathan Doe", "John")]
    [InlineData("John Doe Jr.", "John Doe")]
    public void Matches_ReturnsTrue_WhenNameMatchesPartially(string patronName, string searchName)
    {
        var patron = new Patron(patronName, 12345, "john.doe@example.com");
        var criteria = new NameSearchCriteria(searchName);

        var result = criteria.Matches(patron);

        Assert.True(result);
    }

    [Fact]
    public void Matches_ReturnsFalse_WhenNameDoesNotMatch()
    {
        var patron = new Patron("John Doe", 12345, "john.doe@example.com");
        var criteria = new NameSearchCriteria("Jane Doe");

        var result = criteria.Matches(patron);

        Assert.False(result);
    }
}
