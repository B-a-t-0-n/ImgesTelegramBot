using Microsoft.EntityFrameworkCore;

namespace ImgesTelegramBot.DataBase
{
    public class ImagesBotContext : DbContext
    {
        public DbSet<Image> Images { get; set; } = null!;
        public DbSet<User> Users { get; set;} = null!;
        public DbSet<MainRequest> MainRequests { get; set;} = null!;
        public DbSet<UserRequest> UserRequests { get; set;} = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ImagesBotdb;Trusted_Connection=True;");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //}
    }
}
