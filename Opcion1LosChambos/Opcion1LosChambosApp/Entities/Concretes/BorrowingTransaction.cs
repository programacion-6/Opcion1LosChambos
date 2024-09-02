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
