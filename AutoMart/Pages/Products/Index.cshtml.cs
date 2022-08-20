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

namespace AutoMart.Pages.Products
{
    [Authorize(Roles="administrator")]
    public class IndexModel : PageModel
    {
        private readonly AutoMart.Data.ApplicationDbContext _context;

        public IndexModel(AutoMart.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<products> products { get;set; }

        public async Task OnGetAsync()
        {
            products = await _context.products.ToListAsync();
        }
        public IActionResult Index() =>
            Content("administrator");
    }
}
