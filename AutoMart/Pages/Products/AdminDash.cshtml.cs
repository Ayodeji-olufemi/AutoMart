using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AutoMart.Models;


namespace AutoMart.Pages.Products
{
    public class AdminDashModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public List<AppUser> myUsers { get; set; }

        public AdminDashModel(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        
        public void OnGet()
        {
           myUsers = _userManager.Users.ToList();
        }
    }
}
