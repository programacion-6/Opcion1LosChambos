using LosChambos.Entities.Concretes;
using LosChambos.Validators.Concretes;

namespace LosChambos.Managers;

public class PatronManager : AManager<Patron>
{
    public PatronManager()
        : base(new PatronValidator()) { }

    public PatronManager(List<Patron> items)
        : base(items, new PatronValidator()) { }

    public override bool Update(Patron patron)
    {
        try
        {
            if (Validator.Validate(patron))
            {
                var existingPatron = Items.FirstOrDefault(p => p.Id == patron.Id);
                if (existingPatron == null)
                {
                    return false;
                }

                existingPatron.Name = patron.Name;
                existingPatron.ContactDetails = patron.ContactDetails;
                return true;
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            // TODO Handle exception
        }
        return false;
    }
}
