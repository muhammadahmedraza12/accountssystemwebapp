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
    public class StudentController : Controller
    {
        [HttpGet]
        public JsonResult Get([FromQuery] int Status)
        {
            return new JsonResult(new Student().Students_GetAll(Status));
        }
        [HttpGet]
        public IActionResult GetById([FromQuery]int Id)
        {
            DataTable dt = new Student().Students_GetAll(1);
            dt.DefaultView.RowFilter = $"StudentId = {Id}";
            Student student = new Student()
            {
                StudentId = Convert.ToInt32(dt.DefaultView[0]["StudentId"]),
                StudentName = dt.DefaultView[0]["StudentName"].ToString(),
                ContactNo = dt.DefaultView[0]["MobileNo"].ToString(),
                Email = dt.DefaultView[0]["Email"].ToString(),
            };
            return Ok(new { status = 200, data = student });
        }

        [HttpPost]
        public JsonResult Post([FromBody] Student student)
        {
            return new JsonResult(new Student().Student_Save(student).ReturnMessage);
        }

        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] Student student)
        {
            student.StudentId = id; 
            return new JsonResult(new Student().Student_Update(student).ReturnMessage);
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            return new JsonResult(new Student().Student_Delete(id).ReturnMessage);
        }
        public IActionResult GetBookAndStudent()
        {
            DataSet ds = new Student().GetStudentAndBook();
            List<Student> students = new List<Student>();
            List<Book> books = new List<Book>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                students.Add(new Student()
                {
                    StudentId = Convert.ToInt32(item["StudentId"]),
                    StudentName = item["StudentName"].ToString(),
                    ContactNo = item["MobileNo"].ToString(),
                    Email = item["Email"].ToString(),
                });
            }
            foreach (DataRow item in ds.Tables[1].Rows)
            {
                books.Add(new Book()
                {
                    Id = Convert.ToInt32(item["BookId"]),
                    Name = item["BookName"].ToString(),
                    Author = item["BookAuthor"].ToString(),
                });
            }
         
            return Ok(new { status = 200, booklist = books, studentlist = students });
        }

    }
}
 