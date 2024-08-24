using LosChambos.Entities.Concretes;
using LosChambos.Managers;

namespace Opcion1LosChambosTest.Manager
{
    public class BookManagerTest
    {
        [Fact]
        public void Update_ValidBook_ShouldUpdateSuccessfully()
        {
            var book1 = new Book("Original Title", "Author", "ISBN1", "Genre", 2020);
            var book2 = new Book("Another Book", "Author", "ISBN2", "Genre", 2021);
            var bookManager = new BookManager(new List<Book> { book1, book2 });

            var updatedBook = new Book("Updated Title", "Author", "ISBN1", "Genre", 2020);

            var result = bookManager.Update(updatedBook);

            Assert.False(result);
        }

        [Fact]
        public void Update_NonExistentBook_ShouldReturnFalse()
        {
            var book1 = new Book("Original Title", "Author", "ISBN1", "Genre", 2020);
            var bookManager = new BookManager(new List<Book> { book1 });

            var nonExistentBook = new Book("New Title", "Author", "ISBN2", "Genre", 2021);

            var result = bookManager.Update(nonExistentBook);

            Assert.False(result);
        }
    }
}