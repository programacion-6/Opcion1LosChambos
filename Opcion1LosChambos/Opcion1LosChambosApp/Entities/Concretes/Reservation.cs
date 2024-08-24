namespace LosChambos.Entities.Concretes;

public class Reservation : IEntity
{
    public Guid Id { get; }
    public Patron Patron { get; set; }
    public Book Book { get; set; }
    public DateTime ReservationDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public bool Canceled { get; set; }
    public DateTime? CanceledDate { get; set; }

    public Reservation(Patron patron, Book book, DateTime expiryDate)
    {
        Id = Guid.NewGuid();
        Patron = patron;
        Book = book;
        ReservationDate = DateTime.Now;
        ExpiryDate = expiryDate;
    }

    public bool IsAvailable()
    {
        return !Canceled && DateTime.Now <= ExpiryDate;
    }

    public void Cancel()
    {
        Canceled = true;
        CanceledDate = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Reservation:\n"
            + $"Id: {Id}\n"
            + $"Patron: {Patron}\n===================\n"
            + $"Book: {Book}\n===================\n"
            + $"ReservationDate: {ReservationDate:yyyy-MM-dd}\n"
            + $"ExpiryDate: {ExpiryDate:yyyy-MM-dd}\n"
            + $"Canceled: {Canceled}\n"
            + $"CanceledDate: {CanceledDate?.ToString("yyyy-MM-dd")}";
    }
}
