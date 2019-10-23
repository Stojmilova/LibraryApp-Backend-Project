using DataAccess;
using DataModels;
using Models;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class BookService : IBookService
    {

        private readonly IRepository<BookDTO> _bookRepository;
        private readonly IRepository<UserDTO> _userRepository;

        public BookService(IRepository<BookDTO> bookRepository, IRepository<UserDTO> userRepository)
        {

            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public void AddBook(BookModel model)
        {
            var book = new BookDTO()
            {
                Author = model.Author,
                Title = model.Title,
                Context = model.Context,
                Genre =(int)model.Genre,
                NumbersOfCopies = model.NumbersOfCopies,
                Image=model.Image,
                UserId = model.UserId
            };
            _bookRepository.Add(book);
        }

        public void DeleteBook(int bookId)
        {
            var book = _bookRepository.GetAll().FirstOrDefault(b => b.Id == bookId);
            if (book == null)
                throw new Exception("Book not found");

            _bookRepository.Delete(book);
        }

        public IEnumerable<BookModel> GetAllBooks()
        {
            return _bookRepository.GetAll().Select(x =>
                new BookModel()
                {
                    Id = x.Id,
                    Author = x.Author,
                    Title = x.Title,
                    Context = x.Context,
                    Genre = (BookGenre)x.Genre,
                    NumbersOfCopies = x.NumbersOfCopies,
                    Image=x.Image,
                    UserId = x.UserId

                });
        }

        public BookModel GetBookById(int bookId)
        {
            var book = _bookRepository.GetAll().FirstOrDefault(b => b.Id == bookId);
            if(book == null)
                throw new Exception("Book not found");

            var bookModel = new BookModel()
            {
                Id = book.Id,
                Author = book.Author,
                Title = book.Title,
                Context = book.Context,
                Genre = (BookGenre)book.Genre,
                NumbersOfCopies = book.NumbersOfCopies,
                Image=book.Image,
                UserId = book.UserId

            };
            return bookModel;

        }
    }
}
