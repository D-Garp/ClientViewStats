﻿using System;
using System.Web;

namespace Models
{
    public class ClientDataModel 
    {
        public string ClientName { get; set; }
        public DateTime? DateRegistered { get; set; }
        public string Location { get; set; }
        public int NumberOfUsers { get; set; }
    }
}


