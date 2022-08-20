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

namespace AutoMart.Pages.Cart
{
    public class delModel : PageModel
    {
        private readonly AutoMart.Data.ApplicationDbContext _context;

        public delModel(AutoMart.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public cart cart { get; set; }

        public IList<products> products { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            cart = await _context.cart.FirstOrDefaultAsync(m => m.CartId == id);

            if (cart == null)
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

            cart = await _context.cart.FindAsync(id);

            if (cart != null)
            {
                _context.cart.Remove(cart);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
