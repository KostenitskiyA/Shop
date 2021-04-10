using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Pages.Shared;

namespace Shop.Pages
{
    public class CreateModel : _LayoutModel
    {
        private ApplicationContext _context;

        public List<Role> Roles { get; set; }

        [BindProperty]
        public Shop.Models.User User { get; set; }
            
        public CreateModel(ApplicationContext db) 
            : base(db)
        {
            _context = db;
            Roles = _context.Roles.ToList();
        }

        public void OnPostCreate()
        {
            User.CreateDate = DateTime.Now;
            User.CartId = 1;
            _context.Users.Add(User);
            _context.SaveChanges();

            /*return RedirectToPage("Index");*/
        }
    }
}
