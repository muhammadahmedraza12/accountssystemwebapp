using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class JournalController : Controller
    {
        [HttpGet]
        public JsonResult GetAllJournl()
        {
            return new JsonResult(new Journal().GetAllJournal());
        }
        [HttpPost]
        public JsonResult SaveJournal([FromBody] Journal Account)
        {
            return new JsonResult(new Journal().Jounal_Save(Account).ReturnMessage);
        }
        [HttpPatch("{id}")]
        public JsonResult JournalUpdate(int id, [FromBody] Journal jl)
        {
            jl.id = id;
            return new JsonResult(new Journal().Journal_Update(jl).ReturnMessage);
        }
        [HttpDelete("{id}")]
        public JsonResult DeleteJournalAC(int id, int RefNo)
        {
            return new JsonResult(new Journal().JournalAC_Delete(id,RefNo).ReturnMessage);
        }
        [HttpGet]
        public IActionResult JournalAC_GetById(int Id)
        {
            Journal account = new Journal().JournalAC_GetById(Id);
            if (account == null)
            {
                return Ok(new { status = 400, message = "Internal Server Error" });
            }
            else
            {
                return Ok(new { status = 200, Journal = account });
            }
        }
    }
}
