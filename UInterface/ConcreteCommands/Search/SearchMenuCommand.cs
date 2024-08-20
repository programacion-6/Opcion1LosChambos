using LosChambos.UInterface.CommandInterface;
using LosChambos.UInterface.Menu;

namespace LosChambos.UInterface.ConcreteCommands.Search;

public class SearchMenuCommand : ICommand
{
    private readonly MenuUInterface _menuInterface;

    public SearchMenuCommand(MenuUInterface menuInterface)
    {
        _menuInterface = menuInterface;
    }

    public void Execute()
    {
        _menuInterface.HandleMenu();
    }
}