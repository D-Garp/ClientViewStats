using ClientDataLibrary;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Security.AccessControl;

namespace ClientViewStats.Controllers
{
    public class ClientViewController : Controller
    {
        #region CONTROLLER METHODS
        //using sql connection to get all the data as SQL is more structured 
        public IActionResult ClientView()
        {
            //client list
            var Clients = new List<ClientViewModel>();
            
            //getting clients data
            Clients = GridData();

            return View(Clients);
        }

        #endregion

        #region PRIVATE METHODS
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

        #endregion
    }
}
