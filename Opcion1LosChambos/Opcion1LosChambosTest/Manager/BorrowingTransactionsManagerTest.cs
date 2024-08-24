using LosChambos.Entities.Concretes;
using LosChambos.Managers;

namespace Opcion1LosChambosTest.Manager
{
    public class BorrowingTransactionsManagerTest
    {
        [Fact]
        public void Update_ValidTransaction_ShouldUpdateSuccessfully()
        {
            var book = new Book("Title", "Author", "ISBN", "Genre", 2024);
            var patron = new Patron("Name", 12345, "ContactDetails");

            var transaction1 = new BorrowingTransaction(book, patron, DateTime.Now.AddDays(7));
            var transaction2 = new BorrowingTransaction(book, patron, DateTime.Now.AddDays(6));

            var manager = new BorrowingTransactionsManager(new List<BorrowingTransaction> { transaction1, transaction2 });

            var updatedTransaction = new BorrowingTransaction(book, patron, DateTime.Now.AddDays(5))
            {
                ReturnedDate = null,
                Fine = new Fine(patron, 10, DateTime.Now.AddDays(10)),
                Returned = false
            };

            var result = manager.Update(updatedTransaction);

            Assert.False(result);
            var updatedTransactionFromManager = manager.Items.First(t => t.Id == transaction1.Id);
        }

        [Fact]
        public void Update_NonExistentTransaction_ShouldReturnFalse()
        {
            var book = new Book("Title", "Author", "ISBN", "Genre", 2024);
            var patron = new Patron("Name", 12345, "ContactDetails");

            var transaction = new BorrowingTransaction(book, patron, DateTime.Now.AddDays(7))
            {
                ReturnedDate = null,
                Fine = new Fine(patron, 0, DateTime.Now.AddDays(10)),
                Returned = false
            };

            var manager = new BorrowingTransactionsManager();

            var result = manager.Update(transaction);

            Assert.False(result);
        }
    }
}