namespace LosChambos.Entities.Concretes;

public class Reservation : IEntity
{
    public Guid Id { get; }

    private Patron _patron;
    private Book _book;
    private DateTime _reservationDate;
    private DateTime _expiryDate;
    private bool _canceled;
    private DateTime? _canceledDate;

    public Reservation(Patron patron, Book book, DateTime expiryDate)
    {
        Id = Guid.NewGuid();
        _patron = patron;
        _book = book;
        _reservationDate = DateTime.Now;
        _expiryDate = expiryDate;
        _canceled = false;
    }

    public DateTime ReservationDate
    {
        get => _reservationDate;
        set => _reservationDate = value;
    }

    public DateTime ExpiryDate
    {
        get => _expiryDate;
        set => _expiryDate = value;
    }

    public bool Canceled
    {
        get => _canceled;
        set => _canceled = value;
    }

    public DateTime? CanceledDate
    {
        get => _canceledDate;
        set => _canceledDate = value;
    }

    public bool IsAvailable()
    {
        return !_canceled && DateTime.Now <= _expiryDate;
    }

    public void Cancel()
    {
        _canceled = true;
        _canceledDate = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Reservation:\n"
            + $"Patron: {_patron.Name}\n===================\n"
            + $"Book: {_book.Title}\n===================\n"
            + $"ReservationDate: {_reservationDate:yyyy-MM-dd}\n"
            + $"ExpiryDate: {_expiryDate:yyyy-MM-dd}\n"
            + $"Canceled: {_canceled}\n"
            + $"CanceledDate: {(_canceledDate.HasValue ? _canceledDate.Value.ToString("yyyy-MM-dd") : "Not Canceled")}";
    }
}
