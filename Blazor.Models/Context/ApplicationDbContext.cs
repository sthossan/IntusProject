
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;


namespace Blazor.Models.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { optionsBuilder.UseSqlServer(""); }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(t => t.Name).IsRequired().HasColumnType("varchar(100)");
                entity.Property(t => t.State).IsRequired().HasColumnType("varchar(2)");
            });

            modelBuilder.Entity<Windows>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(t => t.OrderId).IsRequired();
                entity.HasOne(t => t.Orders).WithMany(t => t.Windows).HasForeignKey(t => t.OrderId);

                entity.Property(t => t.Name).IsRequired().HasColumnType("varchar(100)");
                entity.Property(t => t.QuantityOfWindows).IsRequired();
                entity.Property(t => t.TotalSubElements).IsRequired();
            });
            modelBuilder.Entity<SubElements>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(t => t.OrderId).IsRequired();
                entity.Property(t => t.WindowId).IsRequired();
                entity.HasOne(t => t.Windows).WithMany(t => t.SubElements).HasForeignKey(t => t.WindowId);

                entity.Property(t => t.Element).IsRequired();
                entity.Property(t => t.Type).IsRequired().HasColumnType("varchar(50)");
                entity.Property(t => t.Width).IsRequired();
                entity.Property(t => t.Height).IsRequired();
            });


            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();

        }

        public DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Windows> Windows { get; set; }
        public virtual DbSet<SubElements> SubElements { get; set; }
    }
}