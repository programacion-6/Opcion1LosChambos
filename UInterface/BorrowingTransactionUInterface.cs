using LosChambos.Entities;
using LosChambos.Entities.Concretes;

namespace LosChambos.UInterface;

public class BorrowingTransactionUInterface
{
    public static Patron? GetPatronFromUser(Library _library, string patronId)
    {
        var guid = Guid.TryParse(patronId, out var resultPatronId);
        var patron = _library.PatronManager.GetItemById(resultPatronId);

        if (patron == null)
        {
            UserInterface.ShowMessage("Patron not Found");
            return null;
        }
        return patron;
    }
}
