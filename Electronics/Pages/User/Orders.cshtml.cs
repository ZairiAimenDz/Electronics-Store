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

namespace Electronics.Pages.User
{
    [Authorize]
    public class OrdersModel : PageModel
    {
        private readonly Electronics.Data.ApplicationDbContext _context;

        public OrdersModel(Electronics.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Order
                .Include(o => o.Client).Where(o => o.Client.UserName == User.Identity.Name).ToListAsync();
        }
    }
}
