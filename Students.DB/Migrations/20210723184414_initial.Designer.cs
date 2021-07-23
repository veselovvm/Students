﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Students.DB;

namespace Students.DB.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210723184414_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Students.DB.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Fio")
                        .HasColumnType("text");

                    b.Property<int?>("ProgressId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProgressId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Students.DB.StudentProgress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("StudentProgress");
                });

            modelBuilder.Entity("Students.DB.Student", b =>
                {
                    b.HasOne("Students.DB.StudentProgress", "Progress")
                        .WithMany()
                        .HasForeignKey("ProgressId");

                    b.Navigation("Progress");
                });
#pragma warning restore 612, 618
        }
    }
}
