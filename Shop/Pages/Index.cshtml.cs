using Shop.Models;
using Shop.Pages.Shared;

namespace Shop.Pages
{
    public class IndexModel : _LayoutModel
    {
        public IndexModel(ApplicationContext db)
            : base(db) { }
    }
}
