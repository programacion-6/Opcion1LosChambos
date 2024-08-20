using LosChambos.Entities.Concretes;
using LosChambos.ErrorHandling;
using LosChambos.ErrorHandling.Exceptions;
using LosChambos.Validators.Concretes;

namespace LosChambos.Managers;

public class FineManager : AManager<Fine>
{
    private readonly double FinePerDay = 0.50;
    private readonly double FineLimit = 30;

    public FineManager()
        : base(new FineValidator()) { }

    public FineManager(List<Fine> items)
        : base(items, new FineValidator()) { }

    public override bool Update(Fine fine)
    {
        try
        {
            if (Validator.Validate(fine))
            {
                var existingFine = Items.FirstOrDefault(f => f.Id == fine.Id);
                if (existingFine == null)
                    return false;

                existingFine.Amount = fine.Amount;
                existingFine.Patron = fine.Patron;
                existingFine.DueDate = fine.DueDate;
                existingFine.PaidDate = fine.PaidDate;
                return true;
            }
        }
        catch (ValidationException exception)
        {
            ErrorHandler.HandleError(exception);
        }
        return false;
    }

    public bool PayFine(Fine fine)
    {
        var existingFine = Items.FirstOrDefault(f => f.Id == fine.Id);
        if (existingFine == null)
        {
            return false;
        }

        existingFine.PaidDate = DateTime.Now;
        return true;
    }

    public Fine? CalculateFine(BorrowingTransaction transaction)
    {
        var overdueDays = (transaction.ReturnedDate ?? DateTime.Now)
            .Subtract(transaction.DueDate)
            .Days;
        if (overdueDays <= 0)
            return null;

        var fineAmount = overdueDays * FinePerDay;
        var fine = new Fine( transaction.Patron, fineAmount, DateTime.Now.AddDays(FineLimit));
        if (transaction.Fine != null)
            Add(fine);
        transaction.Fine = fine;
        return fine;
    }

    public double CalculateTotalFinesForPatron(Patron patron)
    {
        return Items
            .Where(f =>
                f.Patron.MembershipNumber == patron.MembershipNumber && !f.PaidDate.HasValue
            )
            .Sum(f => f.Amount);
    }
}
