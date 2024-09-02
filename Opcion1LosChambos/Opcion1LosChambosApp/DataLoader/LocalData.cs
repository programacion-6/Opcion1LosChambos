using LosChambos.Entities.Concretes;

namespace LosChambos.DataLoader;
using System.Collections.Generic;
using LosChambos.Entities;

public class LocalData
{
    private static List<Book> _books;
    private static List<Patron> _patrons;
    private static IStorage<Patron> _storagePatron;
    private static IStorage<Book> _storageBook;

    public LocalData(IStorage<Patron> patronStorage, IStorage<Book> bookStorage, Library library)
    {
        _books = new();
        _patrons = new();
        _storagePatron = patronStorage;
        _storageBook = bookStorage;
        LoadData(library);
    }

    private void LoadPatronsFromJson()
    {
        var patronsFromJson = _storagePatron.Load();
        if (patronsFromJson != null)
        {
            _patrons.AddRange(patronsFromJson);
        }
    }

    private void LoadBooksFromJson()
    {
        var booksFromJson = _storageBook.Load();
        if (booksFromJson != null)
        {
            _books.AddRange(booksFromJson);
        }
    }

    public void LoadBooks(Library library)
    {
        foreach (var book in _books)
        {
            library.BookManager.Add(book);
        }
    }

    public void LoadPatrons(Library library)
    {
        foreach (var patron in _patrons)
        {
            library.PatronManager.Add(patron);
        }
    }

    public static void SavePatronsToJson(List<Patron> patrons)
    {
        _storagePatron.Save(patrons);
    }

    public static void SaveBooksToJson(List<Book> books)
    {
        _storageBook.Save(books);
    }

    public void LoadData(Library library)
    {
        LoadDataJson();
        LoadBooks(library);
        LoadPatrons(library);
    }

    public void LoadDataJson()
    {
        LoadPatronsFromJson();
        LoadBooksFromJson();
    }


}