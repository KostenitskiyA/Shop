using System.Collections.Generic;

namespace Shop.Models
{
    /// <summary>
    /// Категория продуктов
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Идентификатор категории
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название категории
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ссылка на продукты категории
        /// </summary>
        public List<Product> Products { get; set; }
    }
}
