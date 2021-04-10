using System.Collections.Generic;

namespace Shop.Models
{
    /// <summary>
    /// Роль
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Идентификатор роли
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Название роли
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ссылка на пользователей роли
        /// </summary>
        public List<User> Users { get; set; }
    }
}
