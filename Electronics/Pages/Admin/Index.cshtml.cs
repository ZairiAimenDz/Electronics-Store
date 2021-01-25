using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Electronics.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Electronics.Pages.Admin
{
    [Authorize(Roles ="Admin")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public IndexModel(ApplicationDbContext context ,IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public int NumberOfOrder;
        public int NumberOfOrderUnt;
        public int NumberOfClients;

        public void OnGet()
        {
            NumberOfOrder = context.Order.Count();
            NumberOfOrderUnt = context.Order.Where(o => o.GettingDelivered).Count();
            NumberOfClients = context.Users.Count()-1;
        }

        [BindProperty]
        public IFormFile AnnouncementFile{ get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            UploadFile(AnnouncementFile);
            return Redirect("/Index");
        }
        private void UploadFile(IFormFile file)
        {
            if (file is not null) 
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "image");
                string uniqueFileName = "announcement.png";
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
        }
    }
}
