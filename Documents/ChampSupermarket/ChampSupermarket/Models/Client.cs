using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampSupermarket.Models
{
    public class Client
    {
        public int ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Age { get; set; }
        public int PhoneNum { get; set; }
    }
}