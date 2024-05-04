using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace WebApplication4.Models
{
    public class Fixed
    {

        public int Id { get; set; }
        public string FixedAccount { get; set; }

        public List<Fixed> GetAllFixedAC()
        {
            SqlCommand sc = new SqlCommand("GetAllFixedACc", ConnectionString.GetConnection());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            List<Fixed> Caccount = new List<Fixed>();
            foreach (DataRow item in dt.Rows)
            {
                Fixed ab = new Fixed
                {
                    // Accountid = Convert.ToInt32(item["AccountId"]),
                    FixedAccount = item["FixedAccount"].ToString(),
                    

                    Id = Convert.ToInt32(item["id"]),
                };
                Caccount.Add(ab);
            }
            return Caccount;
        }
    }
}
