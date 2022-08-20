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
using Microsoft.AspNetCore.Authorization;

namespace AutoMart.Pages.Cart
{
    [Authorize ]
    public class IndexModel : PageModel
    {
        private readonly AutoMart.Data.ApplicationDbContext _context;
       

        public IndexModel(AutoMart.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<cart> cart { get;set; }
        public IList<products> products { get;set; }
        public int ProdcutID { get; set; }
        public decimal total { get; set; }

        public async Task OnGetAsync(int id)
        {
            var email = User.Identity.Name;
            cart = await _context.cart.Where(c => c.Email == email).ToListAsync();
            products = await _context.products.ToListAsync();
           total = 0;
            foreach(var product in cart)
            {
                var prod = products.Where(p => p.Id== product.ProdcutId).FirstOrDefault();
                total += prod.Price;
            }
            
          

        }
        
    }
}
