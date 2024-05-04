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
    public class  ReceiptMaster
    {
        public int RId { get; set; }
        public string InvoiceNo  { get; set; }
        public string Date { get; set; }
      
        public decimal Amount { get; set; }
        public string Description { get; set; }
      
        public string ReturnMessage { get; set; }

        public DataTable ReceiptMaster_GetAll()
        {
            SqlCommand sc = new SqlCommand("GetAllreceiptmaster", ConnectionString.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataReader sdr = sc.ExecuteReader();
            dt.Load(sdr);
            sdr.Close();
            return dt;
        }

        public ReceiptMaster ReceiptMaster_Save(ReceiptMaster ReceiptMc)
        {
            SqlCommand sc = new SqlCommand("insertreceiptmaster", ConnectionString.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@InvoiceNo", ReceiptMc.InvoiceNo);
            sc.Parameters.AddWithValue("@Date", ReceiptMc.Date);
            sc.Parameters.AddWithValue("@Amount", ReceiptMc.Amount);
            sc.Parameters.AddWithValue("@Description", ReceiptMc.Description);
            if (sc.ExecuteNonQuery() > 0)
            {
                ReceiptMc.ReturnMessage = "OK";
            }
            return ReceiptMc;
        }
        public ReceiptMaster ReceiptMaster_Update(ReceiptMaster ReceiptMc)
        {
            SqlCommand sc = new SqlCommand("updatereceiptmaster", ConnectionString.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@RId", ReceiptMc.RId);
            sc.Parameters.AddWithValue("@InvoiceNo", ReceiptMc.InvoiceNo);
            sc.Parameters.AddWithValue("@Date", ReceiptMc.Date);
            sc.Parameters.AddWithValue("@Amount", ReceiptMc.Amount);
            sc.Parameters.AddWithValue("@Description", ReceiptMc.Description);

            if (sc.ExecuteNonQuery() > 0)
            {
                ReceiptMc.ReturnMessage = "OK";
            }
            return ReceiptMc;
        }

        public ReceiptMaster ReceiptMaster_Delete(int RId)
        {
            SqlCommand sc = new SqlCommand("deletereceiptmaster", ConnectionString.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@RId", RId);

            if (sc.ExecuteNonQuery() > 0)
            {
                return new ReceiptMaster { ReturnMessage = "OK" };
            }

            return new ReceiptMaster { ReturnMessage = "Error: ReceiptMaster not found." };
        }
        public ReceiptMaster ReceiptMaster_GetById(int RId)
        {
            SqlCommand command = new SqlCommand("GetbyIDreceiptmaster", ConnectionString.GetConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@RId", RId);
            DataTable dt = new DataTable();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                dt.Load(reader);
            }
            ReceiptMaster ReceiptMc = new ReceiptMaster()
            {
                RId = Convert.ToInt32(dt.Rows[0]["RId"]),
                InvoiceNo = dt.Rows[0]["InvoiceNo"].ToString(),
                Date = dt.Rows[0]["@Date"].ToString(),
                Amount = Convert.ToDecimal(dt.Rows[0]["@Amount"]),
                Description = dt.Rows[0]["@Description"].ToString(),
            };
            return ReceiptMc;
        }
    }
}
