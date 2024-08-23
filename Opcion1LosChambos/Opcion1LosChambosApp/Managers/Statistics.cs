using LosChambos.Entities.Concretes;

namespace LosChambos.Managers;

public class Statistics
{
    public List<BorrowingTransaction> Transactions { get; set; }

    public Statistics()
    {
        Transactions = [];
    }

    public Statistics(List<BorrowingTransaction> transactions)
    {
        Transactions = transactions;
    }

    public List<Book> GetMostBorrowedBooks(int limit = 10)
    {
        return Transactions
            .GroupBy(t => t.Book)
            .OrderByDescending(g => g.Count())
            .Take(limit)
            .Select(g => g.Key)
            .ToList();
    }

    public List<Patron> GetMostActivePatrons(int limit = 10)
    {
        return Transactions
            .GroupBy(t => t.Patron)
            .OrderByDescending(g => g.Count())
            .Take(limit)
            .Select(g => g.Key)
            .ToList();
    }

    public List<Book> GetMostBorrowedBooks()
    {
        return GetMostBorrowedBooks(10);
    }

    public List<Patron> GetMostActivePatrons()
    {
        return GetMostActivePatrons(10);
    }
}
