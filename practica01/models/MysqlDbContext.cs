using Microsoft.EntityFrameworkCore;

namespace practica01.Models
{
    public class MysqlDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;uid=webavanzado;pwd=123;database=csharp01");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u =>
            {
                u.ToTable("users");
                u.Property(p => p.Id).HasColumnName("id");
                u.Property(p => p.Name).HasColumnName("name");
                u.Property(p => p.Password).HasColumnName("password");
                u.Property(p => p.Email).HasColumnName("email");
                u.Property(p => p.FirstName).HasColumnName("first_name");
                u.Property(p => p.LastName).HasColumnName("last_name");
                u.Property(p => p.RememberToken).HasColumnName("remember_token");
                u.Property(p => p.Status).HasColumnName("status");
                u.Property(p => p.RoleId).HasColumnName("role_id");

                u.HasIndex(p => p.Name).IsUnique();
                u.HasIndex(p => p.Email).IsUnique();

                // realtionships
                u.HasOne(user => user.Role).WithMany(roles => roles.Users);
            });

            modelBuilder.Entity<Role>(r =>
            {
                r.ToTable("roles");
                r.Property(p => p.Id).HasColumnName("id");
                r.Property(p => p.Name).HasColumnName("name");

                r.HasIndex(p => p.Name).IsUnique();

                // relationships
                r.HasMany(role => role.Users).WithOne(user => user.Role);
            });

            modelBuilder.Entity<Permission>(p =>
            {
                p.ToTable("permissions");
                p.Property(r => r.Id).HasColumnName("id");
                p.Property(r => r.Description).HasColumnName("description");
                p.Property(r => r.Key).HasColumnName("key");
                p.Property(r => r.RoleId).HasColumnName("role_id");

                p.HasIndex(r => r.Key).IsUnique();
            });

            modelBuilder.Entity<RolePermission>(rp =>
            {
                rp.HasKey(k => new { k.RoleId, k.PermissionId });
            });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
    }
}