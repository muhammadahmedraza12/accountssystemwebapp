using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using Dapper;

namespace WebApplication4.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public string ReturnMessage { get; set; }

        public DataTable Students_GetAll(int Status)
        {
            SqlCommand sc = new SqlCommand("GetAllStudents", ConnectionString.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataReader sdr = sc.ExecuteReader();
            dt.Load(sdr);
            sdr.Close();
            return dt;
        }

        public Student Student_Save(Student student)
        {
            SqlCommand sc = new SqlCommand("SaveStudent", ConnectionString.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@ParamTable1", student.StudentName);
            sc.Parameters.AddWithValue("@ParamTable3", student.ContactNo);
            sc.Parameters.AddWithValue("@ParamTable2", student.Email);
            if (sc.ExecuteNonQuery() > 0)
            {
                student.ReturnMessage = "OK";
            }
            return student;
        }
        public Student Student_Update(Student student)
        {
            SqlCommand sc = new SqlCommand("UpdateStudent", ConnectionString.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@ParamTable1", student.StudentId);
            sc.Parameters.AddWithValue("@ParamTable2", student.StudentName);
            sc.Parameters.AddWithValue("@ParamTable4", student.ContactNo);
            sc.Parameters.AddWithValue("@ParamTable3", student.Email);

            if (sc.ExecuteNonQuery() > 0)
            {
                student.ReturnMessage = "OK";
            }
            return student;
        }

        public Student Student_Delete(int id)
        {
            SqlCommand sc = new SqlCommand("DeleteStudent", ConnectionString.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@ParamTable1", id);

            if (sc.ExecuteNonQuery() > 0)
            {
                return new Student { ReturnMessage = "OK" };
            }

            return new Student { ReturnMessage = "Error: Student not found." };
        }
        public DataSet GetStudentAndBook()
        {
            SqlCommand sc = new SqlCommand("GetStudentsAndBooks", ConnectionString.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }
    }
}
