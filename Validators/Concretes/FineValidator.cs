using LosChambos.Entities.Concretes;

namespace LosChambos.Validators.Concretes;

public class FineValidator : Validator<Fine>
{
    protected override void InitializeValidations()
    {
        Validations.Add("Patron is required.", fine => fine.Patron != null);
        Validations.Add("Amount must be greater than 0.", fine => fine.Amount > 0);
        Validations.Add(
            "Paid date must be set if fine is paid.",
            fine => !fine.Paid || fine.PaidDate != null
        );
        Validations.Add(
            "Paid date cannot be before due date.",
            fine => !fine.Paid || fine.PaidDate >= fine.DueDate
        );
    }
}
