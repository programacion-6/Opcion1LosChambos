using LosChambos.Entities.Concretes;
using LosChambos.SearchCriteria.BorrowingTransactions;

namespace Opcion1LosChambosTest.SearchCriteria.BorrowingTransactions;

public class CurrentlyBorrowedBooksSearchCriteriaTests
{
    [Fact]
    public void Matches_ReturnsTrue_WhenTransactionIsCurrentlyBorrowed()
    {
        var patron = new Patron("John Doe", 12345, "john.doe@example.com");
        var book = new Book("C# Programming", "Sample Author", "1234567890", "Fiction", 2024);
        var transaction = new BorrowingTransaction(book, patron, DateTime.Now.AddDays(7));
        var criteria = new CurrentlyBorrowedBooksSearchCriteria(patron);

        var result = criteria.Matches(transaction);

        Assert.True(result);
    }

    [Fact]
    public void Matches_ReturnsFalse_WhenTransactionIsReturned()
    {
        var patron = new Patron("John Doe", 12345, "john.doe@example.com");
        var book = new Book("C# Programming", "Sample Author", "1234567890", "Fiction", 2024);
        var transaction = new BorrowingTransaction(book, patron, DateTime.Now.AddDays(7));
        transaction.ReturnBook();
        var criteria = new CurrentlyBorrowedBooksSearchCriteria(patron);

        var result = criteria.Matches(transaction);

        Assert.False(result);
    }

    [Fact]
    public void Matches_ReturnsFalse_WhenPatronDoesNotMatch()
    {
        var patron = new Patron("John Doe", 12345, "john.doe@example.com");
        var otherPatron = new Patron("Jane Doe", 67890, "jane.doe@example.com");
        var book = new Book("C# Programming", "Sample Author", "1234567890", "Fiction", 2024);
        var transaction = new BorrowingTransaction(book, patron, DateTime.Now.AddDays(7));
        var criteria = new CurrentlyBorrowedBooksSearchCriteria(otherPatron);

        var result = criteria.Matches(transaction);

        Assert.False(result);
    }
}
