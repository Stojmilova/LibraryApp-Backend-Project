using DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class BookRepository : IRepository<BookDTO>
    {
        private readonly LibraryAppDbContext _context;
        public BookRepository(LibraryAppDbContext context)
        {
            _context = context;
        }
        public void Add(BookDTO entity)
        {
            _context.Books.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(BookDTO entity)
        {
            _context.Books.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<BookDTO> GetAll()
        {
            return _context.Books;
        }

        public void Update(BookDTO update)
        {
            _context.Books.Update(update);
            _context.SaveChanges();
        }
    }
}
