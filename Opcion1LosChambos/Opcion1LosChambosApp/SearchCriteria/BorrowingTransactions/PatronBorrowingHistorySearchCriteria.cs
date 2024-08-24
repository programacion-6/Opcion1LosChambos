using LosChambos.Entities.Concretes;

namespace LosChambos.SearchCriteria.BorrowingTransactions;

public class PatronBorrowingHistorySearchCriteria : ISearchCriteria<BorrowingTransaction>
{
    public Patron Patron { get; set; }

    public PatronBorrowingHistorySearchCriteria(Patron patron)
    {
        Patron = patron;
    }

    public bool Matches(BorrowingTransaction transaction)
    {
        return transaction.Patron == Patron;
    }
}
