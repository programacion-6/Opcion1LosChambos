using LosChambos.Entities.Concretes;

namespace Opcion1LosChambosTest.Entities.Concretes;

public class PatronTest
{
    [Fact]
    public void Patron_Creation_ValidParameters_ShouldSetProperties()
    {
        var patron = new Patron("John Doe", 1, "contact@example.com");

        Assert.NotEqual(Guid.Empty, patron.Id);
        Assert.Equal("John Doe", patron.Name);
        Assert.Equal(1, patron.MembershipNumber);
        Assert.Equal("contact@example.com", patron.ContactDetails);
    }
}
