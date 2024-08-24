using LosChambos.Entities.Concretes;

namespace LosChambos.Validators.Concretes;

public class ReservationValidator : Validator<Reservation>
{
    protected override void InitializeValidations()
    {
        Validations.Add("Patron is required.", reservation => reservation.Patron != null);
        Validations.Add("Book is required.", reservation => reservation.Book != null);
        Validations.Add(
            "Expiry date must be set.",
            reservation => reservation.ExpiryDate != default
        );
        Validations.Add(
            "Reservation date must be set.",
            reservation => reservation.ReservationDate != default
        );
        Validations.Add(
            "Reservation date must be before or equal to expiry date.",
            reservation => reservation.ReservationDate <= reservation.ExpiryDate
        );
    }
}
