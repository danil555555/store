using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests
{
    internal class StubBookRepository : IBookRepository
    {
        public Book[] ResultOfGetAllByIsbn {  get; set; }

        public Book[] ResultOfGetAllByTitleOrAutor { get; set; }

        public Book[] GetAllByIsbn(string isbn)
        {
            return ResultOfGetAllByIsbn;
        }

        public Book[] GetAllByTitleOrAutor(string titleOrAutor)
        {
            return ResultOfGetAllByTitleOrAutor;
        }

        public Book GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
