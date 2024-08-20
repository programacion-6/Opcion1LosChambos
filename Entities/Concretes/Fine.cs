namespace LosChambos.Entities.Concretes;
public class Fine : IEntity
{
    public Guid Id { get; }
    public Patron Patron;
    public double Amount;
    public DateTime DueDate;
    public DateTime? PaidDate;
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

    public override string ToString()
    {
        return $"Fine:\n"
            + $"Id: {Id}\n"
            + $"Patron: \t {Patron}\n===================\n"
            + $"Amount: {Amount}\n"
            + $"DueDate: {DueDate:yyyy-MM-dd}\n"
            + $"PaidDate: {PaidDate:yyyy-MM-dd}\n"
            + $"Paid: {Paid}\n";
    }
}
