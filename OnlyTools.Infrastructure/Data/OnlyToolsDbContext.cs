﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlyTools.Infrastructure.Data.IdentityModels;
using OnlyTools.Infrastructure.Data.Models;
using OnlyTools.Infrastructure.Data.Seed;
using OnlyTools.Infrastructure.Data.Seed.Configuration;

namespace OnlyTools.Infrastructure.Data
{
    public class OnlyToolsDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        private readonly OnlyToolsSeeder _seeder;

        public OnlyToolsDbContext(DbContextOptions<OnlyToolsDbContext> options, OnlyToolsSeeder seeder)
            : base(options)
        {
            _seeder = seeder;
        }
        public DbSet<Tool> Tools { get; set; } = null!;
        public DbSet<Tip> TipsAndTricks { get; set; } = null!;
        public DbSet<JobListing> JobListings { get; set; } = null!;
        public DbSet<ToolCategory> ToolCategories { get; set; } = null!;
        public DbSet<Like> Likes { get; set; } = null!;
        public DbSet<TipCategory> TipCategories { get; set; } = null!;
        public DbSet<JobListingCategory> JobListingCategories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tool>()
                         .HasOne(t => t.Owner)
                         .WithMany()
                         .HasForeignKey(t => t.OwnerID)
                         .IsRequired();

            modelBuilder.Entity<Tool>()
                        .HasOne(t => t.Renter)
                        .WithMany()
                        .HasForeignKey(t => t.RenterID);

            modelBuilder.Entity<Tip>()
                        .HasOne(t => t.Author)
                        .WithMany()
                        .HasForeignKey(t => t.AuthorId);

            modelBuilder.Entity<Like>()
                .HasKey(l => new { l.UserId, l.TipId });

            modelBuilder.Entity<Like>()
                .HasOne(l => l.User)
                .WithMany(u => u.LikedTips)
                .HasForeignKey(l => l.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.Tip)
                .WithMany(t => t.LikedBy)
                .HasForeignKey(l => l.TipId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<JobListing>()
                        .HasOne(j => j.Poster)
                        .WithMany()
                        .HasForeignKey(j => j.PosterId);

            modelBuilder.Entity<ToolCategory>()
               .HasData(new ToolCategory()
               {
                   Id = 1,
                   Name = "Power Tools"
               },
               new ToolCategory()
               {
                   Id = 2,
                   Name = "Hand Tools"
               },
               new ToolCategory()
               {
                   Id = 3,
                   Name = "Gardening Tools"
               },
               new ToolCategory()
               {
                   Id = 4,
                   Name = "Woodworking Tools"
               },
               new ToolCategory()
               {
                   Id = 5,
                   Name = "Measuring Tools"
               },
               new ToolCategory()
               {
                   Id = 6,
                   Name = "Masonry Tool"
               },
               new ToolCategory()
               {
                   Id = 7,
                   Name = "Other Tools"
               });

            modelBuilder.Entity<TipCategory>()
               .HasData(new TipCategory()
               {
                   Id = 1,
                   Name = "Kitchen Renovations"
               },
               new TipCategory()
               {
                   Id = 2,
                   Name = "Bathroom Renovations"
               },
               new TipCategory()
               {
                   Id = 3,
                   Name = "Flooring Solutions"
               },
               new TipCategory()
               {
                   Id = 4,
                   Name = "Interior Painting"

               },
               new TipCategory()
               {
                   Id = 5,
                   Name = "Exterior Upgrades"


               },
               new TipCategory()
               {

                   Id = 6,
                   Name = "Plumbing Fixes"
               },
               new TipCategory()
               {

                   Id = 7,
                   Name = "Electrical Repairs"
               },
               new TipCategory()
               {

                   Id = 8,
                   Name = "HVAC Maintenance"
               },
               new TipCategory()
               {

                   Id = 9,
                   Name = "Foundation and Structural Repairs"
               },
               new TipCategory()
               {

                   Id = 10,
                   Name = "DIY Home Improvement"
               }
               );

            modelBuilder.Entity<JobListingCategory>()
               .HasData(new JobListingCategory() { 
                    Id = 1,
                    Name = "Electrical"
               },
               new JobListingCategory()
               {
                   Id = 2,
                   Name = "Plumbing"
               },
               new JobListingCategory()
               {
                   Id = 3,
                   Name = "HVAC Systems:"
               },
               new JobListingCategory()
               {
                   Id = 4,
                   Name = "Interior Renovations"
               },
               new JobListingCategory()
               {
                   Id = 5,
                   Name = "Other"
               }
               );
        }
    }
}