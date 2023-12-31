﻿// <auto-generated />
using System;
using FBN.SecBank.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FBN.SecBank.Api.Migrations
{
    [DbContext(typeof(SectBankContext))]
    [Migration("20230622191206_cust added")]
    partial class custadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FBN.SecBank.Api.Accounts.Domain.Account", b =>
                {
                    b.Property<Guid>("AccId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<long>("AccountNumber")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreatedAt")
                        .HasColumnType("datetime");

                    b.Property<decimal>("InialAmount")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("AccId");

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("FBN.SecBank.Api.Customers.Domain.Customer", b =>
                {
                    b.Property<Guid>("CustId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.HasKey("CustId");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("FBN.SecBank.Api.Requests.Domain.Request", b =>
                {
                    b.Property<Guid>("ReqId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("RequestStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("RequestType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ReqId");

                    b.ToTable("requests");
                });
#pragma warning restore 612, 618
        }
    }
}
