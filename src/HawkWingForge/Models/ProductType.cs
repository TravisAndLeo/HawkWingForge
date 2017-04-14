using System;
using System.Collections.Generic;

namespace HawkWingForge.Models
{
    public partial class ProductType
    {
        public ProductType()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public int Order { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
