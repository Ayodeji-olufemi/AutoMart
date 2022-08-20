#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoMart.Data;
using AutoMart.Models;
using Microsoft.AspNetCore.Authorization;

namespace AutoMart.Pages.Products
{
    [Authorize(Roles = "administrator")]
    public class CreateModel : PageModel
    {
        private readonly AutoMart.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _en;

        public CreateModel(AutoMart.Data.ApplicationDbContext context, IWebHostEnvironment en)
        {
            _context = context;
            _en = en;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public products products { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(IFormFile productImage)
        {
            var path0 = "/img/" + productImage.FileName;
            var filepath = _en.WebRootPath + path0;
            products.Photo = path0;
            //if (!ModelState.IsValid)
            //{
            //   return Page();
            //}
            using (var stream = System.IO.File.Create(filepath))
            {
                productImage.CopyTo(stream);
            }

            
            _context.products.Add(products);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
