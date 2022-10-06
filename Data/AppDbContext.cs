using eGames.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eGames.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser> // changed from DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character_Game>().HasKey(am => new
            {
                am.CharacterId,
                am.GameId
            });  // combination of primary keys

            modelBuilder.Entity<Character_Game>().HasOne(m => m.Game).WithMany(am => am.Characters_Games).
                HasForeignKey(m => m.GameId);  // Game side

            modelBuilder.Entity<Character_Game>().HasOne(m => m.Character).WithMany(am => am.Characters_Games).
                HasForeignKey(m => m.CharacterId);  // Character side


            base.OnModelCreating(modelBuilder);   // needed for when we define the default authentication tables
        }

        public DbSet<Character> Characters
        {
            get; set;
        }

        public DbSet<Game> Games
        {
            get; set;
        }
        public DbSet<Character_Game> Characters_Games
        {
            get; set;
        }
        public DbSet<GameEngine> GameEngines
        {
            get; set;
        }

        public DbSet<LeadProgrammer> LeadProgrammers
        {
            get; set;
        }

        // Orders related tables

        public DbSet<Order> Orders
        {
            get; set;
        }

        public DbSet<OrderItem> OrderItems
        {
            get; set;
        }

        public DbSet<ShoppingCartItem> ShoppingCartItems
        {
            get; set;
        }
    }
}
