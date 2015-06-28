using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampSupermarket.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public String NameProduct { get; set; }
        public String Description { get; set; }
        public double Price { get; set; }
        public int SuplierID { get; set; }

        public virtual Suplier suplier { get; set; }
  
    }
}