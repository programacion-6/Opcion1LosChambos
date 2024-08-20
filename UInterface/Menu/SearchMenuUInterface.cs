using LosChambos.Entities;
using LosChambos.Managers;
using LosChambos.SearchCriteria;

namespace LosChambos.UInterface.Menu;

public class SearchMenuUInterface<TEntity>
    where TEntity : IEntity
{
    public static void ShowSearchedData<TCriteria>(
        string inputPrompt,
        Func<string, TCriteria?> createCriteria,
        AManager<TEntity> manager
    )
        where TCriteria : ISearchCriteria<TEntity>
    {
        var input = UserInterface.GetUserInput(inputPrompt);
        TCriteria? criteria = createCriteria(input);

        if (criteria == null)
        {
            UserInterface.ShowMessage("Invalid criteria format.");
            return;
        }

        var results = manager.Search(criteria);
        UserInterface.DisplayListResult(results);
    }

    public static IEntity? ShowSearchedItemById(AManager<TEntity> manager, string titleInstruction)
    {
        var idInput = UserInterface.GetUserInput($"Enter {titleInstruction} ID: ");
        if (Guid.TryParse(idInput, out var id))
        {
            var item = manager.GetItemById(id);
            if (item != null)
            {
                UserInterface.ShowMessage(item.ToString() ?? "No item found");
                return item;
            }
            else
                UserInterface.ShowMessage("No item found");
        }
        else
        {
            UserInterface.ShowMessage("Invalid ID format.");
        }
        return null;
    }
}
