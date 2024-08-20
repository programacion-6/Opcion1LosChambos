namespace LosChambos.Entities.Concretes;

public class Patron : IEntity
{
    public Guid Id { get; }
    public string Name { get; set;}
    public int MembershipNumber { get; set;}
    public string ContactDetails { get; set;}

    public Patron(string name, int membershipNumber, string contactDetails)
    {
        Id = Guid.NewGuid();
        Name = name;
        MembershipNumber = membershipNumber;
        ContactDetails = contactDetails;
    }

    public void BorrowBook(Book book)
    {}

    public void ReturnBook(Book book)
    {}
}
