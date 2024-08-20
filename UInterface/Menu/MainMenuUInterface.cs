using LosChambos.UInterface.CommandInterface;

namespace LosChambos.UInterface.Menu;

public class MainMenuUInterface : MenuUInterface
{
    public MainMenuUInterface(
        Dictionary<string, ICommand> menuCommands,
        List<string> menuLabels,
        string menuForTitle
    )
        : base(menuCommands, menuLabels, $"{menuForTitle} menu: ") { }
}