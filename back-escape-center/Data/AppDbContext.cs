using back_escape_center.Models;
using Microsoft.EntityFrameworkCore;

namespace back_escape_center.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<PersonModel> Persons { get; set; }
    public DbSet<RegisterModel> Users { get; set; }
    public DbSet<ClientModel> Clients { get; set; }
    public DbSet<ServiceModel> Services { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonModel>(entity =>
        {
            entity.ToTable("Persons");
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Email).IsUnique();
        });

        modelBuilder.Entity<RegisterModel>(entity =>
        {
            entity.ToTable("Users");
        });

        modelBuilder.Entity<ClientModel>(entity =>
        {
            entity.ToTable("Clients");
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
