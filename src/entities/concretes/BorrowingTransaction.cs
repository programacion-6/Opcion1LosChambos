namespace Entities.Concretes;

public class BorrowingTransaction : IEntity
{
    public Guid Id { get; }
    public Book Book;
    public Patron Patron;
    public DateTime BorrowedDate; 
    public DateTime DueDate;
    public DateTime ReturnedDate;
    public Fine? Fine;
    public bool Returned;

    public BorrowingTransaction(Book book, Patron patron, DateTime dueDate)
    {
        Id = Guid.NewGuid();
        Book = book;
        Patron = patron;
        DueDate = dueDate;
        BorrowedDate = DateTime.Now;
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
}
