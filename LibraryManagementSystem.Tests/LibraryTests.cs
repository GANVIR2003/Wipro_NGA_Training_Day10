using NUnit.Framework;
using LibraryManagementSystem;

namespace LibraryManagementSystem.Tests
{
    [TestFixture]
    public class LibraryTests
    {
        private Library _library;

        [SetUp]
        public void Setup()
        {
            _library = new Library();
        }

        [Test]
        public void AddBook_BookIsAddedSuccessfully()
        {
            var book = new Book("C# Basics", "Microsoft", "ISBN001");
            _library.AddBook(book);

            Assert.That(_library.Books.Count, Is.EqualTo(1));
        }

        [Test]
        public void RegisterBorrower_BorrowerIsRegistered()
        {
            var borrower = new Borrower("John", "CARD001");
            _library.RegisterBorrower(borrower);

            Assert.That(_library.Borrowers.Count, Is.EqualTo(1));
        }

        [Test]
        public void BorrowBook_BookIsMarkedAsBorrowed()
        {
            var book = new Book("C#", "Author", "ISBN002");
            var borrower = new Borrower("Alice", "CARD002");

            _library.AddBook(book);
            _library.RegisterBorrower(borrower);

            _library.BorrowBook("ISBN002", "CARD002");

            Assert.That(book.IsBorrowed, Is.True);
            Assert.That(borrower.BorrowedBooks.Count, Is.EqualTo(1));
        }

        [Test]
        public void ReturnBook_BookIsAvailableAgain()
        {
            var book = new Book("Java", "Author", "ISBN003");
            var borrower = new Borrower("Bob", "CARD003");

            _library.AddBook(book);
            _library.RegisterBorrower(borrower);
            _library.BorrowBook("ISBN003", "CARD003");

            _library.ReturnBook("ISBN003", "CARD003");

            Assert.That(book.IsBorrowed, Is.False);
            Assert.That(borrower.BorrowedBooks.Count, Is.EqualTo(0));
        }
    }
}
