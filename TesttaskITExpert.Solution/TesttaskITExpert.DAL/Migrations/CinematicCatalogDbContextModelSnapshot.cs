﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TesttaskITExpert.DAL.Context;

#nullable disable

namespace TesttaskITExpert.DAL.Migrations
{
    [DbContext(typeof(CinematicCatalogDbContext))]
    partial class CinematicCatalogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TesttaskITExpert.DAL.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("parent_category_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("parent_category_id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TesttaskITExpert.DAL.Entities.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("director")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("release")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("TesttaskITExpert.DAL.Entities.FilmCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("category_id")
                        .HasColumnType("int");

                    b.Property<int>("film_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("category_id");

                    b.HasIndex("film_id");

                    b.ToTable("FilmCategories");
                });

            modelBuilder.Entity("TesttaskITExpert.DAL.Entities.Category", b =>
                {
                    b.HasOne("TesttaskITExpert.DAL.Entities.Category", "ParentCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("parent_category_id");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("TesttaskITExpert.DAL.Entities.FilmCategory", b =>
                {
                    b.HasOne("TesttaskITExpert.DAL.Entities.Category", "category")
                        .WithMany("FilmCategories")
                        .HasForeignKey("category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TesttaskITExpert.DAL.Entities.Film", "film")
                        .WithMany("FilmCategories")
                        .HasForeignKey("film_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");

                    b.Navigation("film");
                });

            modelBuilder.Entity("TesttaskITExpert.DAL.Entities.Category", b =>
                {
                    b.Navigation("FilmCategories");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("TesttaskITExpert.DAL.Entities.Film", b =>
                {
                    b.Navigation("FilmCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
