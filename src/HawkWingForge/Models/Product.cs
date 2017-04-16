using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HawkWingForge.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
        public int ProductTypeID { get; set; }

        public ProductType ProductType { get; set; }
    }
}