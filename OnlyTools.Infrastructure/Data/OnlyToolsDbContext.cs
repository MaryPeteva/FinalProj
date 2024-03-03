using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlyTools.Infrastructure.Data.Models;

namespace OnlyTools.Infrastructure.Data
{
    public class OnlyToolsDbContext: IdentityDbContext
    {
        public OnlyToolsDbContext(DbContextOptions<OnlyToolsDbContext> options):base(options)
        {
            
        }
        public DbSet<Tool> Tools { get; set; }
        //public DbSet<Tips> TipsAndTricks { get; set; }
        public DbSet<ToolOwner> ToolsOwners { get; set; }
        public DbSet<ToolRenter> ToolsRenters { get; set; }
        //public DbSet<TipPublisher> UserPublishedTips { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tool>()
                .HasOne(t => t.Owner)
                .WithMany(to => to.OwnedTools)
                .HasForeignKey(t => t.OwnerID)
                .IsRequired();

            modelBuilder.Entity<Tool>()
                .HasOne(t => t.Renter)
                .WithMany(to => to.RentedTools)
                .HasForeignKey(t => t.RenterID);
            // Configure relationship for ToolsOwners
            modelBuilder.Entity<ToolOwner>()
                .HasMany(to => to.OwnedTools)
                .WithOne(t => t.Owner)
                .HasForeignKey(t => t.OwnerID)
                .IsRequired();

            modelBuilder.Entity<ToolRenter>()
                .HasMany(to => to.RentedTools)
                .WithOne(t => t.Renter);
        }
    }

}
