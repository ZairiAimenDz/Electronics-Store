using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Electronics.Data;
using Electronics.Models;

namespace Electronics.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly Electronics.Data.ApplicationDbContext _context;

        public ProductsModel(Electronics.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public readonly int EPP = 12;

        [BindProperty(SupportsGet =true)]
        public int Currentpage { get; set; } = 0;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid CategoryID { get; set; }
        [BindProperty(SupportsGet = true)]
        public double PriceMin{ get; set; }
        [BindProperty(SupportsGet = true)]
        public double PriceMax{ get; set; }

        public List<Category> Categories;

        public IList<Product> Product { get; set; } = new List<Product>();

        public async Task OnGetAsync()
        {
            var querry = _context.Product.Include(p => p.Category).Where(p=>p.IsAvailable);
            Categories = _context.Category.ToList();
            if (!string.IsNullOrEmpty(SearchTerm))
                querry = querry.Where(c => c.ProductName.ToLower().Contains(SearchTerm) || c.ProductDescription.ToLower().Contains(SearchTerm));
                   // .Where();
            if(Categories.Where(c=>c.ID == CategoryID).Count() > 0)
            {
                querry = querry.Where(p => p.CategoryID == CategoryID);
            }
            if(PriceMin > 0)
            {
                querry = querry.Where(p => p.ProductPrice > PriceMin);
            }
            if(PriceMax > 0)
            {
                querry = querry.Where(p => p.ProductPrice < PriceMax);
            }
            Product = await querry.Skip(EPP*Currentpage).Take(EPP).ToListAsync();
        }
    }
}
