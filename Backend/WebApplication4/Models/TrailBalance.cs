using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace WebApplication4.Models
{
    public class TrailBalance
    {
        public int Accountid { get; set; }
        public string AccountName { get; set; }

        public int id { get; set; }

        public decimal Debit { get; set; }
        public decimal Credit { get; set; }

        

        public List<TrailBalance> GetAllTrailblnce()
        {
            SqlCommand sc = new SqlCommand("GetTrailBamnce", ConnectionString.GetConnection());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            List<TrailBalance> jour = new List<TrailBalance>();
            foreach (DataRow item in dt.Rows)
            {
                TrailBalance ab = new TrailBalance
                {
                    Accountid = Convert.ToInt32(item["AccountId"]),
                    AccountName = item["AccountName"].ToString(),
                    Debit = Convert.ToDecimal(item["Debit"]),
                    Credit = Convert.ToDecimal(item["Credit"]),
                    

                    id = Convert.ToInt32(item["id"]),
                };
                jour.Add(ab);
            }
            return jour;
        }

    }
}
