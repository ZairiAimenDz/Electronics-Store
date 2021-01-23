using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IWebHostEnvironment webHostEnvironment;

        public IndexModel(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        public void OnGet()
        {
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
