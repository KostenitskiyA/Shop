using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Pages.Shared;

namespace Shop.Pages
{
    public class RegistrationModel : _LayoutModel
    {
        private readonly ApplicationContext _context;

        [BindProperty]
        public Authorization Authorization { get; set; }

        [BindProperty]
        public Models.User User { get; set; }

        public List<Role> Roles { get; set; }

        public RegistrationModel(ApplicationContext db)
            : base(db)
        {
            _context = db;

            Roles = _context.Roles.ToList();
        }

        public IActionResult OnPostRegistration()
        {
            try 
            {
                User.CreateDate = DateTime.Now;

                var user = _context.Authorizations.SingleOrDefault(u => u.Login == Authorization.Login);

                if (user == null)
                {
                    _context.Authorizations.Add(Authorization);
                    _context.Users.Add(User);
                    _context.SaveChangesAsync();

                    return RedirectToPage();
                }
                else
                {
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                }

                return Page();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.StackTrace);

                return NotFound();
            }
        }
    }
}
