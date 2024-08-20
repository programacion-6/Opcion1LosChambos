namespace LosChambos.UInterface;

public class UserInterface
{
    public static string GetUserInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? string.Empty;
    }

    public static void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public static void DisplayListResult<T>(IEnumerable<T> results)
    {
        if (results.Any())
        {
            foreach (var item in results)
                ShowMessage(item?.ToString() ?? "Null item");
        }
        else
        {
            Console.WriteLine("No data found.");
        }
    }
}
