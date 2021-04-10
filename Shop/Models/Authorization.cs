namespace Shop.Models
{
    /// <summary>
    /// Авторизация пользователя
    /// </summary>
    public class Authorization
    {
        /// <summary>
        /// Идентификатор авторизации пользователя
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }
        
        /// <summary>
        /// Ссылка на пользователя
        /// </summary>
        public User User { get; set; }
    }
}
