using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Http.Results;


namespace Productive.Models
{
    public class RetriveData
    {
        public void ReadData()
        {
            SqlConnection con = new SqlConnection(
            "Data Source=LAPTOP-P5PO135B\\SQLEXPRESS;Initial Catalog=demodatabase;Integrated Security=True");
            
                SqlCommand cmd = new SqlCommand();               
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select * from UsersDetails ";

            cmd.ExecuteNonQuery(); //not req as it will not return anything which is not useful here
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet saved_records = new DataSet();
            adapter.Fill(saved_records);
            con.Close();
               // return saved_records;

        }
    }
}
