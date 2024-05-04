using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class BooksController : Controller
    {
        [HttpGet]
        public JsonResult GetAllBooks()
        {
            return new JsonResult(new Book().GetAllBooks());
        }
        public IActionResult BookGetById(int BookId)
        {
            Book book = new Book().Book_GetById(BookId);
            if (book == null)
            {
                return Ok(new { status = 400, message = "Internal Server Error" });
            }
            else
            {
                return Ok(new { status = 200, Book = book });
            }
        }
        [HttpPost]
        public JsonResult CreateBook([FromBody] Book book)
        {
            return new JsonResult(new Book().SaveBook(book));
        }

        [HttpPut("{id}")]
        public JsonResult UpdateBook(int id, [FromBody] Book book)
        {
            return new JsonResult(new Book().UpdateBook(id, book));
        }

        [HttpDelete("{id}")]
        public JsonResult DeleteBook(int id)
        {
            return new JsonResult(new Book().DeleteBook(id));
        }

    }
}
