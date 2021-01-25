using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Electronics.Data;
using Electronics.Models;

namespace Electronics.Pages.Admin.Orders
{
    public class IndexModel : PageModel
    {
        private readonly Electronics.Data.ApplicationDbContext _context;

        public IndexModel(Electronics.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Order
                .Include(o => o.Client).ToListAsync();
        }
    }
}
