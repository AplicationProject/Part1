using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampSupermarket.Models
{
    public class Suplier
    {
        public int SuplierID { get; set; }
        public String SuplierName { get; set; }
        public String Adress { get; set; }
        public int Phone { get; set; }

        public virtual ICollection<Product> ProductsSuplier { get; set; }
    }
}