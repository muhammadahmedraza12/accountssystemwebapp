using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class AssignBookController : Controller
    {
        [HttpPost]
        public IActionResult AssignBook_Save([FromBody] AssignBook ab)
        {
            string message = ab.AssignBoook_Save();
            return Ok(new { status = "200",message = message });
        }
        public IActionResult Assign_GetAll()
        {
            List<AssignBook> assignBooks = new AssignBook().GetAllBooks();
            return Ok(new { status = "200", AssignBook = assignBooks });
        }
    }
}
