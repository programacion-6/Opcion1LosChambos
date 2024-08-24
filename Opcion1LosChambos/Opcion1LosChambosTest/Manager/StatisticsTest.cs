using LosChambos.Entities.Concretes;
using LosChambos.Managers;

namespace Opcion1LosChambosTest.Manager;

public class StatisticsTest
{
    [Fact]
    public void GetMostBorrowedBooks_ReturnsCorrectBooks()
    {
        var book1 = new Book("Title 1", "Author 1", "ISBN123", "Genre", 2021);
        var book2 = new Book("Title 2", "Author 2", "ISBN124", "Genre", 2021);
        var patron = new Patron("John Doe", 1, "contact@example.com");
        var dueDate = DateTime.Now.AddDays(7);

        var transactions = new List<BorrowingTransaction>
            {
                new BorrowingTransaction(book1, patron, dueDate),
                new BorrowingTransaction(book1, patron, dueDate),
                new BorrowingTransaction(book2, patron, dueDate)
            };

        var statistics = new Statistics(transactions);

        var mostBorrowedBooks = statistics.GetMostBorrowedBooks();

        Assert.Equal(2, mostBorrowedBooks.Count);
        Assert.Equal(book1, mostBorrowedBooks.First());
    }

    [Fact]
    public void GetMostActivePatrons_ReturnsCorrectPatrons()
    {
        var patron1 = new Patron("Patron 1", 1, "patron1@example.com");
        var patron2 = new Patron("Patron 2", 2, "patron2@example.com");
        var dueDate = DateTime.Now.AddDays(7);

        var transactions = new List<BorrowingTransaction>
            {
                new BorrowingTransaction(new Book("Book 1", "Author", "ISBN1", "Genre", 2021), patron1, dueDate),
                new BorrowingTransaction(new Book("Book 2", "Author", "ISBN2", "Genre", 2021), patron1, dueDate),
                new BorrowingTransaction(new Book("Book 3", "Author", "ISBN3", "Genre", 2021), patron2, dueDate)
            };

        var statistics = new Statistics(transactions);

        var mostActivePatrons = statistics.GetMostActivePatrons();

        Assert.Equal(2, mostActivePatrons.Count);
        Assert.Equal(patron1, mostActivePatrons.First());
    }

    [Fact]
    public void GetMostBorrowedBooks_WithLimit_ReturnsLimitedBooks()
    {
        var transactions = Enumerable.Range(1, 20)
            .Select(i => new BorrowingTransaction(
                new Book($"Book {i}", "Author", $"ISBN{i}", "Genre", 2021),
                new Patron($"Patron {i}", i, $"patron{i}@example.com"),
                DateTime.Now.AddDays(7)))
            .ToList();

        var statistics = new Statistics(transactions);

        var mostBorrowedBooks = statistics.GetMostBorrowedBooks(5);
        
        Assert.Equal(5, mostBorrowedBooks.Count);
    }

    [Fact]
    public void GetMostActivePatrons_WithLimit_ReturnsLimitedPatrons()
    {
        var transactions = Enumerable.Range(1, 20)
            .Select(i => new BorrowingTransaction(
                new Book("Book", "Author", "ISBN", "Genre", 2021),
                new Patron($"Patron {i}", i, $"patron{i}@example.com"),
                DateTime.Now.AddDays(7)))
            .ToList();

        var statistics = new Statistics(transactions);

        var mostActivePatrons = statistics.GetMostActivePatrons(5);

        Assert.Equal(5, mostActivePatrons.Count);
    }
}