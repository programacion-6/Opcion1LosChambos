using LosChambos.Entities.Concretes;

namespace Opcion1LosChambosTest.Entities.Concretes;

public class ReservationTest
{
    [Fact]
    public void Reservation_Creation_ValidParameters_ShouldSetProperties()
    {
        var patron = new Patron("John Doe", 1, "contact@example.com");
        var book = new Book("Title", "Author", "ISBN123", "Genre", 2021);
        var expiryDate = DateTime.Now.AddDays(30);
        var reservation = new Reservation(patron, book, expiryDate);

        Assert.NotEqual(Guid.Empty, reservation.Id);
        Assert.Equal(patron, reservation.Patron);
        Assert.Equal(book, reservation.Book);
        Assert.False(reservation.Canceled);
    }

    [Fact]
    public void Reservation_Cancel_ShouldSetCanceledToTrue()
    {
        var patron = new Patron("John Doe", 1, "contact@example.com");
        var book = new Book("Title", "Author", "ISBN123", "Genre", 2021);
        var expiryDate = DateTime.Now.AddDays(30);
        var reservation = new Reservation(patron, book, expiryDate);

        reservation.Cancel();

        Assert.True(reservation.Canceled);
        Assert.NotNull(reservation.CanceledDate);
    }
}