using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace WebApplication4.Models
{
    public class ChartFAccount
    {
        public int Accountid { get; set; }
        public int id { get; set; }
        public int Mid { get; set; }
        public string AccountName { get; set; }
        public string TurnOverAc { get; set; }
        public int RefNo { get; set; }
        public string Date { get; set; }
        public string ReturnMessage { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }


        public List<ChartFAccount> GetAllChartAccount()
        {
            SqlCommand sc = new SqlCommand("GetAllChartFAccount", ConnectionString.GetConnection());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            List<ChartFAccount> Caccount = new List<ChartFAccount>();
            foreach (DataRow item in dt.Rows)
            {
                ChartFAccount ab = new ChartFAccount
                {
                   // Accountid = Convert.ToInt32(item["AccountId"]),
                    TurnOverAc = item["MasterAccount"].ToString(),
                    AccountName = item["AccountName"].ToString(),
                    Date = item["Date"].ToString(),
                    Debit = Convert.ToDecimal(item["Debit"]),
                    Credit = Convert.ToDecimal(item["Credit"]),
                    RefNo = Convert.ToInt32(item["RefNo"]),
                    Mid = Convert.ToInt32(item["Mid"]),

                    id = Convert.ToInt32(item["id"]),
                };
                Caccount.Add(ab);
            }
            return Caccount;
        }
        public ChartFAccount ChartfAccount_Save(ChartFAccount Account)
        {
            SqlCommand sc = new SqlCommand("InsertChartFAccount", ConnectionString.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@Mid", Account.Mid);
            sc.Parameters.AddWithValue("@AccountName", Account.AccountName);
            sc.Parameters.AddWithValue("@Debit", Account.Debit);
            sc.Parameters.AddWithValue("@Credit", Account.Credit);
            sc.Parameters.AddWithValue("@Date", Account.Date);
 


            if (sc.ExecuteNonQuery() > 0)
            {
                Account.ReturnMessage = "OK";
            }
            return Account;
        }

        public ChartFAccount ChartAccount_Update(ChartFAccount account)
        {
            SqlCommand sc = new SqlCommand("UpDateChartFAccount", ConnectionString.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@Id", account.id);
            sc.Parameters.AddWithValue("@Mid", account.Mid);
            sc.Parameters.AddWithValue("@AccountName", account.AccountName);
            sc.Parameters.AddWithValue("@Debit", account.Debit);
            sc.Parameters.AddWithValue("@Credit", account.Credit);
            sc.Parameters.AddWithValue("@Date", account.Date);
        



            if (sc.ExecuteNonQuery() > 0)
            {
                account.ReturnMessage = "OK";
            }
            return account;
        }
        public ChartFAccount ChartAccount_Delete(int id)
        {
            SqlCommand sc = new SqlCommand("DeleteChartfAccount", ConnectionString.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@Id", id);

            if (sc.ExecuteNonQuery() > 0)
            {
                return new ChartFAccount { ReturnMessage = "OK" };
            }

            return new ChartFAccount { ReturnMessage = "Error: Account not found." };
        }
        public ChartFAccount ChartAccount_GetById(int Id)
        {
            SqlCommand command = new SqlCommand("GetByIdChartFAccount", ConnectionString.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", Id);
            DataTable dt = new DataTable();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                dt.Load(reader);
            }
            ChartFAccount account = new ChartFAccount()
            {
                id = Convert.ToInt32(dt.Rows[0]["id"]),
                Mid = Convert.ToInt32(dt.Rows[0]["Mid"]),
                RefNo = Convert.ToInt32(dt.Rows[0]["RefNo"]),
                Debit = Convert.ToDecimal(dt.Rows[0]["Debit"]),
                Credit = Convert.ToDecimal(dt.Rows[0]["Credit"]),
                TurnOverAc = dt.Rows[0]["MasterAccount"].ToString(),
                AccountName = dt.Rows[0]["AccountName"].ToString(),
                Date = dt.Rows[0]["Date"].ToString(),
            };
            return account;
        }
    }
}

                   
                   
              
                   

                    
