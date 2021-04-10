using System.Collections.Generic;

namespace Shop.Models
{
    /// <summary>
    /// Корзина пользователя
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Идентификатор корзины
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Список продуктов
        /// </summary>
        public List<CartItem> Items { get; set; }

        /// <summary>
        /// Ссылка на пользователя
        /// </summary>
        public User User { get; set; }
    }
}
