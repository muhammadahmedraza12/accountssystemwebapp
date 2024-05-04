using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace WebApplication4.Models
{
    public class MasterAccount
    {
        public int id { get; set; }
        public int Fid { get; set; }
        public string MastrAccount { get; set; }
        public int Status { get; set; }
        public string FixedAccount { get; set; }
        public string ReturnMessage { get; set; }

        public List<MasterAccount> GetAllMasterAccount()
        {
            SqlCommand sc = new SqlCommand("GetALLMasterAC", ConnectionString.GetConnection());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            List<MasterAccount> masteraccount = new List<MasterAccount>();
            foreach (DataRow item in dt.Rows)
            {
                MasterAccount ab = new MasterAccount
                {
                    id = Convert.ToInt32(item["id"]),
                    MastrAccount = item["MasterAccount"].ToString(),
                    FixedAccount = item["FixedAccount"].ToString(),
                    Fid = Convert.ToInt32(item["Fid"]),
                    Status = Convert.ToInt32(item["Status"]),
                   
                };
                masteraccount.Add(ab);
            }
            return masteraccount;
        }
        public MasterAccount MasterAccount_Save(MasterAccount Account)
        {
            SqlCommand sc = new SqlCommand("InsertMasterAC", ConnectionString.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@MasterAccount",Account.MastrAccount);
            sc.Parameters.AddWithValue("@Fid", Account.Fid);
            sc.Parameters.AddWithValue("@Status", Account.Status);
            if (sc.ExecuteNonQuery() > 0)
            {
                Account.ReturnMessage = "OK";
            }
            return Account;
        }





        public MasterAccount MasterAccount_Update(MasterAccount account)
        {
            SqlCommand sc = new SqlCommand("UpdateMasterAC", ConnectionString.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id",account.id);
            sc.Parameters.AddWithValue("@Fid", account.Fid);
            sc.Parameters.AddWithValue("@MasterAccount", account.MastrAccount);
            sc.Parameters.AddWithValue("@Status", account.Status);
            


            if (sc.ExecuteNonQuery() > 0)
            {
                account.ReturnMessage = "OK";
            }
            return account;
        }
        public MasterAccount MasterAccount_Delete(int id)
        {
            SqlCommand sc = new SqlCommand("DeleteMasterAc", ConnectionString.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);

            if (sc.ExecuteNonQuery() > 0)
            {
                return new MasterAccount { ReturnMessage = "OK" };
            }

            return new MasterAccount { ReturnMessage = "Error: Account not found." };
        }
        public MasterAccount MasterAccount_GetById(int Id)
        {
            SqlCommand command = new SqlCommand("GetByIDMAsterAc", ConnectionString.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", Id);
            DataTable dt = new DataTable();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                dt.Load(reader);
            }
            MasterAccount master = new MasterAccount()
            {
                id = Convert.ToInt32(dt.Rows[0]["id"]),
                Fid = Convert.ToInt32(dt.Rows[0]["Fid"]),
                Status = Convert.ToInt32(dt.Rows[0]["Status"]),
                MastrAccount = dt.Rows[0]["MasterAccount"].ToString(),
                FixedAccount = dt.Rows[0]["FixedAccount"].ToString(),
            };
            return master;
        }
       
    }
}
