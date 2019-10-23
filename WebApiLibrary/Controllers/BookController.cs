using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Serilog;
using Services;

namespace WebApiLibrary.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;          
        }

        //GET ALL BOOKS
        //localhost:60937/api/book
        [HttpGet]
        public ActionResult<IEnumerable<BookModel>> GetAllBooks()
        {
            try
            {
                //var userId = GetAuthorizedUserId();
                return Ok(_bookService.GetAllBooks());
            }           
            catch (Exception ex)
            {
                Log.Error("UNKNOWN Error: {message}", ex.Message);
                return BadRequest("Something went wrong. Please contact support!");
            }
        }

        //GET BOOK BY ID
        ////localhost:60937/api/book/id
        [HttpGet("{id}")]
        public ActionResult<BookModel> Get(int id)
        {
            try
            {
                //var userId = GetAuthorizedUserId();
                return Ok(_bookService.GetBookById(id));
            }            
            catch (Exception ex)
            {
                Log.Error("UNKNOWN Error: {message}", ex.Message);
                return BadRequest("Something went wrong. Please contact support!");
            }
        }

        //ADD BOOK
        //localhost:60937/api/book
        [HttpPost]
        public IActionResult Post([FromBody] BookModel model)
        {
            try
            {
                //model.UserId = GetAuthorizedUserId();
                _bookService.AddBook(model);
                return Ok("Successfully added book.");
            }           
            catch (Exception ex)
            {
                Log.Error("UNKNOWN Error: {message}", ex.Message);
                return BadRequest("Something went wrong. Please contact support!");
            }
        }

        //DELETE BOOK
        //localhost:60937/api/book/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int bookId)
        {
            try
            {
                //var userId = GetAuthorizedUserId();
                _bookService.DeleteBook(bookId);
                return Ok("Successfully deleted book");
            }          
            catch (Exception ex)
            {
                Log.Error("UNKNOWN Error: {message}", ex.Message);
                return BadRequest("Something went wrong. Please contact support!");
            }
        }
        //private int GetAuthorizedUserId()
        //{
        //    if (!int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?
        //        .Value, out var userId))
        //    {
        //        string name = User.FindFirst(ClaimTypes.Name)?.Value;
        //        throw new Exception("Name identifier claim does not exist!");
        //       // throw new Exception(userId, name,
        //           // "Name identifier claim does not exist!");
        //    }
        //    return userId;
        //}

    }
}