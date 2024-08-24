namespace LosChambos.ErrorHandling;

using Spectre.Console;

public class ErrorHandler
{
    public static void HandleError(Exception error)
    {
        AnsiConsole.MarkupLine($"[bold underline red]Error: {error.Message}[/]");
        AnsiConsole.MarkupLine($"[red]Stack Trace: {error.StackTrace}[/]");
    }
}
