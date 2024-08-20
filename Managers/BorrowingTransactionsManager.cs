using LosChambos.Entities.Concretes;
using LosChambos.Validators.Concretes;

namespace LosChambos.Managers;

public class BorrowingTransactionsManager : AManager<BorrowingTransaction>
{
    public BorrowingTransactionsManager()
        : base(new BorrowingTransactionValidator()) { }

    public BorrowingTransactionsManager(List<BorrowingTransaction> items)
        : base(items, new BorrowingTransactionValidator()) { }

    public override bool Update(BorrowingTransaction transaction)
    {
        try
        {
            if (Validator.Validate(transaction))
            {
                var existingTransaction = Items.FirstOrDefault(t => t.Id == transaction.Id);
                if (existingTransaction == null)
                    return false;

                existingTransaction.BorrowedDate = transaction.BorrowedDate;
                existingTransaction.DueDate = transaction.DueDate;
                existingTransaction.ReturnedDate = transaction.ReturnedDate;
                existingTransaction.Fine = transaction.Fine;
                existingTransaction.Returned = transaction.Returned;
                return true;
            }
        }
        catch (Exception exception)
        {
            // TODO: Handle exception
            Console.WriteLine(exception);
        }
        return false;
    }
}
