using System.ComponentModel;
using System.Data;

namespace ClientViewStats
{
    public class ClientViewModel 
    {
        [DisplayName("Client ")]
        public string ClientName { get; set; }
        
        [DisplayName("Registration ")]
        public string DateRegistered { get; set; }
        public string Location { get; set; }
        
        [DisplayName("Users")]
        public int NumberOfUsers { get; set; }

    }
}
