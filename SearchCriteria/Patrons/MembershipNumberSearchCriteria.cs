using LosChambos.Entities.Concretes;

namespace LosChambos.SearchCriteria.Patrons;

public class MembershipNumberSearchCriteria : ISearchCriteria<Patron>
{
    public int MembershipNumber { get; set; }

    public MembershipNumberSearchCriteria(int membershipNumber)
    {
        MembershipNumber = membershipNumber;
    }

    public bool Matches(Patron patron)
    {
        return patron.MembershipNumber == MembershipNumber;
    }
}
