namespace LosChambos.Entities.Concretes;

public class BorrowingTransaction : IEntity
{
    public Guid Id { get; }
    public Book Book;
    public Patron Patron;
    public DateTime BorrowedDate;
    public DateTime DueDate;
    public DateTime? ReturnedDate;
    public Fine? Fine;
    public bool Returned;

    public BorrowingTransaction(Book book, Patron patron, DateTime dueDate)
    {
        Id = Guid.NewGuid();
        Book = book;
        Patron = patron;
        DueDate = dueDate;
        BorrowedDate = DateTime.Now;
        Returned = false;
    }

    public void BorrowBook()
    {
        BorrowedDate = DateTime.Now;
        Returned = false;
    }

    public void ReturnBook()
    {
        Returned = true;
        ReturnedDate = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Borrowing Transaction:"
            + $"Book: \t {Book}\n===================\n"
            + $"Patron: \t {Patron}\n===================\n"
            + $"Borrowed Date: {BorrowedDate:yyyy-MM-dd}\n"
            + $"Due Date: {DueDate}\n"
            + $"Returned Date: {ReturnedDate:yyyy-MM-dd}\n"
            + $"Returned: {Returned}\n"
            + $"Fine: {(Fine != null ? Fine + "\n===================" : "None")}\n";
    }
}
