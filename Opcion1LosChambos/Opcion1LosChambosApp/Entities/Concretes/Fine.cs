namespace LosChambos.Entities.Concretes;
public class Fine : IEntity
{
    public Guid Id { get; }

    private Patron _patron;
    private double _amount;
    private DateTime _dueDate;
    private DateTime? _paidDate;
    private bool _paid;

    public Fine(Patron patron, double amount, DateTime dueDate)
    {
        Id = Guid.NewGuid();
        _patron = patron;
        _amount = amount;
        _dueDate = dueDate;
        _paid = false;
    }

    public double Amount
    {
        get => _amount;
        set => _amount = value;
    }

    public DateTime DueDate
    {
        get => _dueDate;
        set => _dueDate = value;
    }

    public DateTime? PaidDate
    {
        get => _paidDate;
        set => _paidDate = value;
    }

    public bool Paid
    {
        get => _paid;
        set => _paid = value;
    }

    public void PayFine()
    {
        _paid = true;
        _paidDate = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Fine:\n"
            + $"Patron: \t {_patron.Name}\n===================\n"
            + $"Amount: {Amount}\n"
            + $"DueDate: {DueDate:yyyy-MM-dd}\n"
            + $"PaidDate: {(PaidDate.HasValue ? PaidDate.Value.ToString("yyyy-MM-dd") : "Not Paid")}\n"
            + $"Paid: {Paid}\n";
    }
}
