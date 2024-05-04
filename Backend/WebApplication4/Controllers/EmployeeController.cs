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
    public class EmployeeController : Controller
    {

        [HttpGet]
        public JsonResult Get([FromQuery] int Status)
        {
            return new JsonResult(new Employee().Employee_GetAll(Status));
        }
        [HttpGet]
        public IActionResult GetById([FromQuery] int Id)
        {
            DataTable dt = new Employee().Employee_GetAll(1);
            dt.DefaultView.RowFilter = $"EmployeeId = {Id}";
            Employee employee = new Employee()
            {
                EmployeeId = Convert.ToInt32(dt.DefaultView[0]["EmployeeId"]),
                EmployeeName = dt.DefaultView[0]["EmployeeName"].ToString(),
                Addres = dt.DefaultView[0]["Addres"].ToString(),
                Email = dt.DefaultView[0]["Email"].ToString(),
                CNIC = dt.DefaultView[0]["CNIC"].ToString(),
            };
            return Ok(new { status = 200, data = employee });
        }
       
        [HttpPost]
        public JsonResult Post([FromBody] Employee employee)
        {
            return new JsonResult(new Employee().Employee_Save(employee).ReturnMessage);
        }

        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] Employee employee)
        {
            employee.EmployeeId = id;
            return new JsonResult(new Employee().Employee_Update(employee).ReturnMessage);
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            return new JsonResult(new Employee().Employee_Delete(id).ReturnMessage);
        }
       

    }
}
