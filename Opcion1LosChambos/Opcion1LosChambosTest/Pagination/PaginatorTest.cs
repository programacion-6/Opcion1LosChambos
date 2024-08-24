using LosChambos.Pagination;
using Moq;
using Spectre.Console;

namespace Opcion1LosChambosTest.Manager;
public class PaginatorTests
{
    private readonly Mock<IAnsiConsole> _ansiConsoleMock;

    public PaginatorTests()
    {
        _ansiConsoleMock = new Mock<IAnsiConsole>();
    }

    [Fact]
    public void Constructor_ShouldThrowArgumentOutOfRangeException_WhenPageSizeIsLessThanOrEqualToZero()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Paginator<string>(new List<string>(), 0));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Paginator<string>(new List<string>(), -1));
    }
}
