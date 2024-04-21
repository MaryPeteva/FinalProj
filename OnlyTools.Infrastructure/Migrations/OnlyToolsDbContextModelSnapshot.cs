﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlyTools.Infrastructure.Data;

#nullable disable

namespace OnlyTools.Infrastructure.Migrations
{
    [DbContext(typeof(OnlyToolsDbContext))]
    partial class OnlyToolsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("OnlyTools.Infrastructure.Data.IdentityModels.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("varbinary(max)")
                        .HasComment("profile picture, stored as a byte array, optional");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("OnlyTools.Infrastructure.Data.Models.JobListing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("Posted")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PosterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("PosterId");

                    b.ToTable("JobListings");
                });

            modelBuilder.Entity("OnlyTools.Infrastructure.Data.Models.Like", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TipId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "TipId");

                    b.HasIndex("TipId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("OnlyTools.Infrastructure.Data.Models.Tip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid?>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasComment("Category unique identifier, integer representation");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<DateTime>("PubllishedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.ToTable("TipsAndTricks");
                });

            modelBuilder.Entity("OnlyTools.Infrastructure.Data.Models.TipCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("unique integer category identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Category name, string representation");

                    b.HasKey("Id");

                    b.ToTable("TipCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Kitchen Renovations"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bathroom Renovations"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Flooring Solutions"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Interior Painting"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Exterior Upgrades"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Plumbing Fixes"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Electrical Repairs"
                        },
                        new
                        {
                            Id = 8,
                            Name = "HVAC Maintenance"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Foundation and Structural Repairs"
                        },
                        new
                        {
                            Id = 10,
                            Name = "DIY Home Improvement"
                        });
                });

            modelBuilder.Entity("OnlyTools.Infrastructure.Data.Models.Tool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid?>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasComment("Category unique identifier, integer representation");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasComment("Description of the tool to be displayed");

                    b.Property<bool>("IsRented")
                        .HasColumnType("bit")
                        .HasComment("Indicates whether the tool is currently rented out");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Name of the tool to be displayed");

                    b.Property<Guid>("OwnerID")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Foreign key referencing the owner of the tool");

                    b.Property<decimal>("RentPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Price for renting the tool");

                    b.Property<Guid?>("RenterID")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Foreign key referencing the renter of the tool");

                    b.Property<byte[]>("ToolPicture")
                        .HasColumnType("varbinary(max)")
                        .HasComment("Picture of the tool, stored as a byte array, optional");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ApplicationUserId1");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OwnerID");

                    b.HasIndex("RenterID");

                    b.ToTable("Tools");
                });

            modelBuilder.Entity("OnlyTools.Infrastructure.Data.Models.ToolCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("unique integer category identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Category name, string representation");

                    b.HasKey("Id");

                    b.ToTable("ToolCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Power Tools"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Hand Tools"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Gardening Tools"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Woodworking Tools"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Measuring Tools"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Masonry Tool"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Other Tools"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("OnlyTools.Infrastructure.Data.IdentityModels.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("OnlyTools.Infrastructure.Data.IdentityModels.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlyTools.Infrastructure.Data.IdentityModels.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("OnlyTools.Infrastructure.Data.IdentityModels.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlyTools.Infrastructure.Data.Models.JobListing", b =>
                {
                    b.HasOne("OnlyTools.Infrastructure.Data.IdentityModels.ApplicationUser", "Poster")
                        .WithMany()
                        .HasForeignKey("PosterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poster");
                });

            modelBuilder.Entity("OnlyTools.Infrastructure.Data.Models.Like", b =>
                {
                    b.HasOne("OnlyTools.Infrastructure.Data.Models.Tip", "Tip")
                        .WithMany("LikedBy")
                        .HasForeignKey("TipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlyTools.Infrastructure.Data.IdentityModels.ApplicationUser", "User")
                        .WithMany("LikedTips")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Tip");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlyTools.Infrastructure.Data.Models.Tip", b =>
                {
                    b.HasOne("OnlyTools.Infrastructure.Data.IdentityModels.ApplicationUser", null)
                        .WithMany("PostedTips")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("OnlyTools.Infrastructure.Data.IdentityModels.ApplicationUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlyTools.Infrastructure.Data.Models.TipCategory", "Category")
                        .WithMany("Tips")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("OnlyTools.Infrastructure.Data.Models.Tool", b =>
                {
                    b.HasOne("OnlyTools.Infrastructure.Data.IdentityModels.ApplicationUser", null)
                        .WithMany("OwnedTools")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("OnlyTools.Infrastructure.Data.IdentityModels.ApplicationUser", null)
                        .WithMany("RentedTools")
                        .HasForeignKey("ApplicationUserId1");

                    b.HasOne("OnlyTools.Infrastructure.Data.Models.ToolCategory", "Category")
                        .WithMany("Tools")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlyTools.Infrastructure.Data.IdentityModels.ApplicationUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlyTools.Infrastructure.Data.IdentityModels.ApplicationUser", "Renter")
                        .WithMany()
                        .HasForeignKey("RenterID");

                    b.Navigation("Category");

                    b.Navigation("Owner");

                    b.Navigation("Renter");
                });

            modelBuilder.Entity("OnlyTools.Infrastructure.Data.IdentityModels.ApplicationUser", b =>
                {
                    b.Navigation("LikedTips");

                    b.Navigation("OwnedTools");

                    b.Navigation("PostedTips");

                    b.Navigation("RentedTools");
                });

            modelBuilder.Entity("OnlyTools.Infrastructure.Data.Models.Tip", b =>
                {
                    b.Navigation("LikedBy");
                });

            modelBuilder.Entity("OnlyTools.Infrastructure.Data.Models.TipCategory", b =>
                {
                    b.Navigation("Tips");
                });

            modelBuilder.Entity("OnlyTools.Infrastructure.Data.Models.ToolCategory", b =>
                {
                    b.Navigation("Tools");
                });
#pragma warning restore 612, 618
        }
    }
}
