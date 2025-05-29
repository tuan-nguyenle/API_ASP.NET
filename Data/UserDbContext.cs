using ASP.Net.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net.Data
{
    public class UserDbContext(DbContextOptions<UserDbContext> options):DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}
