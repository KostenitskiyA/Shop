namespace Shop.Models
{
    /// <summary>
    /// Продукт
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Идентификатор продукта
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название продукта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание продукта
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Идентификатор категории  продукта
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Ссылка на категорию продукта
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Цена продукта
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// Изображение продукта
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Изображение продукта в низком разрешении
        /// </summary>
        public string ImageThumbnail { get; set; }
    }
}
