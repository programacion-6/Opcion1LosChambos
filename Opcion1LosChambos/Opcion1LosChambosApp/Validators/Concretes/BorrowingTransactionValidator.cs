using LosChambos.Entities.Concretes;

namespace LosChambos.Validators.Concretes;

public class BorrowingTransactionValidator : Validator<BorrowingTransaction>
{
    protected override void InitializeValidations()
    {
        Validations.Add("Book is required.", transaction => transaction.Book != null);
        Validations.Add("Patron is required.", transaction => transaction.Patron != null);
        Validations.Add(
            "Borrowed date must be set.",
            transaction => transaction.BorrowedDate != default
        );
        Validations.Add(
            "Due date must be set.",
            transaction => transaction.DueDate != default
        );
        Validations.Add(
            "Borrowed date must be before or equal to due date.",
            transaction => transaction.BorrowedDate <= transaction.DueDate
        );
        Validations.Add(
            "If returned, returned date must be after or equal to borrowed date.",
            transaction =>
                !transaction.Returned
                || (
                    transaction.ReturnedDate.HasValue
                    && transaction.ReturnedDate >= transaction.BorrowedDate
                )
        );
    }
}
