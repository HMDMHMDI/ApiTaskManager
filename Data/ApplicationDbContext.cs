using System.ComponentModel.DataAnnotations;
using ApiTaskManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiTaskManager.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Admin> Admins { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ClientTask> ClientTasks { get; set; }
    public DbSet<AdminTask> AdminTasks { get; set; }
    public DbSet<AdminClient> AdminClients { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Task> Tasks { get; set; }


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
            .HasForeignKey(a => a.OwnerId);
        modelBuilder.Entity<Admin>()
            .HasOne(a => a.User)
            .WithOne(u => u.Admin)
            .HasForeignKey<Admin>(e => e.UserId)
            .OnDelete(DeleteBehavior.SetNull);

        // User Section
        modelBuilder.Entity<User>().HasKey(e => e.Id);
        modelBuilder.Entity<User>()
            .HasOne(u => u.Owner)
            .WithOne(o => o.User)
            .HasForeignKey<User>(u => u.OwnerId);
        modelBuilder.Entity<User>()
            .HasOne(u => u.Admin)
            .WithOne(o => o.User)
            .HasForeignKey<User>(u => u.AdminId)
            .OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<User>()
            .HasOne(u => u.Client)
            .WithOne(o => o.User)
            .HasForeignKey<User>(u => u.ClientId);

        // Owner Section
        modelBuilder.Entity<Owner>()
            .HasMany(o => o.Admins)
            .WithOne(a => a.Owner)
            .HasForeignKey(a => a.OwnerId);
        modelBuilder.Entity<Owner>()
            .HasMany(o => o.Clients)
            .WithOne(c => c.Owner)
            .HasForeignKey(c => c.OwnerId);
        modelBuilder.Entity<Owner>()
            .HasMany(o => o.Tasks)
            .WithOne(t => t.Owner)
            .HasForeignKey(t => t.OwnerId);
        modelBuilder.Entity<Owner>()
            .HasOne(e => e.User)
            .WithOne(e => e.Owner)
            .HasForeignKey<Owner>(e => e.UserId);
        // Client Section
        modelBuilder.Entity<Client>()
            .HasMany(c => c.Tasks)
            .WithMany(t => t.Clients)
            .UsingEntity<ClientTask>(
                j => j.HasOne(e => e.Task).WithMany(),
                j => j.HasOne(e => e.Client).WithMany()
            );
        modelBuilder.Entity<Client>()
            .HasOne(c => c.Owner)
            .WithMany(o => o.Clients)
            .HasForeignKey(o => o.OwnerId);
        modelBuilder.Entity<Client>()
            .HasMany(c => c.Admins)
            .WithMany(e => e.Clients)
            .UsingEntity<AdminClient>(
                j => j.HasOne(e => e.Admin).WithMany(),
                j => j.HasOne(e => e.Client).WithMany()
            );
        modelBuilder.Entity<Client>()
            .HasOne(e => e.User)
            .WithOne(e => e.Client);
        // Task Section
        modelBuilder.Entity<Task>()
            .HasMany(t => t.Clients)
            .WithMany(c => c.Tasks)
            .UsingEntity<ClientTask>(
                j => j.HasOne(j => j.Client).WithMany(),
                j => j.HasOne(j => j.Task).WithMany()
            );
        modelBuilder.Entity<Task>()
            .HasMany(e => e.Admins)
            .WithMany(a => a.Tasks)
            .UsingEntity<AdminTask>(
                j => j.HasOne(j => j.Admin).WithMany(),
                j => j.HasOne(j => j.Task).WithMany()
            );
        modelBuilder.Entity<Task>()
            .HasOne(e => e.Owner)
            .WithMany(e => e.Tasks)
            .HasForeignKey(e => e.OwnerId);
    }
}