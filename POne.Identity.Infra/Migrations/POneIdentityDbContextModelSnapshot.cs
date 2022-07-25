﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POne.Identity.Infra.Connections;

#nullable disable

namespace POne.Identity.Infra.Migrations
{
    [DbContext(typeof(POneIdentityDbContext))]
    partial class POneIdentityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("POne.Identity.Domain.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Creation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Account");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ce4b628f-3561-49e8-9560-5e16ef46dfe9"),
                            Creation = new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "POne Main Account",
                            IsDeleted = false,
                            LastUpdate = new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "POne"
                        });
                });

            modelBuilder.Entity("POne.Identity.Domain.Entities.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Creation")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Contacts", "auth");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6459b59a-ef4b-4d0c-bc63-4657e262701c"),
                            Creation = new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            LastUpdate = new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Test contact",
                            UserId = new Guid("3de581c4-3f1a-4ac3-a395-24a697eda880")
                        });
                });

            modelBuilder.Entity("POne.Identity.Domain.Entities.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Creation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<bool>("IsDefault")
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

                    b.HasIndex("AccountId");

                    b.ToTable("Profiles", "auth");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"),
                            AccountId = new Guid("ce4b628f-3561-49e8-9560-5e16ef46dfe9"),
                            Creation = new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "POne Admin profile",
                            IsDefault = true,
                            IsDeleted = false,
                            LastUpdate = new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "POne Admin"
                        });
                });

            modelBuilder.Entity("POne.Identity.Domain.Entities.Role", b =>
                {
                    b.Property<string>("Key")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Key");

                    b.ToTable("Roles", "auth");

                    b.HasData(
                        new
                        {
                            Key = "ADMIN_PROFILE_CREATE"
                        },
                        new
                        {
                            Key = "ADMIN_PROFILE_DELETE"
                        },
                        new
                        {
                            Key = "ADMIN_PROFILE_READ"
                        },
                        new
                        {
                            Key = "ADMIN_PROFILE_UPDATE"
                        },
                        new
                        {
                            Key = "ADMIN_USER_CREATE"
                        },
                        new
                        {
                            Key = "ADMIN_USER_DELETE"
                        },
                        new
                        {
                            Key = "ADMIN_USER_READ"
                        },
                        new
                        {
                            Key = "ADMIN_USER_UPDATE"
                        });
                });

            modelBuilder.Entity("POne.Identity.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
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

                    b.Property<Guid?>("ProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Users", "auth");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3de581c4-3f1a-4ac3-a395-24a697eda880"),
                            AccountId = new Guid("ce4b628f-3561-49e8-9560-5e16ef46dfe9"),
                            BirthDate = new DateTime(1996, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Creation = new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "uilliansl@outlook.com",
                            IsDeleted = false,
                            LastUpdate = new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Uillian de Souza Lopes",
                            ProfileId = new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8")
                        });
                });

            modelBuilder.Entity("ProfileRole", b =>
                {
                    b.Property<Guid>("ProfilesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RolesKey")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ProfilesId", "RolesKey");

                    b.HasIndex("RolesKey");

                    b.ToTable("ProfileRoles", "auth");

                    b.HasData(
                        new
                        {
                            ProfilesId = new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"),
                            RolesKey = "ADMIN_PROFILE_CREATE"
                        },
                        new
                        {
                            ProfilesId = new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"),
                            RolesKey = "ADMIN_PROFILE_DELETE"
                        },
                        new
                        {
                            ProfilesId = new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"),
                            RolesKey = "ADMIN_PROFILE_READ"
                        },
                        new
                        {
                            ProfilesId = new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"),
                            RolesKey = "ADMIN_PROFILE_UPDATE"
                        },
                        new
                        {
                            ProfilesId = new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"),
                            RolesKey = "ADMIN_USER_CREATE"
                        },
                        new
                        {
                            ProfilesId = new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"),
                            RolesKey = "ADMIN_USER_DELETE"
                        },
                        new
                        {
                            ProfilesId = new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"),
                            RolesKey = "ADMIN_USER_READ"
                        },
                        new
                        {
                            ProfilesId = new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"),
                            RolesKey = "ADMIN_USER_UPDATE"
                        });
                });

            modelBuilder.Entity("POne.Identity.Domain.Entities.Contact", b =>
                {
                    b.HasOne("POne.Identity.Domain.Entities.User", "User")
                        .WithMany("Contacts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("POne.Core.ValueObjects.PhoneNumber", "Number", b1 =>
                        {
                            b1.Property<Guid>("ContactId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("CountryCode")
                                .HasColumnType("int");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("nvarchar(30)");

                            b1.HasKey("ContactId");

                            b1.ToTable("Contacts", "auth");

                            b1.WithOwner()
                                .HasForeignKey("ContactId");

                            b1.HasData(
                                new
                                {
                                    ContactId = new Guid("6459b59a-ef4b-4d0c-bc63-4657e262701c"),
                                    CountryCode = 55,
                                    Number = "999998888"
                                });
                        });

                    b.Navigation("Number");

                    b.Navigation("User");
                });

            modelBuilder.Entity("POne.Identity.Domain.Entities.Profile", b =>
                {
                    b.HasOne("POne.Identity.Domain.Entities.Account", "Account")
                        .WithMany("Profiles")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("POne.Identity.Domain.Entities.User", b =>
                {
                    b.HasOne("POne.Identity.Domain.Entities.Account", "Account")
                        .WithMany("Users")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("POne.Identity.Domain.Entities.Profile", "Profile")
                        .WithMany("Users")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.NoAction);

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

                    b.Navigation("Account");

                    b.Navigation("Address");

                    b.Navigation("Password");

                    b.Navigation("Profile");

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
                        .HasForeignKey("RolesKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("POne.Identity.Domain.Entities.Account", b =>
                {
                    b.Navigation("Profiles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("POne.Identity.Domain.Entities.Profile", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("POne.Identity.Domain.Entities.User", b =>
                {
                    b.Navigation("Contacts");
                });
#pragma warning restore 612, 618
        }
    }
}
