using Beeshtiha.Domain.Entities;
using Beeshtiha.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace beeshtiha.DAL.DbContexts;

public class BeeshtihaDbContext : DbContext
{
    public BeeshtihaDbContext(DbContextOptions options) 
        : base(options)
    {
    }

    public DbSet<Card> Cards { get; set; }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region seed 
        modelBuilder.Entity<Card>().HasData
           (
            new Card() { Id = 1, CustomerId = 1, ItemsId = 2, Status = Status.Pending, PaymentStatus = PaymentStatus.Partially_paid, CreatedAt = DateTime.UtcNow, UpdatedAt = null  },
            new Card() { Id = 2, CustomerId = 2, ItemsId = 1, Status = Status.Completed, PaymentStatus = PaymentStatus.Unpaid, CreatedAt = DateTime.UtcNow, UpdatedAt = null  },
            new Card() { Id = 3, CustomerId = 3, ItemsId = 3, Status = Status.InProgress, PaymentStatus = PaymentStatus.Paid, CreatedAt = DateTime.UtcNow, UpdatedAt = null  }
            );

        modelBuilder.Entity<Dish>().HasData
            (
            new Dish() { Id = 1, Name = "Osh", Category = Category.Main, Description = "Oldirsa osh oldirsin", Igredients = "brinch", Price = 3500, Amount = 10, CreaterId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null },
            new Dish() { Id = 2, Name = "Tuxum", Category = Category.Appetizer, Description = "Tuxum", Igredients = "tuxum tuz", Price = 2340, Amount = 13, CreaterId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null },
            new Dish() { Id = 3, Name = "Pirog", Category = Category.Dessert, Description = "uuuux", Igredients = "mehr", Price = 2345, Amount = 45, CreaterId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = null }
            );

        modelBuilder.Entity<User>().HasData
            (
            new User() { Id = 1, Name = "Javohir", Phone = "889084000", UserRole = UserRole.Admin, CreatedAt = DateTime.UtcNow, UpdatedAt = null},
            new User() { Id = 2, Name = "Muhammad", Phone = "34565432", UserRole = UserRole.Customer, CreatedAt = DateTime.UtcNow, UpdatedAt = null},
            new User() { Id = 3, Name = "Abror", Phone = "93234345", UserRole = UserRole.Customer, CreatedAt = DateTime.UtcNow, UpdatedAt = null}
            );
      #endregion  
    }
    
}
