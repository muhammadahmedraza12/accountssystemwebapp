using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Security.Principal;

namespace WebApplication4.Models
{
    public class Journal
    {
       
        public int id { get; set; }
        public int RefNo { get; set; }
        public int Accountid { get; set; }
        public string AccountName { get; set; }
        public decimal Amount { get; set; }
        public string InvoiceNo { get; set; }
        public string Date { get; set; }
        public string ReturnMessage { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }

        public List<Journal> GetAllJournal()
        {
            SqlCommand sc = new SqlCommand("GetAllJournaFAccount", ConnectionString.GetConnection());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            List<Journal> jour = new List<Journal>();
            foreach (DataRow item in dt.Rows)
            {
                Journal ab = new Journal
                {
                    Accountid = Convert.ToInt32(item["AccountId"]),
                    AccountName = item["AccountName"].ToString(),
                    Amount = Convert.ToDecimal(item["Amount"]),
                    Date = item["Date"].ToString(),
                    Debit = Convert.ToDecimal(item["Debit"]),
                    Credit = Convert.ToDecimal(item["Credit"]),
                    RefNo = Convert.ToInt32(item["RefId"]),
                    InvoiceNo = item["InvoiceNo"].ToString(),

                    id = Convert.ToInt32(item["id"]),
                };
                jour.Add(ab);
            }
            return jour;
        }

        public Journal Jounal_Save(Journal account)
        {
            SqlCommand sc = new SqlCommand("InsertNewJournalVoucher", ConnectionString.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@AccountId", account.Accountid);
            sc.Parameters.AddWithValue("@Amount", account.Amount);
            sc.Parameters.AddWithValue("@Debit", account.Debit);
            sc.Parameters.AddWithValue("@Credit", account.Credit);
            sc.Parameters.AddWithValue("@Date", account.Date);
            sc.Parameters.AddWithValue("@InvoiceNo", account.InvoiceNo);
        //    sc.Parameters.AddWithValue("@Id", account.id);
            


            if (sc.ExecuteNonQuery() > 0)
            {
                account.ReturnMessage = "OK";
            }
            return account;
        }
        public Journal Journal_Update(Journal jl)
        {
            SqlCommand sc = new SqlCommand("UpdateJornalVoucher", ConnectionString.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@Id", jl.id);
            sc.Parameters.AddWithValue("@AccountId", jl.Accountid);
            sc.Parameters.AddWithValue("@Amount", jl.Amount);
            sc.Parameters.AddWithValue("@Debit", jl.Debit);
            sc.Parameters.AddWithValue("@Credit", jl.Credit);
            sc.Parameters.AddWithValue("@Date", jl.Date);
            sc.Parameters.AddWithValue("@RefNo", jl.RefNo);
            sc.Parameters.AddWithValue("@InvoiceNo", jl.InvoiceNo);




            if (sc.ExecuteNonQuery() > 0)
            {
                jl.ReturnMessage = "OK";
            }
            return jl;
        }
        public Journal JournalAC_Delete(int id, int RefNo)
        {
            SqlCommand sc = new SqlCommand("DeleteJournalVoucher", ConnectionString.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            sc.Parameters.AddWithValue("@RefId", RefNo);

            if (sc.ExecuteNonQuery() > 0)
            {
                return new Journal { ReturnMessage = "OK" };
            }

            return new Journal { ReturnMessage = "Error:Journal Account not found." };
        }
        public Journal JournalAC_GetById(int Id)
        {
            SqlCommand command = new SqlCommand("GetByIdChartFAccount", ConnectionString.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", Id);
            DataTable dt = new DataTable();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                dt.Load(reader);
            }
            Journal account = new Journal()
            {
                id = Convert.ToInt32(dt.Rows[0]["Id"]),
                Accountid = Convert.ToInt32(dt.Rows[0]["AccountId"]),
                RefNo = Convert.ToInt32(dt.Rows[0]["RefNo"]),
                Debit = Convert.ToDecimal(dt.Rows[0]["Debit"]),
                Credit = Convert.ToDecimal(dt.Rows[0]["Credit"]),
                Amount = Convert.ToDecimal(dt.Rows[0]["Amount"]),
                AccountName = dt.Rows[0]["AccountName"].ToString(),
                Date = dt.Rows[0]["Date"].ToString(),
                InvoiceNo = dt.Rows[0]["InvoiceNo"].ToString(),
            };
            return account;
        }
    }
}
