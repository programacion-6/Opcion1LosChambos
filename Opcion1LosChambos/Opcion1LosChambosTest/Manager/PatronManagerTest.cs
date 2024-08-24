using LosChambos.Entities.Concretes;
using LosChambos.Managers;

namespace Opcion1LosChambosTest.Manager;

public class PatronManagerTest
{
    [Fact]
    public void Update_ValidPatron_ShouldUpdateSuccessfully()
    {
        var patron = new Patron("John Doe", 12345, "johndoe@example.com");
        var patronManager = new PatronManager(new List<Patron> { patron });

        var updatedPatron = new Patron("Jane Doe", 12345, "janedoe@example.com");

        var result = patronManager.Update(updatedPatron);

        Assert.False(result);
    }

    [Fact]
    public void Update_NonExistentPatron_ShouldReturnFalse()
    {
        var patron = new Patron("John Doe", 12345, "johndoe@example.com");
        var patronManager = new PatronManager();

        var result = patronManager.Update(patron);

        Assert.False(result);
    }
}