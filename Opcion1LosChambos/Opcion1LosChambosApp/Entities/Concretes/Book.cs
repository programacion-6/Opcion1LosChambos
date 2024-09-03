namespace LosChambos.Entities.Concretes;

public class Book : IEntity
{
    public Guid Id { get; }
    private string _title;
    private string _author;
    private string _isbn;
    private string _genre;
    private int _publicationYear;

    public Book(string title, string author, string isbn, string genre, int publicationYear)
    {
        Id = Guid.NewGuid();
        _title = title;
        _author = author;
        _isbn = isbn;
        _genre = genre;
        _publicationYear = publicationYear;
    }

    public string Title 
    { 
        get => _title; 
        set => _title = value;
    }

    public string Author 
    { 
        get => _author;
        set => _author = value;
    }

    public string ISBN 
    { 
        get => _isbn; 
        set => _isbn = value;
    }

    public string Genre 
    { 
        get => _genre; 
        set => _genre = value;
    }

    public int PublicationYear 
    { 
        get => _publicationYear; 
        set => _publicationYear = value;
    }

    public override string ToString()
    {
        return $"Book:\n"
            + $"Title: {Title}\n"
            + $"Author: {Author}\n"
            + $"ISBN: {ISBN}\n"
            + $"Genre: {Genre}\n"
            + $"PublicationYear: {PublicationYear}\n";
    }
}
