using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Models;
using Shop.Pages.Shared;

namespace Shop.Pages.User
{
    public class IndexModel : _LayoutModel
    {
        private ApplicationContext _context;

        public List<Shop.Models.User> Users { get; set; }

        public IndexModel(ApplicationContext db)
            : base(db)
        {
            _context = db;
            Users = _context.Users.Include(r => r.Role).ToList();
        }

        public IActionResult OnPostDelete(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();

            return RedirectToPage();
        }
    }
}
