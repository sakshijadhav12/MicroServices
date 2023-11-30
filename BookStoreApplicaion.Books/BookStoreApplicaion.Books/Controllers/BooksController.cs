using BookStoreApplicaion.Books.Entity;
using BookStoreApplicaion.Books.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace BookStoreApplicaion.Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooks bookService;

        public BooksController(IBooks bookService)
        {
            this.bookService = bookService;
        }

        [HttpPost]
        [Route("addBook")]
        public IActionResult AddBook([FromBody] BookModel book)
        {
            try
            {
                var result = bookService.addBook(book);

                if (result != null)
                {
                    return Ok(new { Status = true, Message = "Book added successfully", Data = result });
                }
                else
                {
                    return BadRequest(new { Status = false, Message = "Failed to add the book" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Status = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("viewBook")]
        public IActionResult ViewBook(string bookName)
        {
            try
            {
                var result = bookService.viewBook(bookName);

                if (result != null )
                {
                    return Ok(new { Status = true, Message = "Books found", Data = result });
                }
                else
                {
                    return NotFound(new { Status = false, Message = "No books found with the given name" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Status = false, Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("viewBookById")]
        public IActionResult ViewBookbyid(int BookId)
        {
            try
            {
                var result = bookService.viewBookbyid( BookId);
            

                if (result != null)
                {
                    return Ok(new { Status = true, Message = "Book found", Data = result });
                }
                else
                {
                    return NotFound(new { Status = false, Message = "No book found with the given name" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("updateBook")]
        public IActionResult UpdateBook([FromBody] BookModel book, string bookName)
        {
            try
            {
                var result = bookService.updateBook(book, bookName);

                if (result != null)
                {
                    return Ok(new { Status = true, Message = "Book updated successfully", Data = result });
                }
                else
                {
                    return NotFound(new { Status = false, Message = "Book not found or update unsuccessful" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Status = false, Message = ex.Message });
            }
        }
    }
}
    

