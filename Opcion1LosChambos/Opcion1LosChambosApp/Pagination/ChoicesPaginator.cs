using Spectre.Console;

namespace LosChambos.Pagination;

public class ChoicesPaginator 
{
        public static int CalculateTotalPages(int itemCount, int pageSize)
    {
        return (int)Math.Ceiling(itemCount / (double)pageSize);
    }

    public static List<T> GetPageItems<T>(List<T> items, int currentPage, int pageSize)
    {
        return items.Skip(currentPage * pageSize).Take(pageSize).ToList();
    }

    public static List<string> BuildOptionsList<T>(List<T> pageItems, int currentPage, int totalPages)
    {
        var options = pageItems.Select(item => item!.ToString()!).ToList();
        if (currentPage < totalPages - 1) options.Add("Next");
        if (currentPage > 0) options.Add("Previous");
        options.Add("Exit");
        return options;
    }

    public static bool HandleSpecialChoices(string selectedChoice, ref int currentPage, int totalPages)
    {
        switch(selectedChoice)
        {
            case "Next" :
                    currentPage ++;
                    return true;
            case "Previous" :
                    currentPage --;
                    return true;
            case "Exit" :
                    return false;
            default :
                    return false;
        }
    }

    public static T? GetSelectedItem<T>(List<T> items, string selectedChoice)
        where T : notnull
    {
        return items.FirstOrDefault(item => item!.ToString() == selectedChoice);
    }
}