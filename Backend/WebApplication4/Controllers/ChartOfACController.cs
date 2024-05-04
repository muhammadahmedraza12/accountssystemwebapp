using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class ChartOfACController : Controller
    {
        [HttpGet]
        public JsonResult GetAllChartFACC()
        {
            return new JsonResult(new ChartFAccount().GetAllChartAccount());
        }
        [HttpPost]
        public JsonResult SaveChartFAc([FromBody] ChartFAccount Account)
        {
            return new JsonResult(new ChartFAccount().ChartfAccount_Save(Account).ReturnMessage);
        }
        [HttpPatch("{id}")]
        public JsonResult ChartACUpdate(int id, [FromBody] ChartFAccount account)
        {
            account.Accountid = id;
            return new JsonResult(new ChartFAccount().ChartAccount_Update(account).ReturnMessage);
        }
        [HttpDelete("{id}")]
        public JsonResult DeleteChartAc(int id)
        {
            return new JsonResult(new ChartFAccount().ChartAccount_Delete(id).ReturnMessage);
        }
        [HttpGet]
        public IActionResult ChartAccount_GetById(int Id)
        {
            ChartFAccount account = new ChartFAccount().ChartAccount_GetById(Id);
            if (account == null)
            {
                return Ok(new { status = 400, message = "Internal Server Error" });
            }
            else
            {
                return Ok(new { status = 200, ChartFAccount = account });
            }
        }
    }
}
