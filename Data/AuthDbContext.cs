using ASP.Net.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net.Data
{
    public class AuthDbContext(DbContextOptions<AuthDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Resource> Resources { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(
                entity =>
                {
                    entity.HasIndex(u => u.Username).IsUnique();
                    entity.HasIndex(u => u.Email).IsUnique();
                    entity.Property(u => u.IsActive).HasDefaultValue(true);
                    entity.Property(u => u.ImageUrl).HasDefaultValue("https://avatar.iran.liara.run/public/19");
                    entity.Property(u => u.Created_At).HasDefaultValueSql("GETDATE()");
                    entity.Property(u => u.Updated_At).HasDefaultValueSql("GETDATE()");

                    entity.Ignore(e => e.RoleIds);
                }
            );

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(u => u.Created_At).HasDefaultValueSql("GETDATE()");
                entity.Property(u => u.Updated_At).HasDefaultValueSql("GETDATE()");
                entity.Property(u => u.IsActive).HasDefaultValue(true);

                entity.HasIndex(e => e.Name).IsUnique();

            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.Action).HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(u => u.Created_At).HasDefaultValueSql("GETDATE()");
                entity.Property(u => u.Updated_At).HasDefaultValueSql("GETDATE()");

                entity.HasIndex(e => e.Action).IsUnique();
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(u => u.Created_At).HasDefaultValueSql("GETDATE()");
                entity.Property(u => u.Updated_At).HasDefaultValueSql("GETDATE()");

                entity.HasIndex(e => e.Path).IsUnique();
            });
        }
    }
}
