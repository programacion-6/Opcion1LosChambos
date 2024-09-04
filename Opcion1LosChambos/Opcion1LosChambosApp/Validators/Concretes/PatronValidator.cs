using LosChambos.Entities.Concretes;
using System.Linq;
using System.Net.Mail;

namespace LosChambos.Validators.Concretes;

public class PatronValidator : Validator<Patron>
{
   protected override void InitializeValidations()
    {
        Validations.Add("Name is required.",
            patron => !string.IsNullOrEmpty(patron.Name) && patron.Name.Any(char.IsLetter));

        Validations.Add("MembershipNumber is required.",
            patron => patron.MembershipNumber > 0);

        Validations.Add("Email is required.",
            patron => !string.IsNullOrEmpty(patron.ContactDetails) && IsValidEmail(patron.ContactDetails));
    }


    private static bool IsValidEmail(string email)
    {
        try
        {
            var mailAddress = new MailAddress(email);
            return mailAddress.Address == email;
        }
        catch
        {
            return false;
        }
    }

    public bool ValidateName(string name) => 
        !string.IsNullOrEmpty(name) && name.Any(char.IsLetter);

    public bool ValidateContactDetails(string contactDetails) => 
        !string.IsNullOrEmpty(contactDetails) && IsValidEmail(contactDetails);
}
