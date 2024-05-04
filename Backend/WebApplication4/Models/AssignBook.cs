using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication4.Models
{
    public class AssignBook
    {
        public int AssignId { get; set; }
        public int StudentId { get; set; }
        public int BookId { get; set; }
        public string Date { get; set; }
        public string StudentName{ get; set; }
        public string BookName { get; set; }
        public List<AssignBook> GetAllBooks()
        {
            SqlCommand sc = new SqlCommand("AssignBook_GetAll", ConnectionString.GetConnection());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            List<AssignBook> assignbooks = new List<AssignBook>();
            foreach (DataRow item in dt.Rows)
            {
                AssignBook ab = new AssignBook
                {
                    AssignId = Convert.ToInt32(item["AssignId"]),
                    StudentName = item["StudentName"].ToString(),
                    BookName = item["BookName"].ToString(),
                    BookId = Convert.ToInt32(item["BookId"]),
                    StudentId = Convert.ToInt32(item["StudentId"]),
                    Date = item["Date"].ToString(),
                };
                assignbooks.Add(ab);
            }
            return assignbooks;
        }
        public string AssignBoook_Save()
        {
            SqlCommand sc = new SqlCommand("AssignBoook_Save", ConnectionString.GetConnection());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@Date", Convert.ToDateTime(this.Date));
            sc.Parameters.AddWithValue("@BookId", this.BookId);
            sc.Parameters.AddWithValue("@StudentId", this.StudentId);
            string message = Convert.ToString(sc.ExecuteScalar());
            return message;
        }
    }
}
