namespace LosChambos.Entities.Concretes;

public class Patron : IEntity
{
    public Guid Id { get; }

    private string _name;
    private int _membershipNumber;
    private string _contactDetails;

    public Patron(string name, int membershipNumber, string contactDetails)
    {
        Id = Guid.NewGuid();
        _name = name;
        _membershipNumber = membershipNumber;
        _contactDetails = contactDetails;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public int MembershipNumber
    {
        get => _membershipNumber;
        set => _membershipNumber = value;
    }

    public string ContactDetails
    {
        get => _contactDetails;
        set => _contactDetails = value;
    }

    public void BorrowBook(Book book)
    {
    }

    public void ReturnBook(Book book)
    {
    }

    public override string ToString()
    {
        return $"Patron:\n"
            + $"Name: {Name}\n"
            + $"MembershipNumber: {MembershipNumber}\n"
            + $"ContactDetails: {ContactDetails}";
    }
}
