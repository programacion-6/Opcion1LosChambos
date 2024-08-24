using LosChambos.Entities;
using LosChambos.UInterface.CommandInterface;

namespace LosChambos.UInterface.ConcreteCommands.UserInterfaces;

public class HandleMenuCommand<T> : ICommand
    where T : IEntity
{
    private readonly BaseUInterface<T> _baseUInterface;

    public HandleMenuCommand(BaseUInterface<T> baseUInterface)
    {
        _baseUInterface = baseUInterface;
    }

    public void Execute()
    {
        _baseUInterface._menu.HandleMenu();
    }
}