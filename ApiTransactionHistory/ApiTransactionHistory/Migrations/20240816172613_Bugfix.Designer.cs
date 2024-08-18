﻿// <auto-generated />
using System;
using ApiTransactionHistory.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiTransactionHistory.Migrations
{
    [DbContext(typeof(ApiTransactionHistoryContext))]
    [Migration("20240816172613_Bugfix")]
    partial class Bugfix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiTransactionHistory.Domain.ProductInCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<decimal>("PricePerProduct")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("TransactionHistoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TransactionHistoryId");

                    b.ToTable("ProductInCart");
                });

            modelBuilder.Entity("ApiTransactionHistory.Domain.TransactionHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("FinalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("PaymentDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("TransactionHistoryToCouponsId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TransactionHistoryToCouponsId");

                    b.ToTable("TransactionHistory");
                });

            modelBuilder.Entity("ApiTransactionHistory.Domain.TransactionHistoryToCoupons", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CouponsId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionHistoryId")
                        .HasColumnType("int");

                    b.Property<int>("TransactionHistoryId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TransactionHistoryId1");

                    b.ToTable("TransactionHistoryToCoupons");
                });

            modelBuilder.Entity("ApiTransactionHistory.Domain.ProductInCart", b =>
                {
                    b.HasOne("ApiTransactionHistory.Domain.TransactionHistory", null)
                        .WithMany("ProductsInCart")
                        .HasForeignKey("TransactionHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApiTransactionHistory.Domain.TransactionHistory", b =>
                {
                    b.HasOne("ApiTransactionHistory.Domain.TransactionHistoryToCoupons", "Coupons")
                        .WithMany()
                        .HasForeignKey("TransactionHistoryToCouponsId");

                    b.Navigation("Coupons");
                });

            modelBuilder.Entity("ApiTransactionHistory.Domain.TransactionHistoryToCoupons", b =>
                {
                    b.HasOne("ApiTransactionHistory.Domain.TransactionHistory", "TransactionHistory")
                        .WithMany()
                        .HasForeignKey("TransactionHistoryId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TransactionHistory");
                });

            modelBuilder.Entity("ApiTransactionHistory.Domain.TransactionHistory", b =>
                {
                    b.Navigation("ProductsInCart");
                });
#pragma warning restore 612, 618
        }
    }
}