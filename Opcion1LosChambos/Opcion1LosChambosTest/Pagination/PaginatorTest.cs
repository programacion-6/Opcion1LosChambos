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
        public void CalculateTotalPages_ShouldReturnCorrectPageCount()
        {
            var paginator = new Paginator<string>(new List<string> { "item1", "item2", "item3", "item4", "item5", "item6" }, 5);
            var totalPages = paginator.CalculateTotalPages(6);
            Assert.Equal(2, totalPages);
        }

        [Fact]
        public void HandleNavigationChoice_ShouldReturnCorrectPageNumber()
        {
            var paginator = new Paginator<string>(new List<string> { "item1", "item2", "item3" }, 1);

            int nextPage = paginator.HandleNavigationChoice("Next", 1, 3);
            Assert.Equal(2, nextPage);

            int previousPage = paginator.HandleNavigationChoice("Previous", 2, 3);
            Assert.Equal(1, previousPage);
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
    }
}
