using back_escape_center.Models;
using Microsoft.EntityFrameworkCore;

namespace back_escape_center.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<RegisterModel> Users { get; set; }
    public DbSet<ServiceModel> Services { get; set; }
    public DbSet<ClientModel> Clients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RegisterModel>(entity =>
        {
            entity.ToTable("Users");
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Email).IsUnique();
        });

        modelBuilder.Entity<ClientModel>(entity =>
        {
            entity.ToTable("Clients");
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<ServiceModel>(entity =>
        {
            entity.ToTable("Services");
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Client)
                  .WithMany()
                  .HasForeignKey(e => e.ClientId);
        });
    }
}
