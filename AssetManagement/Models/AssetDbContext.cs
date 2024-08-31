using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Models
{
    public class AssetDbContext : DbContext
    {
        public AssetDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasKey(b => b.BookID); 

            modelBuilder.Entity<Hardware>()
                .HasKey(b => b.HardwareID);

            modelBuilder.Entity<Software>()
                .HasKey(b => b.SoftwareID);
        }

        public DbSet<Book> books { get; set; }
        public DbSet<Hardware> hardwares { get; set; }
        public DbSet<Software> softwares { get; set; }
    }
}
