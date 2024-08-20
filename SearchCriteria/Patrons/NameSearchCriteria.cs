using LosChambos.Entities.Concretes;

namespace LosChambos.SearchCriteria.Patrons;

public class NameSearchCriteria : ISearchCriteria<Patron>
{
    public string Name { get; set; }

    public NameSearchCriteria(string name)
    {
        Name = name;
    }

    public bool Matches(Patron patron)
    {
        return patron.Name.Contains(Name, StringComparison.OrdinalIgnoreCase);
    }
}
