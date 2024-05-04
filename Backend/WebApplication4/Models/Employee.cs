using System.Data.SqlClient;
using System.Data;
using System;

namespace WebApplication4.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string CNIC { get; set; }
        public string Addres { get; set; }
        public string ReturnMessage { get; set; }
        public int Status { get; set; }

        public DataTable Employee_GetAll(int Status)
        {
            SqlCommand sc = new SqlCommand("GetAllEmployee", ConnectionString.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataReader sdr = sc.ExecuteReader();
            dt.Load(sdr);
            sdr.Close();
            return dt;
        }

        public Employee Employee_Save(Employee employee)
        {
            SqlCommand sc = new SqlCommand("CreateEmployee", ConnectionString.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
            sc.Parameters.AddWithValue("@Email",employee.Email);
            sc.Parameters.AddWithValue("@CNIC", employee .CNIC);
            sc.Parameters.AddWithValue("@Addres",employee.Addres);
            if (sc.ExecuteNonQuery() > 0)
            {
                employee.ReturnMessage = "OK";
            }
            return employee;
        }
        public Employee Employee_Update(Employee employee)
        {
            SqlCommand sc = new SqlCommand("UpdateEmployee", ConnectionString.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
            sc.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
            sc.Parameters.AddWithValue("@Email", employee.Email);
            sc.Parameters.AddWithValue("@CNIC", employee.CNIC);
            sc.Parameters.AddWithValue("@Addres", employee.Addres);
            if (sc.ExecuteNonQuery() > 0)
            {
                employee.ReturnMessage = "OK";
            }
            return employee;
        }
        public Employee Employee_Delete(int id)
        {
            SqlCommand sc = new SqlCommand("DeleteEmployee", ConnectionString.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@EmployeeId", id);

            if (sc.ExecuteNonQuery() > 0)
            {
                return new Employee { ReturnMessage = "OK" };
            }

            return new Employee { ReturnMessage = "Error: Employee not found." };
        }
        public Employee Empolyee_GetById(int Id)
        {
            SqlCommand command = new SqlCommand("GetByIdEmployee", ConnectionString.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EmployeeId", Id);
            DataTable dt = new DataTable();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                dt.Load(reader);
            }
            Employee employee = new Employee()
            {
                EmployeeId = Convert.ToInt32(dt.Rows[0]["EmployeeId"]),
                EmployeeName = dt.Rows[0]["EmployeeName"].ToString(),
                Email = dt.Rows[0]["@Email"].ToString(),
                Addres = dt.Rows[0]["@Address"].ToString(),
                CNIC = dt.Rows[0]["@CNIC"].ToString(),
            };
            return employee;
        }
    }
}
