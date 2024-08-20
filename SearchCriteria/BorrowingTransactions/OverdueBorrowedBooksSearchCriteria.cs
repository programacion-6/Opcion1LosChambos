using LosChambos.Entities.Concretes;

namespace LosChambos.SearchCriteria.BorrowingTransactions;

public class OverdueBorrowedBooksSearchCriteria : ISearchCriteria<BorrowingTransaction>
{
    public Patron Patron { get; set; }

    public OverdueBorrowedBooksSearchCriteria(Patron patron)
    {
        Patron = patron;
    }

    public bool Matches(BorrowingTransaction transaction)
    {
        return transaction.Patron == Patron
            && !transaction.Returned
            && transaction.DueDate < DateTime.Now;
    }
}
