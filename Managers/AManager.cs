using LosChambos.Entities;

namespace LosChambos.Managers;

public abstract class AManager<T>
    where T : IEntity
{
    public List<T> Items { get; set; }
    protected Validator<T> Validator;

    public AManager(Validator<T> validator)
    {
        Items = [];
        Validator = validator;
    }

    public AManager(List<T> items, Validator<T> validator)
    {
        Items = items;
        Validator = validator;
    }

    public bool Add(T item)
    {
        try
        {
            if (Validator.Validate(item))
            {
                Items.Add(item);
                return true;
            }
        }
        catch (ValidationException exception)
        {
            ErrorHandler.HandleError(exception);
        }
        return false;
    }

    public bool Remove(T item)
    {
        return Items.Remove(item);
    }

    public List<T> Search(ISearchCriteria<T> criteria)
    {
        return Items.Where(criteria.Matches).ToList();
    }

    public T? GetItemById(Guid id)
    {
        return Items.FirstOrDefault(p => p.Id == id);
    }

    public abstract bool Update(T item);
}