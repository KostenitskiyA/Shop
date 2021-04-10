using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Models;
using Shop.Pages.Shared;

namespace Shop.Pages
{
    public class SearchModel : _LayoutModel
    {

        private readonly ApplicationContext _context;

        /// <summary>
        /// Продукты
        /// </summary>
        public List<Product> Products { get; set; }

        public SearchModel(ApplicationContext db)
            : base(db)
        {
            _context = db;

            Products = new List<Product>();
        }

        public void OnGetByQuery(string query)
        {
            Products = !String.IsNullOrEmpty(query) 
                ? _context.Products.Where(c => c.Name.Contains(query)).ToList() 
                : _context.Products.ToList();
        }

        public void OnGetByCategory(int id)
        {
            Products = id > 0 
                ? _context.Products.Where(p => p.CategoryId == id).ToList() 
                : _context.Products.ToList();
        }
    }
}
