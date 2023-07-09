using ApiTaskManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTaskManager.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Admins Section
        modelBuilder.Entity<Admin>()
            .HasMany(a => a.Clients)
            .WithMany(c => c.Admins)
            .UsingEntity<AdminClient>(
                j => j.HasOne(e => e.Client).WithMany(),
                j => j.HasOne(e => e.Admin).WithMany()
            );
        modelBuilder.Entity<Admin>()
            .HasMany(a => a.Tasks)
            .WithMany(t => t.Admins)
            .UsingEntity<AdminTask>(
                j => j.HasOne(e => e.Task).WithMany(),
                j => j.HasOne(e => e.Admin).WithMany()
                );
        modelBuilder.Entity<Admin>()
            .HasOne(a => a.Owner)
            .WithMany(o => o.Admins)
            .HasForeignKey(a => a.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Admin>()
            .HasOne(a => a.User)
            .WithOne(u => u.Admin)
            .HasForeignKey<Admin>(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // User Section
        modelBuilder.Entity<User>()
            .HasOne(u => u.Owner)
            .WithOne(o => o.User)
            .HasForeignKey<User>(u => u.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<User>()
            .HasOne(u => u.Admin)
            .WithOne(o => o.User)
            .HasForeignKey<User>(u => u.AdminId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<User>()
            .HasOne(u => u.Client)
            .WithOne(o => o.User)
            .HasForeignKey<User>(u => u.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Owner Section
        modelBuilder.Entity<Owner>()
            .HasMany(o => o.Admins)
            .WithOne(a => a.Owner)
            .HasForeignKey(a => a.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Owner>()
            .HasMany(o => o.Clients)
            .WithOne(c => c.Owner)
            .HasForeignKey(c => c.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Owner>()
            .HasMany(o => o.Tasks)
            .WithOne(t => t.Owner)
            .HasForeignKey(t => t.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);
        // Client Section
        modelBuilder.Entity<Client>()
            .HasMany(c => c.Tasks)
            .WithMany(t => t.Clients)
            .UsingEntity<ClientTask>(
                j => j.HasOne(e => e.Task).WithMany(),
                j => j.HasOne(e =>e.Client).WithMany()
                );
        modelBuilder.Entity<Client>()
            .HasOne(c => c.Owner)
            .WithMany(o => o.Clients)
            .HasForeignKey(o => o.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Client>()
            .HasMany(c => c.Admins)
            .WithMany(e => e.Clients)
            .UsingEntity<AdminClient>(
                j => j.HasOne(e => e.Admin).WithMany(),
                j => j.HasOne(e => e.Client).WithMany()
                );
    
    }
}