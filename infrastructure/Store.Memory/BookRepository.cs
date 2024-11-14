using System.Net.Http.Headers;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1,"ISBN 12312-31231","D. Knuth", "Art of Programming","fgfgfgf",7m),
            new Book(2, "ISBN 12312-31232", "M. Fowler", "Refactoing", "ewwer", 12.3m),
            new Book(3, "ISBN 12312-31232", "B. Kernighan. D.Ritchie", "C Programming Language", "ebvvb", 17.55m)
        };

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn)
                        .ToArray();
        }

        public Book[] GetAllByTitleOrAutor(string quere)
        {
            return books.Where(book => book.Author.Contains(quere)
                                    || book.Title.Contains(quere))
                        .ToArray();
        }

        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }
    }
}
