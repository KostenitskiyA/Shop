using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Models;
using Shop.Pages.Shared;

namespace Shop.Pages
{
    public class AuthorizationModel : _LayoutModel
    {
        private readonly ApplicationContext _context;

        [BindProperty]
        public Authorization Authorization { get; set; } 

        public AuthorizationModel(ApplicationContext db)
            : base(db)
        {
            _context = db;
        }

        public IActionResult OnPostAuthorization()
        {
            try 
            {
                var user = _context.Authorizations.Include(u => u.User).ThenInclude(r => r.Role).SingleOrDefault(a => a.Login == Authorization.Login && a.Password == Authorization.Password);

                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                        new Claim(ClaimsIdentity.DefaultRoleClaimType, user.User.Role.Name)
                    };

                    ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));

                    return RedirectToPage();
                }
                else 
                {
                    Console.WriteLine("Пользователь не найден");
                }

                return NotFound();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.StackTrace);

                return NotFound();
            }
        }
    }
}
