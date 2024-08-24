using LosChambos.Entities;
using LosChambos.Entities.Concretes;

namespace LosChambos.DataLoader;

public class LocalData
{
    public static List<Book> Books = new List<Book>
    {
        new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565", "Fiction", 1925),
        new Book("1984", "George Orwell", "9780451524935", "Dystopian", 1949),
        new Book("To Kill a Mockingbird", "Harper Lee", "9780060935467", "Fiction", 1960),
        new Book("Pride and Prejudice", "Jane Austen", "9780141439518", "Romance", 1813),
        new Book("The Catcher in the Rye", "J.D. Salinger", "9780316769488", "Fiction", 1951),
        new Book("Moby-Dick", "Herman Melville", "9781503280786", "Adventure", 1851),
        new Book("War and Peace", "Leo Tolstoy", "9781400079988", "Historical", 1869),
        new Book("The Odyssey", "Homer", "9780140268867", "Epic", 800),
        new Book("Ulysses", "James Joyce", "9780199535675", "Modernist", 1922),
        new Book("Crime and Punishment", "Fyodor Dostoevsky", "9780140449136", "Psychological Fiction", 1866),
        new Book("The Brothers Karamazov", "Fyodor Dostoevsky", "9780374528379", "Philosophical Fiction", 1880),
        new Book("Brave New World", "Aldous Huxley", "9780060850524", "Dystopian", 1932),
        new Book("The Lord of the Rings", "J.R.R. Tolkien", "9780544003415", "Fantasy", 1954),
        new Book("Don Quixote", "Miguel de Cervantes", "9780060934347", "Satire", 1605),
        new Book("The Divine Comedy", "Dante Alighieri", "9780142437223", "Epic Poetry", 1320),
        new Book("Hamlet", "William Shakespeare", "9780140714548", "Tragedy", 1603),
        new Book("Anna Karenina", "Leo Tolstoy", "9780143035008", "Romance", 1877),
        new Book("The Iliad", "Homer", "9780140275360", "Epic", 750),
        new Book("One Hundred Years of Solitude", "Gabriel Garcia Marquez", "9780060883287", "Magic Realism", 1967),
        new Book("The Sound and the Fury", "William Faulkner", "9780679732242", "Southern Gothic", 1929),
    };

    public static List<Patron> Patrons = new List<Patron>
    {
        new Patron("John Doe", 1001, "john.doe@example.com"),
        new Patron("Jane Smith", 1002, "jane.smith@example.com"),
        new Patron("Alice Johnson", 1003, "alice.johnson@example.com"),
        new Patron("Bob Brown", 1004, "bob.brown@example.com"),
        new Patron("Charlie Davis", 1005, "charlie.davis@example.com"),
        new Patron("Diana Evans", 1006, "diana.evans@example.com"),
        new Patron("Edward Frank", 1007, "edward.frank@example.com"),
        new Patron("Fiona Green", 1008, "fiona.green@example.com"),
        new Patron("George Hill", 1009, "george.hill@example.com"),
        new Patron("Hannah Lee", 1010, "hannah.lee@example.com"),
        new Patron("Ivan Miller", 1011, "ivan.miller@example.com"),
        new Patron("Julia Nelson", 1012, "julia.nelson@example.com"),
        new Patron("Kevin Olson", 1013, "kevin.olson@example.com"),
        new Patron("Laura Peterson", 1014, "laura.peterson@example.com"),
        new Patron("Michael Quinn", 1015, "michael.quinn@example.com"),
        new Patron("Nina Roberts", 1016, "nina.roberts@example.com"),
        new Patron("Oscar Scott", 1017, "oscar.scott@example.com"),
        new Patron("Paul Turner", 1018, "paul.turner@example.com"),
        new Patron("Quinn Underwood", 1019, "quinn.underwood@example.com"),
        new Patron("Rachel White", 1020, "rachel.white@example.com"),
    };

    public static void LoadBooks(Library library)
    {
        foreach (var book in Books)
        {
            library.BookManager.Add(book);
        }
    }

    public static void LoadPatrons(Library library)
    {
        foreach (var patron in Patrons)
        {
            library.PatronManager.Add(patron);
        }
    }

    public static void LoadBorrowingTransactions(Library library)
    {
        var random = new Random();
        
        for (int i = 0; i < 40; i++)
        {
            var book = Books[random.Next(Books.Count)];
            var patron = Patrons[random.Next(Patrons.Count)];
            var dueDate = DateTime.Now.AddDays(random.Next(7, 30));
            
            var transaction = new BorrowingTransaction(book, patron, dueDate);

            if (!library.BorrowingTransactionsManager.Items.Any(t => t.Book.Id == book.Id && !t.Returned))
            {
                library.BorrowingTransactionsManager.Add(transaction);
            }
        }
    }

    public static void LoadData(Library library)
    {
        LoadBooks(library);
        LoadPatrons(library);
        LoadBorrowingTransactions(library);
    }
}
