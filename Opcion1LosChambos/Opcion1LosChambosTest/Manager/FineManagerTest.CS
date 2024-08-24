using LosChambos.Entities.Concretes;
using LosChambos.Managers;

namespace Opcion1LosChambosTest.Manager;

public class FineManagerTest
{
    [Fact]
    public void Update_ValidFine_ShouldUpdateSuccessfully()
    {
        var patron = new Patron("Name", 12345, "ContactDetails");
        var fine1 = new Fine(patron, 10, DateTime.Now.AddDays(10));
        var fine2 = new Fine(patron, 20, DateTime.Now.AddDays(5));
        var manager = new FineManager(new List<Fine> { fine1, fine2 });

        var updatedFine = new Fine(patron, 30, DateTime.Now.AddDays(3));

        var result = manager.Update(updatedFine);

        Assert.False(result);
        var updatedFineFromManager = manager.Items.First(f => f.Id == fine1.Id);
    }

    [Fact]
    public void Update_NonExistentFine_ShouldReturnFalse()
    {
        var patron = new Patron("Name", 12345, "ContactDetails");
        var fine = new Fine(patron, 10, DateTime.Now.AddDays(10));
        var manager = new FineManager();

        var result = manager.Update(fine);

        Assert.False(result);
        
    }
}