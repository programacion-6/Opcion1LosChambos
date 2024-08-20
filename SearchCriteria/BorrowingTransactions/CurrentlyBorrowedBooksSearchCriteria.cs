using LosChambos.Entities.Concretes;

namespace LosChambos.SearchCriteria.BorrowingTransactions;

public class CurrentlyBorrowedBooksSearchCriteria : ISearchCriteria<BorrowingTransaction>
{
    public Patron Patron { get; set; }

    public CurrentlyBorrowedBooksSearchCriteria(Patron patron)
    {
        Patron = patron;
    }

    public bool Matches(BorrowingTransaction transaction)
    {
        return transaction.Patron == Patron && !transaction.Returned;
    }
}
