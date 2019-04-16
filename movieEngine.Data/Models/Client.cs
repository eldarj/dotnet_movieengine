using System;
using System.Collections.Generic;
using System.Text;

namespace movieEngine.Data.Models
{
    // Registered API clients
    public class Client
    {
        public int ClientId { get; set; }
        public String Name { get; set; }
        public String Username { get; set; }
        public String Token { get; set; }
        public DateTime DateRegistered { get; set; }
    }
}
