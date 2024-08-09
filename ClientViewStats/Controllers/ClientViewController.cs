using ClientDataConsole;
using ClientViewStats.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.AccessControl;

namespace ClientViewStats.Controllers
{
    public class ClientViewController : Controller
    {
        //using sql connection to get all the data as SQL is more structured 
        public IActionResult ClientView()
        {
            //client list
            var Clients = new List<ClientViewModel>();
            
            //getting clients data
            Clients = GridData();

            return View(Clients);
        }

        //Location stats 
        public IActionResult Locations() 
        {
            var Locations = new List<LocationsModel>();
            DataTable table = new DataTable();

            //Get data from view
            string sqlcom = "SELECT * FROM vwLocations";
            using (SqlConnection sqlcon = new SqlConnection(Common.connetionString)) 
            {
                sqlcon.Open();
                table = Common.GetDataTable(sqlcon, sqlcom);

                foreach (DataRow row in table.Rows)
                {

                    LocationsModel LocationViewModel = new LocationsModel();
                    LocationViewModel.Location = row["Location"].ToString();
                    LocationViewModel.Clients = row["Clients"].ToString();
                    LocationViewModel.Users = Int32.Parse(row["Users"].ToString());

                    Locations.Add(LocationViewModel);

                }
            }

            return View(Locations); 
        }

        //Registration stats get from sql view
        public IActionResult Registration()
        {
            var Registration = new List<RegistrationModel>();
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

            return View(Registration);
        }

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

        //get grid data for clients table 
        private List<ClientViewModel> GridData() {

            List <ClientViewModel> Clients = new List<ClientViewModel>();
            DataTable table = new DataTable();
            string sqlcom = "SELECT * FROM tblClientData";

            using (SqlConnection sqlcon = new SqlConnection(Common.connetionString))
            {
                sqlcon.Open();
                table = Common.GetDataTable(sqlcon, sqlcom);
            }


            foreach (DataRow row in table.Rows) {
                
                ClientViewModel clientViewModel = new ClientViewModel();
                clientViewModel.ClientName = row["ClientName"].ToString();
                clientViewModel.Location = row["Location"].ToString();
                clientViewModel.DateRegistered = (DateTime.Parse(row["DateRegistered"].ToString())).ToShortDateString();
                clientViewModel.NumberOfUsers = Int32.Parse(row["NumberOfUsers"].ToString());

                Clients.Add(clientViewModel);   

            }
               
            return Clients;
        }

    }
}
