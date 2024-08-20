using LosChambos.Entities;
using LosChambos.UInterface.Menu;

namespace LosChambos.UInterface;

public abstract class BaseUInterface<T>
    where T : IEntity
{
    protected readonly Library _library;
    protected readonly SearchMenuUInterface<T> _searchInterface;
    public readonly MainMenuUInterface _menu;
    protected readonly string _menuTitle;

    protected BaseUInterface(Library library, string menuTitle)
    {
        _library = library;
        _menuTitle = menuTitle;

        _searchInterface = CreateSearchInterface();
        _menu = CreateMainMenuInterface();
    }

    protected abstract SearchMenuUInterface<T> CreateSearchInterface();
    protected abstract MainMenuUInterface CreateMainMenuInterface();
}
