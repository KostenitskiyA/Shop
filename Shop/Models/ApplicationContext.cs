using System.Collections.Generic;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace Shop.Models
{
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// Авторизации пользователей
        /// </summary>
        public DbSet<Authorization> Authorizations { get; set; }

        /// <summary>
        /// Роли
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Пользователи
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Категории продуктов
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Продукты
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Корзины пользователей
        /// </summary>
        public DbSet<Cart> Carts { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().HasIndex(u => u.Id).IsUnique();
            //modelBuilder.Entity<User>().Property(u => u.Id).IsRequired();
            //modelBuilder.Entity<User>().Property(u => u.Name).IsRequired();
            //modelBuilder.Entity<User>().Property(u => u.Name).HasMaxLength(36);
            //modelBuilder.Entity<User>().Property(u => u.RoleId).IsRequired();
            //modelBuilder.Entity<User>().Property(u => u.CreateDate).IsRequired();
            //modelBuilder.Entity<Role>().HasIndex(u => u.Id).IsUnique();
            //modelBuilder.Entity<Product>().HasIndex(u => u.Id).IsUnique();
            //modelBuilder.Entity<Cart>().HasIndex(u => u.Id).IsUnique();

            modelBuilder.Entity<User>()
                .HasOne(r => r.Role)
                .WithMany(u => u.Users)
                .HasForeignKey(r => r.RoleId);

            modelBuilder.Entity<User>()
                .HasOne(a => a.Authorization)
                .WithOne(u => u.User)
                .HasForeignKey<User>(a => a.AuthorizationId);

            modelBuilder.Entity<User>()
                .HasOne(c => c.Cart)
                .WithOne(u => u.User)
                .HasForeignKey<User>(c => c.CartId);

            modelBuilder.Entity<CartItem>()
                .HasOne(c => c.Cart)
                .WithMany(i => i.Items)
                .HasForeignKey(c => c.CartId);

            modelBuilder.Entity<Product>()
                .HasOne(c => c.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(c => c.CategoryId);

            var role1 = new Role
            {
                Id = 1,
                Name = "Покупатель",
                Users = new List<User>()
            };
            var role2 = new Role
            {
                Id = 2,
                Name = "Продавец",
                Users = new List<User>()
            };
            var role3 = new Role
            {
                Id = 3,
                Name = "Администратор",
                Users = new List<User>()
            };

            var user1 = new User
            {
                Id = 1,
                Name = "Alexander",
                RoleId = 1,
                AuthorizationId = 1,
                CartId = 1
            };
            var user2 = new User 
            {
                Id = 2,
                Name = "Dmitriy", 
                RoleId = 1,
                AuthorizationId = 2,
                CartId = 2
            };
            var user3 = new User 
            {
                Id = 3,
                Name = "Vladislav",
                RoleId = 2,
                AuthorizationId = 3,
                CartId = 3
            };
            var user4 = new User
            {
                Id = 4,
                Name = "Lorik",
                RoleId = 3,
                AuthorizationId = 4,
                CartId = 4
            };

            var authorization1 = new Authorization()
            {
                Id = 1,
                Login = "Alex",
                Password = "050101"
            };
            var authorization2 = new Authorization()
            {
                Id = 2,
                Login = "Dima",
                Password = "050101"
            };
            var authorization3 = new Authorization()
            {
                Id = 3,
                Login = "Vlad",
                Password = "050101"
            };
            var authorization4 = new Authorization()
            {
                Id = 4,
                Login = "Lory",
                Password = "050101"
            };

            var category1 = new Category()
            {
                Id = 1,
                Name = "Компьютеры"
            };
            var category2 = new Category()
            {
                Id = 2,
                Name = "Ноутбуки"
            };
            var category3 = new Category()
            {
                Id = 3,
                Name = "Планшеты"
            };
            var category4 = new Category()
            {
                Id = 4,
                Name = "Телефоны"
            };

            var product1 = new Product()
            {
                Id = 1,
                Name = "Apple IPhone 11 64Gb white",
                Description = "Прикольный телефон, наверное",
                CategoryId = 4,
                Price = 59999
            };
            var product2 = new Product()
            {
                Id = 2,
                Name = "Apple IPhone 11 128Gb black",
                Description = "Прикольный телефон, наверное",
                CategoryId = 4,
                Price = 59999
            };
            var product3 = new Product()
            {
                Id = 3,
                Name = "Apple IPhone 12 128Gb black",
                Description = "Прикольный телефон, наверное",
                CategoryId = 4,
                Price = 59999
            };
            var product4 = new Product()
            {
                Id = 4,
                Name = "Apple IPhone 12 64Gb white",
                Description = "Прикольный телефон, наверное",
                CategoryId = 4,
                Price = 59999
            };

            var cart1 = new Cart()
            {
                Id = 1
            };
            var cart2 = new Cart()
            {
                Id = 2
            };
            var cart3 = new Cart()
            {
                Id = 3
            };
            var cart4 = new Cart()
            {
                Id = 4
            };

            modelBuilder.Entity<Role>()
                .HasData(new Role[]
                {
                    role1,
                    role2,
                    role3
                });

            modelBuilder.Entity<User>()
                .HasData(new User[]
                {
                    user1,
                    user2,
                    user3,
                    user4
                });

            modelBuilder.Entity<Authorization>()
                .HasData(new Authorization[]
                {
                    authorization1,
                    authorization2,
                    authorization3,
                    authorization4
                });

            modelBuilder.Entity<Category>()
                .HasData( new Category[]
                {
                    category1,
                    category2,
                    category3,
                    category4
                });

            modelBuilder.Entity<Product>()
                .HasData(new Product[]
                {
                    product1,
                    product2,
                    product3,
                    product4
                });

            modelBuilder.Entity<Cart>()
                .HasData(new Cart[]
                {
                    cart1,
                    cart2,
                    cart3,
                    cart4
                });
        }
    }
}
