﻿// <auto-generated />
using System;
using IServer.IDP.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IServer.IDP.Migrations.IdentityDb
{
    [DbContext(typeof(IdentityDbContext))]
    [Migration("20210427221751_AddEmailAddress")]
    partial class AddEmailAddress
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IServer.IDP.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SecurityCode")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("SecurityCodeExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UserName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("Subject")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Active = true,
                            ConcurrencyStamp = "dd7fbbbc-2928-4f27-b952-a1aa08482e13",
                            Password = "password",
                            SecurityCodeExpirationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subject = "d860efca-22d9-47fd-8249-791ba61b07c7",
                            UserName = "Frank"
                        },
                        new
                        {
                            Id = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Active = true,
                            ConcurrencyStamp = "da58e617-4abb-4aef-852e-83d5492b5da8",
                            Password = "password",
                            SecurityCodeExpirationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subject = "b7539694-97e7-4dfe-84da-b4256e1ff5c7",
                            UserName = "Claire"
                        });
                });

            modelBuilder.Entity("IServer.IDP.Entities.UserClaim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");

                    b.HasData(
                        new
                        {
                            Id = new Guid("49ef4147-92b1-44fa-8985-b49427b13498"),
                            ConcurrencyStamp = "aec20383-b883-42b1-9b01-d995e4490b5b",
                            Type = "given_name",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "Frank"
                        },
                        new
                        {
                            Id = new Guid("3ec1552e-981f-4746-a0e1-67e1c1da659e"),
                            ConcurrencyStamp = "05f5b624-b226-4b16-ab9e-8d1b72b33c9d",
                            Type = "email",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "frank@someprovider.com"
                        },
                        new
                        {
                            Id = new Guid("e2a42ece-e2b5-49df-bc4e-03aa7ed25e40"),
                            ConcurrencyStamp = "74959fa3-1205-4468-b524-5c16ef2dc542",
                            Type = "family_name",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "Underwood"
                        },
                        new
                        {
                            Id = new Guid("0ad73c4e-77f2-4901-9471-19c4118d917b"),
                            ConcurrencyStamp = "cc3c2461-7440-4896-9c18-591bf58f76ec",
                            Type = "address",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "Main Road 1"
                        },
                        new
                        {
                            Id = new Guid("2fcdb59a-10a3-4852-a983-6b14a332165d"),
                            ConcurrencyStamp = "9e524fdf-d494-46fd-bc36-b2352254d3f1",
                            Type = "subscriptionlevel",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "FreeUser"
                        },
                        new
                        {
                            Id = new Guid("a081ddc5-1913-4a15-a942-01cf1cdc8ce3"),
                            ConcurrencyStamp = "32f36104-4528-4df0-ac8f-2dcc51efad34",
                            Type = "country",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "nl"
                        },
                        new
                        {
                            Id = new Guid("c4c4d278-99bb-4c2d-b75d-f84ed3cd7239"),
                            ConcurrencyStamp = "1fc3bb6b-a549-4aa1-acc1-ec7cfbb4b59b",
                            Type = "given_name",
                            UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Value = "Claire"
                        },
                        new
                        {
                            Id = new Guid("f1e96bca-7187-493e-a4fb-373a956da427"),
                            ConcurrencyStamp = "ae90995d-c576-4c7c-a8df-96bbcafb3ee4",
                            Type = "family_name",
                            UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Value = "Underwood"
                        },
                        new
                        {
                            Id = new Guid("aa451e92-533c-4a0d-889e-0b2c3e01a1b5"),
                            ConcurrencyStamp = "87d72f49-ca23-498d-a4eb-c21fcf87b6eb",
                            Type = "email",
                            UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Value = "claire@someprovider.com"
                        },
                        new
                        {
                            Id = new Guid("5bc287b2-47ac-4d46-af9c-dd21369297a6"),
                            ConcurrencyStamp = "2ba25b43-7829-4b01-b195-9f464af2721e",
                            Type = "address",
                            UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Value = "Big Street 2"
                        },
                        new
                        {
                            Id = new Guid("18098b8f-f941-4667-af05-2af44e5d4f07"),
                            ConcurrencyStamp = "9a381320-b7b8-40fe-8516-242984f6dd9e",
                            Type = "subscriptionlevel",
                            UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Value = "PayingUser"
                        },
                        new
                        {
                            Id = new Guid("ae9a1559-57c4-4665-9683-bc26391dbe9d"),
                            ConcurrencyStamp = "ab3c9453-fde4-46e3-a4ac-b7fdcfe779ad",
                            Type = "country",
                            UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Value = "be"
                        });
                });

            modelBuilder.Entity("IServer.IDP.Entities.UserClaim", b =>
                {
                    b.HasOne("IServer.IDP.Entities.User", "User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("IServer.IDP.Entities.User", b =>
                {
                    b.Navigation("Claims");
                });
#pragma warning restore 612, 618
        }
    }
}
