using LosChambos.Pagination;
using Moq;
using Spectre.Console;
using Xunit;

namespace Opcion1LosChambosTest.Manager
{
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

        [Fact]
        public void Constructor_ShouldThrowArgumentNullException_WhenItemsListIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Paginator<string>(null, 5));
        }

        [Fact]
        public void GetPageItems_ShouldReturnCorrectItemsForGivenPage()
        {
            var items = new List<string> { "item1", "item2", "item3" };
            var paginator = new Paginator<string>(items, 2);
            
            var pageItems = paginator.GetPageItems(2).ToList();

            Assert.Single(pageItems);
            Assert.Equal("item3", pageItems[0]);
        }

        [Fact]
        public void DisplayPaginatedList_ShouldExitWhenExitOptionSelected()
        {
            var items = new List<string> { "item1", "item2", "item3" };
            var paginator = new Paginator<string>(items, 1);

            _ansiConsoleMock.SetupSequence(console => console.Prompt(It.IsAny<SelectionPrompt<string>>()))
                .Returns("Exit"); // Simula que el usuario selecciona "Exit" inmediatamente

            paginator.DisplayPaginatedList();

            _ansiConsoleMock.Verify(console => console.Clear(), Times.Once);
            _ansiConsoleMock.Verify(console => console.Prompt(It.IsAny<SelectionPrompt<string>>()), Times.Once);
        }
    }
}
