namespace LosChambos.Entities.Concretes;
public class Fine : IEntity
{
    public Guid Id { get; }
    public Patron Patron;
    public double Amount;
    public DateTime DueDate;
    public DateTime PaidDate;
    public bool Paid;

    public Fine(Patron patron, double amount, DateTime dueDate)
    {
        Id = Guid.NewGuid();
        Patron = patron;
        Amount = amount;
        DueDate = dueDate;
    }

    public void PayFine()
    {
        Paid = true;
        PaidDate = DateTime.Now;
    }
}
