using System;
using System.Collections.Generic;

namespace HawkWingForge.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public bool? Available { get; set; }
        public int? ProductTypeId { get; set; }

        public virtual ProductType ProductType { get; set; }
    }
}
