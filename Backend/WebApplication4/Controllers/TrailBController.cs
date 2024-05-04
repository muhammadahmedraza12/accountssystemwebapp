using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class TrailBController : Controller
    {
        [HttpGet]
        public JsonResult GetAllTrailBalance()
        {
            return new JsonResult(new TrailBalance().GetAllTrailblnce());
        }
    }
}
