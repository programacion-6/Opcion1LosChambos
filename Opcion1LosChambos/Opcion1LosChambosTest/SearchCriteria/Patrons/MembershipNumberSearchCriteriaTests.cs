using LosChambos.Entities.Concretes;
using LosChambos.SearchCriteria.Patrons;

namespace Opcion1LosChambosTest.SearchCriteria.Patrons;

public class MembershipNumberSearchCriteriaTests
{
    [Fact]
    public void Matches_ReturnsTrue_WhenMembershipNumberMatchesExactly()
    {
        var patron = new Patron("John Doe", 12345, "john.doe@example.com");
        var criteria = new MembershipNumberSearchCriteria(12345);

        var result = criteria.Matches(patron);

        Assert.True(result);
    }

    [Fact]
    public void Matches_ReturnsFalse_WhenMembershipNumberDoesNotMatch()
    {
        var patron = new Patron("John Doe", 12345, "john.doe@example.com");
        var criteria = new MembershipNumberSearchCriteria(67890);

        var result = criteria.Matches(patron);

        Assert.False(result);
    }
}
