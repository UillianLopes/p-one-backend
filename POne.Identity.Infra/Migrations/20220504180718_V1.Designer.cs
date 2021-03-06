// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POne.Identity.Infra.Connections;

#nullable disable

namespace POne.Identity.Infra.Migrations
{
    [DbContext(typeof(POneIdentityDbContext))]
    [Migration("20220504180718_V1")]
    partial class V1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("POne.Identity.Domain.Entities.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Creation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Profiles", "auth");
                });

            modelBuilder.Entity("POne.Identity.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Creation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Roles", "auth");
                });

            modelBuilder.Entity("POne.Identity.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Creation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.HasKey("Id");

                    b.ToTable("Users", "auth");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3de581c4-3f1a-4ac3-a395-24a697eda880"),
                            BirthDate = new DateTime(1996, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Creation = new DateTime(2022, 5, 4, 15, 7, 18, 561, DateTimeKind.Local).AddTicks(3287),
                            Email = "uilliansl@outlook.com",
                            IsDeleted = false,
                            LastUpdate = new DateTime(2022, 5, 4, 15, 7, 18, 561, DateTimeKind.Local).AddTicks(3293),
                            Name = "Uillian de Souza Lopes"
                        });
                });

            modelBuilder.Entity("ProfileRole", b =>
                {
                    b.Property<Guid>("ProfilesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RolesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProfilesId", "RolesId");

                    b.HasIndex("RolesId");

                    b.ToTable("ProfilesRoles", "auth");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<Guid>("RolesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("UsersRoles", "auth");
                });

            modelBuilder.Entity("POne.Identity.Domain.Entities.User", b =>
                {
                    b.OwnsOne("POne.Core.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)");

                            b1.Property<string>("Country")
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)");

                            b1.Property<string>("District")
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)");

                            b1.Property<string>("Number")
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)");

                            b1.Property<string>("State")
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)");

                            b1.Property<string>("Street")
                                .HasMaxLength(254)
                                .HasColumnType("nvarchar(254)");

                            b1.Property<string>("ZipCode")
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users", "auth");

                            b1.WithOwner()
                                .HasForeignKey("UserId");

                            b1.HasData(
                                new
                                {
                                    UserId = new Guid("3de581c4-3f1a-4ac3-a395-24a697eda880"),
                                    City = "Serra",
                                    Country = "Brazil",
                                    District = "Praia de capuba",
                                    Number = "20",
                                    State = "ES",
                                    Street = "Rua Dolores Araujo de Oliveira",
                                    ZipCode = "29173660"
                                });
                        });

                    b.OwnsOne("POne.Core.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users", "auth");

                            b1.WithOwner()
                                .HasForeignKey("UserId");

                            b1.HasData(
                                new
                                {
                                    UserId = new Guid("3de581c4-3f1a-4ac3-a395-24a697eda880"),
                                    Value = "$2a$11$uxW.fi50RNvTC.GOq20dXu0mZzJ.wIAbjd2V5hEhm.YB62v1V1yIG"
                                });
                        });

                    b.OwnsOne("POne.Core.ValueObjects.PhoneNumber", "MobilePhone", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("CountryCode")
                                .HasColumnType("int");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users", "auth");

                            b1.WithOwner()
                                .HasForeignKey("UserId");

                            b1.HasData(
                                new
                                {
                                    UserId = new Guid("3de581c4-3f1a-4ac3-a395-24a697eda880"),
                                    CountryCode = 55,
                                    Number = "27998321849"
                                });
                        });

                    b.OwnsOne("POne.Identity.Domain.Entities.UserSettings", "Settings", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users", "auth");

                            b1.WithOwner()
                                .HasForeignKey("UserId");

                            b1.HasData(
                                new
                                {
                                    UserId = new Guid("3de581c4-3f1a-4ac3-a395-24a697eda880"),
                                    Value = "eyAiTGFuZ3VhZ2UiOiAicHQtQlIiIH0="
                                });
                        });

                    b.Navigation("Address");

                    b.Navigation("MobilePhone");

                    b.Navigation("Password");

                    b.Navigation("Settings");
                });

            modelBuilder.Entity("ProfileRole", b =>
                {
                    b.HasOne("POne.Identity.Domain.Entities.Profile", null)
                        .WithMany()
                        .HasForeignKey("ProfilesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POne.Identity.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("POne.Identity.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POne.Identity.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
