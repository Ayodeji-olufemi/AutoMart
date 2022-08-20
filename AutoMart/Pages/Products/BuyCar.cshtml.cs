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
    public class BuyCarModel : PageModel
    {
        private readonly AutoMart.Data.ApplicationDbContext _context;

        public BuyCarModel(AutoMart.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<products> products { get; set; }


        public async Task OnGetAsync(string? searchbar)
        {
            products = await _context.products.ToListAsync();
            if(searchbar !=null)
            {
                products = products.Where(p => p.Type.Contains(searchbar) || p.Name.Contains(searchbar) || p.Brand.Contains(searchbar)).ToList();
            }
        }
       
    }
}
