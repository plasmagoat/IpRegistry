﻿// <auto-generated />

using Danelec.IpRegistry.Infrastructure.Data;
using Danelec.IpRegistry.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Danelec.IpRegistry.Infrastructure.Migrations
{
    [DbContext(typeof(IpRegistryContext))]
    [Migration("20240217200944_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("Danelec.IpRegistry.Core.Models.IpRegistration", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Ip")
                        .IsUnique();

                    b.ToTable("IpRegistrations");
                });
#pragma warning restore 612, 618
        }
    }
}
