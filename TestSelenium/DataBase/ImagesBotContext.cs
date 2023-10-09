using Microsoft.EntityFrameworkCore;

namespace ImgesTelegramBot.DataBase
{
    public class ImagesBotContext : DbContext
    {
        public DbSet<Image> Images { get; set;}
        public DbSet<User> Users { get; set;}
        public DbSet<MainRequest> MainRequests { get; set;}
        public DbSet<UserRequest> UserRequests { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ImagesBotdb;Trusted_Connection=True;");
        }
    }
}
