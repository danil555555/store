using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Store.Tests
{
    public class BookServiceTests
    {
        [Fact]
        public void GetAllByQuere_WithIsbn_CallsGetAllByIsbn()
        {
            var bookRipositoryStub = new Mock<IBookRepository>();
           bookRipositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
               .Returns(new[] { new Book(1, "", "", "","",0m) });

           bookRipositoryStub.Setup(x => x.GetAllByTitleOrAutor(It.IsAny<string>()))
              .Returns(new[] { new Book(2, "", "", "", "", 0m) });

        var bookService = new BookService(bookRipositoryStub.Object);

        var actual = bookService.GetAllByQuere("ISBN 12345-67890");

        Assert.Collection(actual, book => Assert.Equal(1, book.Id));

        }

        [Fact]
        public void GetAllByQuery_WithIsbn_CallsGetAllByIsbn()
        {
            const int idOfIsbnSearch = 1;
            const int idOfAuthorSearch = 2;

            var bookRepository = new StubBookRepository();

            bookRepository.ResultOfGetAllByIsbn = new[]
            {
                new Book(idOfIsbnSearch, "", "", "", "", 0m),
            };

            bookRepository.ResultOfGetAllByTitleOrAutor = new[]
            {
                new Book(idOfAuthorSearch, "", "", "", "", 0m),
            };

            var bookService = new BookService(bookRepository);

            var books = bookService.GetAllByQuere("ISBN 12345-67890");

            Assert.Collection(books, book => Assert.Equal(idOfIsbnSearch, book.Id));

        }

        [Fact]
        public void GetAllByQuery_WithTitle_CallsGetAllByTitleOrAutor()
        {
            const int idOfIsbnSearch = 1;
            const int idOfAuthorSearch = 2;

            var bookRepository = new StubBookRepository();

            bookRepository.ResultOfGetAllByIsbn = new[]
            {
                new Book(idOfIsbnSearch, "", "", "", "", 0m),
            };

            bookRepository.ResultOfGetAllByTitleOrAutor = new[]
            {
                new Book(idOfAuthorSearch, "", "", "", "", 0m),
            };

            var bookService = new BookService(bookRepository);
            var books = bookService.GetAllByQuere("Programming");

            Assert.Collection(books, book => Assert.Equal(idOfAuthorSearch, book.Id));
        }
    }
}
