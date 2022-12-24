using System;
using System.Data;
using System.Data.SqlClient;



namespace Productive.Models
{
    public class DataUpdate
    {
        SqlConnection con = new SqlConnection(
            "Data Source=LAPTOP-P5PO135B\\SQLEXPRESS;Initial Catalog=demodatabase;Integrated Security=True");
        //DAl logic for this project
        public string Saverecord(ModelForm mf)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                con.Open();
                //cmd.ExecuteNonQuery();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO UsersDetails " + "(UNAME,Status,StartHour,SMeridiem,EndHour,EMeridiem)" + " VALUES(' " + mf.UNAME + "','" + mf.Selection + "',"+ mf.StartHour + ",'" + mf.SMeridiem + "'," + mf.EndHour + ",'" + mf.EMeridiem + "')";
                cmd.ExecuteNonQuery();
                con.Close();
               // dr = cmd.();
                
                return ("Inserted");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
           

        }
    }
}
