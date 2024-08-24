using Spectre.Console;

namespace LosChambos.Pagination;
public class Paginator<T>
{
    private readonly List<T> _items;
    private int _pageSize;

    public Paginator(List<T> items, int pageSize = 5)
    {
        _items = items;
        _pageSize = pageSize;
    }

    public void DisplayPaginatedList()
    {
        int totalItems = _items.Count;
        int totalPages = (int)Math.Ceiling(totalItems / (double)_pageSize);
        int currentPage = 1;

        while (true)
        {
            AnsiConsole.Clear();
            DisplayPage(currentPage, totalPages);

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Navigate:")
                    .AddChoices(new[] { "Next", "Previous", "Exit" })
            );

            switch (choice)
            {
                case "Next":
                    if (currentPage < totalPages)
                        currentPage++;
                    break;
                case "Previous":
                    if (currentPage > 1)
                        currentPage--;
                    break;
                case "Exit":
                    return;
            }
        }
    }

    private void DisplayPage(int currentPage, int totalPages)
    {
        AnsiConsole.MarkupLine($"[yellow]Page {currentPage}/{totalPages}[/]\n");

        var pageItems = _items
            .Skip((currentPage - 1) * _pageSize)
            .Take(_pageSize);

        foreach (var item in pageItems)
        {
            AnsiConsole.MarkupLine(item?.ToString() ?? "Null item");
        }
    }
}
