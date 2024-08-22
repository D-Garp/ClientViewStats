using Microsoft.AspNetCore.Mvc;
using ClientDataLibrary;
using ClientViewStats.Models;
using System.Data.SqlClient;
using System.Data;

namespace ClientViewStats.Controllers
{
    public class RegistrationDatesController : Controller
    {

        //Registration stats get from sql view
        public IActionResult Registration()
        {
            var Registration = new List<RegistrationModel>();
            //get data per registration date
            Registration = RegistrationGridData();

            return View(Registration);
        }

        private List<RegistrationModel> RegistrationGridData()
        {

            List<RegistrationModel> Registration = new List<RegistrationModel>();
            DataTable table = new DataTable();

            //Get data from view
            string sqlcom = "SELECT * FROM vwRegistrationDate";
            using (SqlConnection sqlcon = new SqlConnection(Common.connetionString))
            {
                sqlcon.Open();
                table = Common.GetDataTable(sqlcon, sqlcom);

                foreach (DataRow row in table.Rows)
                {

                    RegistrationModel RegistrationViewModel = new RegistrationModel();
                    RegistrationViewModel.RegistrationDate = (DateTime.Parse(row["DateRegistered"].ToString())).ToShortDateString();
                    RegistrationViewModel.Clients = row["Clients"].ToString();
                    RegistrationViewModel.Users = Int32.Parse(row["Users"].ToString());

                    Registration.Add(RegistrationViewModel);

                }
            }

            return Registration;
        }

    }
}
