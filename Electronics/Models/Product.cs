using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Electronics.Models
{
    public class Product
    {
        [Key]
        public Guid ID { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime AddedDate { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public double ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public Category Category { get; set; }

        [Required]
        public Guid CategoryID { get; set; }
        public bool IsAvailable { get; set; }
        public string Thumbnail { get; set; }

        [NotMapped]
        public IFormFile ThumbnailFile { get; set; }
        public List<Order> ProductOrders { get; set; }
    }
}
