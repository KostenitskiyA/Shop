using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Pages.Shared
{
    public class _LayoutModel : PageModel
    {
        private ApplicationContext _context;

        /// <summary>
        /// Список категорий
        /// </summary>
        public List<Category> Categories { get; set; }

        /// <summary>
        /// Список продуктов
        /// </summary>
        public List<Product> Products { get; set; }

        [BindProperty]
        public string Query { get; set; }

        public _LayoutModel(ApplicationContext db)
        {
            _context = db;

            Categories = _context.Categories.ToList();
            Products = new List<Product>();
        }

        /*public void OnGet()
        {
            if (User.Identity.IsAuthenticated) 
            {
                var user = _context.Authorizations.Where(l => l.Login == User.Identity.Name).Include(u => u.User).ThenInclude(c => c.Cart).SingleOrDefault();
                Products = JsonSerializer.Deserialize<List<Product>>(user.User.Cart.Products);
            }
        }*/

        public IActionResult OnPostSearch()
        {
            return RedirectToPage("Search", "ByQuery", new { query = Query });
        }

        public async Task<IActionResult> OnPostLogOutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToPage();
        }

        /*public void OnGetBuy(int id)
        {
            if (User.Identity.IsAuthenticated) 
            {
                var user = _context.Authorizations
                    .Where(l => l.Login == User.Identity.Name)
                    .Include(u => u.User)
                    .ThenInclude(c => c.Cart)
                    .SingleOrDefault();

                var product = _context.Products
                    .Where(i => i.Id == id)
                    .SingleOrDefault();

                Products.Add(product);
                var products = JsonSerializer.Serialize(Products);
                user.User.Cart.Products = products;
                _context.SaveChanges();
            }
        }*/
    }
}
