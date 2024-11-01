﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


#nullable disable

namespace SchoolGradesWebApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("SchoolGradesWebApp.Models.Student", b =>
                {
                    b.Property<int>("StudentKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("StudentKey"));

                    b.Property<decimal>("Grade")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("SubjectKey")
                        .HasColumnType("int");

                    b.HasKey("StudentKey");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SchoolGradesWebApp.Models.Subject", b =>
                {
                    b.Property<int>("SubjectKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("SubjectKey"));

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("SubjectKey");

                    b.ToTable("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}