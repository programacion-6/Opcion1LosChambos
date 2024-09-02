namespace LosChambos.Entities.Concretes;

public class BorrowingTransaction : IEntity
{
    public Guid Id { get; }
    private Book _book;
    private Patron _patron;
    private DateTime _borrowedDate;
    private DateTime _dueDate;
    private DateTime? _returnedDate;
    private Fine? _fine;
    private bool _returned;

    public BorrowingTransaction(Book book, Patron patron, DateTime dueDate)
    {
        Id = Guid.NewGuid();
        _book = book;
        _patron = patron;
        _dueDate = dueDate;
        _borrowedDate = DateTime.Now;
        _returned = false;
    }

    public Book Book 
    { 
        get => _book; 
        set => _book = value; 
    }
    public Patron Patron 
    { 
        get => _patron; 
        set => _patron = value; 
    }
    public DateTime BorrowedDate 
    { 
        get => _borrowedDate; 
        set => _borrowedDate = value; 
    }
    public DateTime DueDate 
    { 
        get => _dueDate; 
        set => _dueDate = value; 
    }
    public DateTime? ReturnedDate 
    { 
        get => _returnedDate; 
        set => _returnedDate = value; 
    }
    public Fine? Fine 
    { 
        get => _fine; 
        set => _fine = value; 
    }
    public bool Returned 
    { 
        get => _returned; 
        set => _returned = value; 
    }
    public void BorrowBook()
    {
        _borrowedDate = DateTime.Now;
        _returned = false;
    }

    public void ReturnBook()
    {
        _returned = true;
        _returnedDate = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Borrowing Transaction:\n"
            + $"Book: \t {Book.Title}\n"
            + $"Author: {Book.Author}\n"
            + $"ISBN: {Book.ISBN}\n"
            + $"Genre: {Book.Genre}\n"
            + $"Publication Year: {Book.PublicationYear}\n"
            + $"===================\n"
            + $"Patron: \t {Patron.Name}\n"
            + $"Membership Number: {Patron.MembershipNumber}\n"
            + $"Contact Details: {Patron.ContactDetails}\n"
            + $"===================\n"
            + $"Borrowed Date: {BorrowedDate:yyyy-MM-dd}\n"
            + $"Due Date: {DueDate:yyyy-MM-dd}\n"
            + $"Returned Date: {(ReturnedDate.HasValue ? ReturnedDate.Value.ToString("yyyy-MM-dd") : "Not Returned")}\n"
            + $"Fine: {(Fine != null ? Fine.ToString() + "\n===================" : "None")}\n";
    }
}
