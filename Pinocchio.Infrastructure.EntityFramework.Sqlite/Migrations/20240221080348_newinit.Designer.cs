﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pinocchio.Infrastructure.EntityFramework.Sqlite;

#nullable disable

namespace Pinocchio.Infrastructure.EntityFramework.Sqlite.Migrations
{
    [DbContext(typeof(SqlitePinocchioDataContext))]
    [Migration("20240221080348_newinit")]
    partial class newinit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("Pinocchio.Domain.Child", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ChildName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Children", (string)null);
                });

            modelBuilder.Entity("Pinocchio.Domain.Parent", b =>
                {
                    b.Property<string>("ChatId")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("ChatId");

                    b.ToTable("Parents", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
