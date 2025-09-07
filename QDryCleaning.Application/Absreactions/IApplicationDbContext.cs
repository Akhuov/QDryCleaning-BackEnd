using Microsoft.EntityFrameworkCore;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.Absreactions
{
    public interface IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }  
        public DbSet<Order> Orders { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
