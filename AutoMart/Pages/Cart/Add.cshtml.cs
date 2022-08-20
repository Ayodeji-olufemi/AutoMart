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

namespace AutoMart.Pages.Cart
{
    [Authorize]
    public class AddModel : PageModel
    {
        private readonly AutoMart.Data.ApplicationDbContext _context;

        public AddModel(AutoMart.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int productId)
        {
            var email = User.Identity.Name;
            
            _context.cart.Add(new cart()
            {
                Email = email,
                ProdcutId = productId,
                Quantity = 1,
            });
            _context.SaveChanges();

            return RedirectToPage("/Products/BuyCar");
        }

       
    }
}
