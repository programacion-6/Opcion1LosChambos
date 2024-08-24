using LosChambos.Entities;
using LosChambos.Managers;
using LosChambos.UInterface.CommandInterface;
using LosChambos.UInterface.Menu;

namespace LosChambos.UInterface.ConcreteCommands.Search;

public class SearchEntityByIdCommand<TEntity> : ICommand 
    where TEntity : IEntity
{
    private readonly string _searchForTitle;
    AManager<TEntity> _manager;

    public SearchEntityByIdCommand(string searchForTitle,
        AManager<TEntity> manager){
            _searchForTitle = searchForTitle;
            _manager = manager;
    }

    public void Execute()
    {
        SearchMenuUInterface<TEntity>.ShowSearchedItemById(_manager, _searchForTitle);
    }
}
