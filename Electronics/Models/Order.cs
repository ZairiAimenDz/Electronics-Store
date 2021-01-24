using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string PaymentCheck { get; set; }
        [NotMapped]
        public IFormFile PaymentCheckFile{ get; set; }
        public bool Payed { get; set; }
        public bool GettingDelivered { get; set; }
        public bool DeliveredAndDone { get; set; }
    }
}
