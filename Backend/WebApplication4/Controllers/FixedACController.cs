using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class FixedACController : Controller
    {
        [HttpGet]
        public JsonResult GetAllFixedAC()
        {
            return new JsonResult(new Fixed().GetAllFixedAC());
        }
    }
}
