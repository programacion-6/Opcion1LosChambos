using Spectre.Console;

namespace LosChambos.Pagination;
public class Paginator<T>
{
    private readonly List<T> _items;
    private readonly int _pageSize;

    public Paginator(List<T> items, int pageSize = 5)
    {
        _items = items ?? throw new ArgumentNullException(nameof(items));
        _pageSize = pageSize > 0 ? pageSize : throw new ArgumentOutOfRangeException(nameof(pageSize));
    }

    public void DisplayPaginatedList()
    {
        var (totalItems, totalPages, currentPage) = InitializePagination();

        if (totalItems == 0)
        {
            AnsiConsole.MarkupLine("[yellow]No items to display.[/]");
            return;
        }

        NavigatePages(totalPages, ref currentPage);
    }

    private (int totalItems, int totalPages, int currentPage) InitializePagination()
    {
        int totalItems = _items.Count;
        int totalPages = CalculateTotalPages(totalItems);
        int currentPage = 1;

        return (totalItems, totalPages, currentPage);
    }

    private void NavigatePages(int totalPages, ref int currentPage)
    {
        while (true)
        {
            AnsiConsole.Clear();
            DisplayCurrentPage(currentPage, totalPages);

            var choice = GetNavigationChoice();
            currentPage = HandleNavigationChoice(choice, currentPage, totalPages);

            if (choice == "Exit")
                break;
        }
    }

    private void DisplayCurrentPage(int currentPage, int totalPages)
    {
        DisplayPage(currentPage, totalPages);
    }

    public void DisplayPage(int currentPage, int totalPages)
    {
        ValidateCurrentPage(currentPage, totalPages);
        DisplayPageHeader(currentPage, totalPages);
        DisplayPageItems(currentPage);
        DisplayPageFooter(currentPage);
    }

    private void ValidateCurrentPage(int currentPage, int totalPages)
    {
        if (currentPage < 1 || currentPage > totalPages)
        {
            throw new ArgumentOutOfRangeException(nameof(currentPage), "Current page is out of range.");
        }
    }

    private void DisplayPageHeader(int currentPage, int totalPages)
    {
        AnsiConsole.MarkupLine($"[bold blue]Page {currentPage}/{totalPages}[/]");
    }

    private void DisplayPageItems(int currentPage)
    {
        var pageItems = GetPageItems(currentPage);
        foreach (var item in pageItems)
        {
            DisplayItem(item);
        }
    }

    private void DisplayPageFooter(int currentPage)
    {
        DisplayPageSummary(currentPage);
    }

    public int CalculateTotalPages(int totalItems)
    {
        return (int)Math.Ceiling(totalItems / (double)_pageSize);
    }

    public IEnumerable<T> GetPageItems(int currentPage)
    {
        return _items.Skip((currentPage - 1) * _pageSize).Take(_pageSize);
    }

    private void DisplayItem(T item)
    {
        AnsiConsole.MarkupLine($"[cyan]{item?.ToString() ?? "[red]Null item[/]"}[/]");
        AnsiConsole.MarkupLine("[grey]----[/]");
    }

    private void DisplayPageSummary(int currentPage)
    {
        int startItemIndex = ((currentPage - 1) * _pageSize) + 1;
        int endItemIndex = Math.Min(currentPage * _pageSize, _items.Count);
        AnsiConsole.MarkupLine($"[grey]Showing items {startItemIndex}-{endItemIndex} of {_items.Count}[/]");
    }

    private string GetNavigationChoice()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[green]Navigate[/]:")
                .HighlightStyle("yellow")
                .AddChoices(new[] { "Next", "Previous", "Exit" })
        );
    }

    public int HandleNavigationChoice(string choice, int currentPage, int totalPages)
    {
        switch (choice)
        {
            case "Next":
                return (currentPage < totalPages) ? currentPage + 1 : currentPage;
            case "Previous":
                return (currentPage > 1) ? currentPage - 1 : currentPage;
            case "Exit":
            default:
                return currentPage;
        }
    }
}
