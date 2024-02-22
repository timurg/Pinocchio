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
    [Migration("20240221113633_children_states")]
    partial class children_states
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

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ChildName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ParentChatId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParentChatId");

                    b.ToTable("Children", (string)null);
                });

            modelBuilder.Entity("Pinocchio.Domain.DateChildState", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("ChildId")
                        .HasColumnType("TEXT");

                    b.Property<int>("ChildState")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("StateDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.ToTable("ChildStates", (string)null);
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

            modelBuilder.Entity("Pinocchio.Domain.Child", b =>
                {
                    b.HasOne("Pinocchio.Domain.Parent", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentChatId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Pinocchio.Domain.DateChildState", b =>
                {
                    b.HasOne("Pinocchio.Domain.Child", "Child")
                        .WithMany()
                        .HasForeignKey("ChildId");

                    b.Navigation("Child");
                });

            modelBuilder.Entity("Pinocchio.Domain.Parent", b =>
                {
                    b.Navigation("Children");
                });
#pragma warning restore 612, 618
        }
    }
}
