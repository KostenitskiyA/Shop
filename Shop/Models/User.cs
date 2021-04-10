using System;

namespace Shop.Models
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Идентификатор авторизации пользователя
        /// </summary>
        public int AuthorizationId { get; set; }

        /// <summary>
        /// Ссылка на авторизацию пользователя
        /// </summary>
        public Authorization Authorization { get; set; }

        /// <summary>
        /// Идентификатор роли пользователя
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Ссылка на роль пользователя
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// Идентификатор корзины пользователя
        /// </summary>
        public int CartId { get; set; }

        /// <summary>
        /// Ссылка на корзину пользователя
        /// </summary>
        public Cart Cart { get; set; }

        /// <summary>
        /// Дата создания пользователя
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
