using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsAPIClient.Models
{
   public class User
    {
        public string Name { get; set; }

        public Guid Token { get; set; }
    }
}
