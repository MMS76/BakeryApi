﻿// <auto-generated />
using System;
using BakeryApi.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BakeryApi.Migrations
{
    [DbContext(typeof(BakeryContext))]
    partial class BakeryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BakeryApi.Models.Data.Bread", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BreadName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("MaxCount")
                        .HasColumnType("int");

                    b.Property<int>("MinCount")
                        .HasColumnType("int");

                    b.Property<double>("PricePerUnit")
                        .HasColumnType("float");

                    b.Property<int>("Unit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Breads");
                });

            modelBuilder.Entity("BakeryApi.Models.Data.DeliverTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FromHour")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("ToHour")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DeliverTimes");
                });

            modelBuilder.Entity("BakeryApi.Models.Data.Factor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BreadCount")
                        .HasColumnType("int");

                    b.Property<int>("BreadId")
                        .HasColumnType("int");

                    b.Property<int>("DeliverTimeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelivered")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<string>("TrackingCode")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<long>("UserAddressId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BreadId");

                    b.HasIndex("DeliverTimeId");

                    b.HasIndex("UserAddressId");

                    b.ToTable("Factors");
                });

            modelBuilder.Entity("BakeryApi.Models.Data.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<int>("RoleEnum")
                        .HasColumnType("int");

                    b.Property<string>("SecurityCode")
                        .HasColumnType("varchar(6)");

                    b.Property<DateTime?>("SecurityCodeExpiration")
                        .HasColumnType("datetime2");

                    b.Property<long?>("TelegramChatId")
                        .HasColumnType("bigint");

                    b.Property<string>("TelegramName")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("TelegramUserName")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BakeryApi.Models.Data.UserAddress", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserAddresses");
                });

            modelBuilder.Entity("BakeryApi.Models.Data.Factor", b =>
                {
                    b.HasOne("BakeryApi.Models.Data.Bread", "Bread")
                        .WithMany("Factors")
                        .HasForeignKey("BreadId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BakeryApi.Models.Data.DeliverTime", "DeliverTime")
                        .WithMany("Factors")
                        .HasForeignKey("DeliverTimeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BakeryApi.Models.Data.UserAddress", "UserAddress")
                        .WithMany("Factors")
                        .HasForeignKey("UserAddressId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("BakeryApi.Models.Data.UserAddress", b =>
                {
                    b.HasOne("BakeryApi.Models.Data.User", "User")
                        .WithMany("UserAddress")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
