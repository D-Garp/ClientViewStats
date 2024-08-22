using ClientViewStats.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using ClientDataLibrary;

namespace ClientViewStats.Controllers
{
    public class LocationsController : Controller
    {
        //Location stats 
        public IActionResult Locations()
        {
            var Locations = new List<LocationsModel>();
            //Get data from view
            Locations = LocationGridData();

            return View(Locations);
        }

        private List<LocationsModel> LocationGridData()
        {
            List<LocationsModel> Locations = new List<LocationsModel>();
            DataTable table = new DataTable();

            string sqlcom = "SELECT * FROM vwLocations";
            using (SqlConnection sqlcon = new SqlConnection(Common.connetionString))
            {
                sqlcon.Open();
                table = Common.GetDataTable(sqlcon, sqlcom);
            }

            foreach (DataRow row in table.Rows)
            {

                LocationsModel LocationViewModel = new LocationsModel();
                LocationViewModel.Location = row["Location"].ToString();
                LocationViewModel.Clients = row["Clients"].ToString();
                LocationViewModel.Users = Int32.Parse(row["Users"].ToString());

                Locations.Add(LocationViewModel);
            }
            return Locations;

        }

    }
}
