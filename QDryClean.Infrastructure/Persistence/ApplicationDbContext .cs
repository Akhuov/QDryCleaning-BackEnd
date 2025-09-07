using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Domain.Entities;

namespace QDryClean.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.Migrate();
        }
        public DbSet<User> Users { get; set; }  
        public DbSet<Order> Orders { get; set; }
    }
}

//protected override void OnModelCreating(ModelBuilder modelBuilder)
//{
//    modelBuilder.Entity<Marriage>()
//        .HasOne(m => m.Groom)
//        .WithOne(g => g.Marriage)
//        .HasForeignKey<Marriage>(m => m.GroomId)
//        .OnDelete(DeleteBehavior.NoAction);
//}