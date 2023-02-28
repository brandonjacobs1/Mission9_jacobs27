using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_jacobs27.Models
{
    public class EFBookstoreRepository : IBookstoreRepository
    {
        private BookstoreContext _context { get; set; }

        public EFBookstoreRepository(BookstoreContext context)
        {
            _context = context;
        }
        public IQueryable<Book> Books => _context.Books;
    }
}
