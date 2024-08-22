using Microsoft.AspNetCore.Mvc;
using ClientDataLibrary;
using System.Data.SqlClient;
using System.Data;
using ClientViewStats.Models;

namespace ClientViewStats.Controllers
{
    public class UsersController : Controller
    {
        //get users information 
        public IActionResult Users()
        {
            DataTable table = new DataTable();
            UsersModel UsersModel = new UsersModel();

            //Get data from view
            string sqlcom = "SELECT SUM(NumberOfUsers) Users FROM tblClientData";
            using (SqlConnection sqlcon = new SqlConnection(Common.connetionString))
            {
                sqlcon.Open();
                table = Common.GetDataTable(sqlcon, sqlcom);

                UsersModel.NumberOfUsers = Int32.Parse(table.Rows[0]["Users"].ToString());

            }

            return View(UsersModel);
        }



    }
}
