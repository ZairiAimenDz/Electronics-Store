using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Electronics.Models;

namespace Electronics.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Electronics.Models.Category> Category { get; set; }
        public DbSet<Electronics.Models.Product> Product { get; set; }
        public DbSet<Electronics.Models.Order> Order { get; set; }
    }
}
