using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IBookService
    {
        IEnumerable<BookModel> GetAllBooks();
        BookModel GetBookById(int bookId);
        void AddBook(BookModel model);
        void DeleteBook(int bookId);
    }
}
