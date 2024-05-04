using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class MasterACController : Controller
    {
        [HttpGet]
        public JsonResult GetAllMasterAC()
        {
            return new JsonResult(new MasterAccount().GetAllMasterAccount());
        }
       
        [HttpGet]
        public IActionResult MasterAccount_GetById(int Id)
        {
            MasterAccount account = new MasterAccount().MasterAccount_GetById(Id);
            if (account == null)
            {
                return Ok(new { status = 400, message = "Internal Server Error" });
            }
            else
            {
                return Ok(new { status = 200, MasterAccount = account });
            }
        }
        [HttpPost]
        public JsonResult SaveMasterAc([FromBody] MasterAccount master)
        {
            return new JsonResult(new MasterAccount().MasterAccount_Save(master).ReturnMessage);
        }

        [HttpPatch("{id}")]
        public JsonResult MasterACUpdate(int id, [FromBody] MasterAccount master)
        {
            master.id = id;
            return new JsonResult(new MasterAccount().MasterAccount_Update(master).ReturnMessage);
        }
        [HttpDelete("{id}")]
        public JsonResult DeleteMasterAc(int id)
        {
            return new JsonResult(new MasterAccount().MasterAccount_Delete(id).ReturnMessage);
        }
    }
}
