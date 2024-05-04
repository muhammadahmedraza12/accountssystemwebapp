using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace WebApplication4.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Author { get; set; }

        public int AssignId { get; set; }

        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();
            SqlCommand command = new SqlCommand("GetAllBooks", ConnectionString.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                dt.Load(reader);
            }
            foreach (DataRow item in dt.Rows)
            {
                Book b = new Book()
                {
                    Id = Convert.ToInt32(item["BookId"]),
                    Name = item["BookName"].ToString(),
                    Author = item["BookAuthor"].ToString(),
                };
                books.Add(b);
            }
            return books;
        }
        public Book Book_GetById(int Id)
        {
            SqlCommand command = new SqlCommand("Book_GetById", ConnectionString.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("ParamTable1", Id);
            DataTable dt = new DataTable();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                dt.Load(reader);
            }
            Book book = new Book()
            {
                Id = Convert.ToInt32(dt.Rows[0]["BookId"]),
                Name = dt.Rows[0]["BookName"].ToString(),
                Author = dt.Rows[0]["BookAuthor"].ToString(),
            };
            return book;
        }

        public string SaveBook(Book book)
        {
            SqlCommand command = new SqlCommand("SaveBook", ConnectionString.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ParamTable1", book.Name);
            command.Parameters.AddWithValue("@ParamTable2", book.Author);
            command.Parameters.AddWithValue("@ParamTable3", book.AssignId);
            command.ExecuteNonQuery();

            return "OK";
        }

        public string UpdateBook(int id, Book book)
        {
            book.Id = id;
            SqlCommand command = new SqlCommand("UpdateBook", ConnectionString.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ParamTable1", book.Id);
            command.Parameters.AddWithValue("@ParamTable2", book.Name);
            command.Parameters.AddWithValue("@ParamTable3", book.Author);
            command.Parameters.AddWithValue("@ParamTable4", book.AssignId);
            command.ExecuteNonQuery();

            return "OK";
        }

        public string DeleteBook(int id)
        {
            SqlCommand command = new SqlCommand("DeleteBook", ConnectionString.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ParamTable1", id);

            if (command.ExecuteNonQuery() > 0)
                return "OK";
            else
                return "Data Not Deleted";

        }
    }
}
