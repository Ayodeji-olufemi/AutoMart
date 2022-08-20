#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoMart.Data;
using AutoMart.Models;

namespace AutoMart.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly AutoMart.Data.ApplicationDbContext _context;

        public DeleteModel(AutoMart.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public products products { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            products = await _context.products.FirstOrDefaultAsync(m => m.Id == id);

            if (products == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            products = await _context.products.FindAsync(id);

            if (products != null)
            {
                _context.products.Remove(products);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
