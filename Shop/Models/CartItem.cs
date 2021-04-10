using System;

namespace Shop.Models
{
    /// <summary>
    /// Товар в корзине пользователя
    /// </summary>
    public class CartItem
    {
        /// <summary>
        /// Идентификатор продукта в корзине 
        /// </summary>
        public int CartItemId { get; set; }

        /// <summary>
        /// Идентификатор корзины
        /// </summary>
        public int CartId { get; set; }

        /// <summary>
        /// Ссылка на корзину
        /// </summary>
        public Cart Cart { get; set; }

        /// <summary>
        /// Идентификатор продукта
        /// </summary>
        public int ProductId { get; set; }
        
        /// <summary>
        /// Ссылка на продукт
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Цена продукта
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// Количество продукта
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Дата добавления продукта
        /// </summary>
        public DateTime AddedDate { get; set; }
    }
}
