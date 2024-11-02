using System.Net.Http.Headers;
using.System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "Art of Programming"),
            new Book(2, "Refactoing"),
            new Book(3, "C Programming Language")
        };
        public Book[] GetAllByTitle(string titlePart)
        {
            return books.Where(book => book.Title.Contains(titlePart))
                .ToArray();

        }
    }
}
