using LosChambos.Entities.Concretes;

namespace Opcion1LosChambosTest.Entities.Concretes;

public class FineTest
{
    [Fact]
    public void Fine_Creation_ValidParameters_ShouldSetProperties()
    {
        var patron = new Patron("John Doe", 1, "contact@example.com");
        var fine = new Fine(patron, 10.0, DateTime.Now.AddDays(30));

        Assert.NotEqual(Guid.Empty, fine.Id);
        Assert.Equal(patron, fine.Patron);
        Assert.Equal(10.0, fine.Amount);
    }

    [Fact]
    public void Fine_PayFine_ShouldSetPaidToTrue()
    {
        var patron = new Patron("John Doe", 1, "contact@example.com");
        var fine = new Fine(patron, 10.0, DateTime.Now.AddDays(30));

        fine.PayFine();

        Assert.True(fine.Paid);
        Assert.NotNull(fine.PaidDate);
    }
}