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
    public class DetailsModel : PageModel
    {
        private readonly AutoMart.Data.ApplicationDbContext _context;

        public DetailsModel(AutoMart.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
