using LosChambos.Entities.Concretes;

namespace Opcion1LosChambosTest.Entities.Concretes;

public class BookTest
{
    [Fact]
    public void Book_Creation_ValidParameters_ShouldSetProperties()
    {
        var book = new Book("Title", "Author", "ISBN123", "Genre", 2021);

        Assert.NotEqual(Guid.Empty, book.Id);
        Assert.Equal("Title", book.Title);
        Assert.Equal("Author", book.Author);
        Assert.Equal("ISBN123", book.ISBN);
        Assert.Equal("Genre", book.Genre);
        Assert.Equal(2021, book.PublicationYear);
    }

    [Fact]
    public void Book_ToString_ShouldReturnFormattedString()
    {
        var book = new Book("Title", "Author", "ISBN123", "Genre", 2021);
        var result = book.ToString();

        Assert.Contains("Book:", result);
        Assert.Contains("Title: Title", result);
        Assert.Contains("Author: Author", result);
    }
}
