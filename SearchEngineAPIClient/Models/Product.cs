using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsAPIClient.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
