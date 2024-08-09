using System.ComponentModel;

namespace ClientViewStats.Models
{
    public class RegistrationModel
    {
        [DisplayName("Registration ")]
        public string RegistrationDate { get; set; }
        public string Clients { get; set; }
        public int Users { get; set; }
    }
}
