using LosChambos.Entities.Concretes;

namespace Opcion1LosChambosTest.Entities.Concretes;

public class BorrowingTransactionTest
{
    [Fact]
    public void BorrowingTransaction_Creation_ValidParameters_ShouldSetProperties()
    {
        var book = new Book("Title", "Author", "ISBN123", "Genre", 2021);
        var patron = new Patron("John Doe", 1, "contact@example.com");
        var dueDate = DateTime.Now.AddDays(7);
        var transaction = new BorrowingTransaction(book, patron, dueDate);

        Assert.NotEqual(Guid.Empty, transaction.Id);
        Assert.Equal(book, transaction.Book);
        Assert.Equal(patron, transaction.Patron);
        Assert.False(transaction.Returned);
    }

    [Fact]
    public void BorrowingTransaction_ReturnBook_ShouldSetReturnedToTrue()
    {
        var book = new Book("Title", "Author", "ISBN123", "Genre", 2021);
        var patron = new Patron("John Doe", 1, "contact@example.com");
        var dueDate = DateTime.Now.AddDays(7);
        var transaction = new BorrowingTransaction(book, patron, dueDate);

        transaction.ReturnBook();

        Assert.True(transaction.Returned);
        Assert.NotNull(transaction.ReturnedDate);
    }
}