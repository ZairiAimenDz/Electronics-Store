using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Electronics.Data;
using Electronics.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace Electronics.Pages.Admin.Products
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly Electronics.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment webhostEnvironment;

        public CreateModel(Electronics.Data.ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webhostEnvironment = hostEnvironment;
        }
        public List<Category> Categories;
        public IActionResult OnGet()
        {
            Categories = _context.Category.ToList();
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Product.Thumbnail = UploadFile(Product.ThumbnailFile);
            Product.AddedDate = DateTime.Now;
            Product.IsAvailable = true;
            _context.Category.Where(c => c.ID == Product.CategoryID).FirstOrDefault().Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private string UploadFile(IFormFile file)
        {
            string uniqueFileName = null;

            if (file is not null)
            {
                string uploadsFolder = Path.Combine(webhostEnvironment.WebRootPath, "image");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
