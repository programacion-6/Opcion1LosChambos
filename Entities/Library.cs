using LosChambos.Entities.Concretes;
using LosChambos.Managers;

namespace LosChambos.Entities;
public class Library
{
    public AManager<Book> BookManager { get; }
    public AManager<Patron> PatronManager { get; }
    public AManager<BorrowingTransaction> BorrowingTransactionsManager { get; }
    public FineManager FineManager { get; }

    public Library()
    {
        BookManager = new BookManager();
        PatronManager = new PatronManager();
        BorrowingTransactionsManager = new BorrowingTransactionsManager();
        FineManager = new FineManager();
    }
}
