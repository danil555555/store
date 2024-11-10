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
                .Returns(new[] { new Book(1, "", "", "") });

            bookRipositoryStub.Setup(x => x.GetAllByTitleOrAutor(It.IsAny<string>()))
                .Returns(new[] { new Book(2, "", "", "") });

            var bookService = new BookService(bookRipositoryStub.Object);

            var actual = bookService.GetAllByQuere("ISBN 12345-67890");

            Assert.Collection(actual, book => Assert.Equal(1, book.Id));

        }
    }
}
