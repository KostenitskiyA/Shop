using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Pages.Shared;

namespace Shop.Pages
{
    public class EditModel : _LayoutModel
    {
        private ApplicationContext _context;

        [BindProperty]
        public Shop.Models.User User { get; set; }

        public EditModel(ApplicationContext db)
            : base(db)
        {
            _context = db;
        }

        public void OnGet(int id)
        {
            User = _context.Users.Find(id);
        }

        public IActionResult OnPostEdit()
        {
            _context.Users.Update(User);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
