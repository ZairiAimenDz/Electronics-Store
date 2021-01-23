using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Electronics.Data;
using Electronics.Models;
using Microsoft.AspNetCore.Authorization;

namespace Electronics.Pages.Admin.Products
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly Electronics.Data.ApplicationDbContext _context;

        public IndexModel(Electronics.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public readonly int EPP = 12;
        public IList<Product> Product { get;set; }
        [BindProperty(SupportsGet = true)]
        public int Currentpage { get; set; } = 0;

        public async Task OnGetAsync()
        {
            Product = await _context.Product
                .Include(p => p.Category).OrderBy(p => p.ProductName).Skip(EPP*Currentpage).Take(EPP).ToListAsync();
        }
    }
}
