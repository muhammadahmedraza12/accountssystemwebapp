using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using WebApplication4.Models;
using System.Security.Cryptography;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class ReceiptMasterController : Controller
    {

        [HttpGet]
        public JsonResult GetAllreciepmaster([FromQuery] int Status)
        {
            return new JsonResult(new ReceiptMaster().ReceiptMaster_GetAll());
        }
        [HttpGet]
        public IActionResult GetByIdrecieptmaster([FromQuery] int RId)
        {
            DataTable dt = new ReceiptMaster().ReceiptMaster_GetAll();
            dt.DefaultView.RowFilter = $"RId = {RId}";
            ReceiptMaster ReceiptMc = new ReceiptMaster()
            {

                RId = Convert.ToInt32(dt.Rows[0]["RId"]),
                InvoiceNo = dt.Rows[0]["InvoiceNo"].ToString(),
                Date = dt.Rows[0]["Date"].ToString(),
                Amount = Convert.ToDecimal(dt.Rows[0]["Amount"]),
                Description = dt.Rows[0]["Description"].ToString(),
            };
            return Ok(new { status = 200, data = ReceiptMc });
        }

        [HttpPost]
        public JsonResult Insert([FromBody] ReceiptMaster ReceiptMc)
        {
            return new JsonResult(new ReceiptMaster().ReceiptMaster_Save(ReceiptMc).ReturnMessage);
        }

      

        [HttpPatch("{RId}")]
        public JsonResult Put(int RId, [FromBody] ReceiptMaster ReceiptMc)
        {
            ReceiptMc.RId = RId;
            return new JsonResult(new ReceiptMaster().ReceiptMaster_Update(ReceiptMc).ReturnMessage);
        }
       

        [HttpDelete("{RId}")]
        public JsonResult Delete(int RId)
        {
            return new JsonResult(new ReceiptMaster().ReceiptMaster_Delete(RId).ReturnMessage);
        }


    }
}
