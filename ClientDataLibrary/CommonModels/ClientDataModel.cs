using System;
using System.Web;

namespace CommonModels
{
    public class ClientDataModel 
    {
        public string ClientName { get; set; }
        public DateTime? DateRegistered { get; set; }
        public string Location { get; set; }
        public int NumberOfUsers { get; set; }
    }
}


