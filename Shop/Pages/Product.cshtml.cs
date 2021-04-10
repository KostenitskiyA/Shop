using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shop.Models;
using Shop.Pages.Shared;

namespace Shop.Pages
{
    public class ProductModel : _LayoutModel
    {
        private readonly ApplicationContext _context;

        public Product Product { get; set; }

        public ProductModel(ApplicationContext db) 
            : base(db)
        {
            _context = db;
        }

        public void OnGetProductById(int id)
        {
            Product = _context.Products.Include(c => c.Category).SingleOrDefault(i => i.Id == id);
        }
    }
}
