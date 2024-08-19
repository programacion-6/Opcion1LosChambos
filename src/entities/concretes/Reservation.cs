
public class Reservation : IEntity
{
    public Guid Id { get; }
    public Patron Patron { get; set; }
    public Book Book { get; set; }
    public DateTime ReservationDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public bool Canceled { get; set; }
    public DateTime CanceledDate { get; set; }

    public bool IsAvailable()
    {
        return false;
    }

    public void Cancel()
    {
        Canceled = true;
        CanceledDate = DateTime.Now;
    }
}