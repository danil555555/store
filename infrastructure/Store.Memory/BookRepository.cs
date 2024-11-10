﻿using System.Net.Http.Headers;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1,"ISBN 12312-31231","D. Knuth", "Art of Programming"),
            new Book(2, "ISBN 12312-31232", "M. Fowler", "Refactoing"),
            new Book(3, "ISBN 12312-31232", "B. Kernighan. D.Ritchie", "C Programming Language")
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
    }
}
