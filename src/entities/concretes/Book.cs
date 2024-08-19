namespace Entities.Concretes;

public class Book : IEntity
{
    public Guid Id { get; }
    public string Title {get; set;}
    public string Author {get; set;}
    public string ISBN {get; set;}
    public string Genre {get; set;}
    public int PublicationYear {get; set;}

    public Book(string title, string author, string isbn, string genre, int publicationYear)
    {
        Id = Guid.NewGuid();
        Title = title;
        Author = author;
        ISBN = isbn;
        Genre = genre;
        PublicationYear = publicationYear;
    }
}
