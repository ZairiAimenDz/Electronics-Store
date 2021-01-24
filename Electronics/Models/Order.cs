using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronics.Models
{
    public class Order
    {
        public Guid ID { get; set; }
        public DateTime OrderDate { get; set; }
        public string ApplicationUserID { get; set; }
        public ApplicationUser Client { get; set; }

        public List<Product> OrderProducts { get; set; }
    }
}
