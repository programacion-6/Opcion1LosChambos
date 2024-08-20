namespace LosChambos.SearchCriteria;

public interface ISearchCriteria<T>
{
    bool Matches(T item);
}
