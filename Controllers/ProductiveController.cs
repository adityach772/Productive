using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Productive.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Productive.Controllers
{
    [Route("MyWork")]
    public class ProductiveController : Controller
    {
        DataUpdate du = new DataUpdate();
        [Route("Update")]
        public IActionResult UpdateStatus()
        {
            return View("UpdateFormUI");
        }


        public IActionResult UpdateRecords(ModelForm mf)
        {
            SqlConnection con = new SqlConnection(
            "Data Source=LAPTOP-P5PO135B\\SQLEXPRESS;Initial Catalog=demodatabase;Integrated Security=True");
 
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "INSERT into UsersDetails (UNAME,Status,StartHour,SMeridiem,EndHour,EMeridiem) VALUES ('"+ mf.UNAME +"','" + mf.Selection + "', " + mf.StartHour + ", '" + mf.SMeridiem + "'," + mf.EndHour + ", '" + mf.EMeridiem + "' )";          
            cmd.ExecuteNonQuery();
            con.Close();

            return View("ShowFormUI",mf);

        }
        [Route("SavedRecords")]
        public IActionResult ShowRecords()
        {
            SqlDataReader dr;
            SqlConnection con = new SqlConnection(
            "Data Source=LAPTOP-P5PO135B\\SQLEXPRESS;Initial Catalog=demodatabase;Integrated Security=True");
            List<ModelForm> savedRecords = new List<ModelForm>();

            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select TOP (100) [UNAME],[Status],[StartHour],[SMeridiem],[EndHour],[EMeridiem] from UsersDetails";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                savedRecords.Add(new ModelForm() { UNAME = dr["UNAME"].ToString(),
                                                   Selection = dr["Status"].ToString(),
                    StartHour = (int)dr["StartHour"],
                    SMeridiem = dr["SMeridiem"].ToString(),
                    EndHour = (int)dr["EndHour"],
                    EMeridiem = dr["EMeridiem"].ToString(),
                });
            }
            con.Close();

            return View("UpdateRecordsUI",savedRecords);

        }
    }
}
