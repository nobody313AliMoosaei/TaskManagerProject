﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagerRoom308.Data.Database;

#nullable disable

namespace TaskManagerRoom308.Migrations
{
    [DbContext(typeof(Application_dbContext))]
    [Migration("20250129194749_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskManagerRoom308.Data.Entities.Task", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tag")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("TaskLevel")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TaskManagerRoom308.Data.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(220)
                        .HasColumnType("nvarchar(220)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TaskManagerRoom308.Data.Entities.UserTask", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifyDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("TaskRef")
                        .HasColumnType("bigint");

                    b.Property<long>("UserRef")
                        .HasColumnType("bigint");

                    b.Property<int>("UserTaskStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TaskRef");

                    b.HasIndex("UserRef");

                    b.ToTable("UserTasks");
                });

            modelBuilder.Entity("TaskManagerRoom308.Data.Entities.UserTask", b =>
                {
                    b.HasOne("TaskManagerRoom308.Data.Entities.Task", "TaskRefNavigation")
                        .WithMany("UserTasks")
                        .HasForeignKey("TaskRef")
                        .IsRequired();

                    b.HasOne("TaskManagerRoom308.Data.Entities.User", "UserRefNavigation")
                        .WithMany("UserTasks")
                        .HasForeignKey("UserRef")
                        .IsRequired();

                    b.Navigation("TaskRefNavigation");

                    b.Navigation("UserRefNavigation");
                });

            modelBuilder.Entity("TaskManagerRoom308.Data.Entities.Task", b =>
                {
                    b.Navigation("UserTasks");
                });

            modelBuilder.Entity("TaskManagerRoom308.Data.Entities.User", b =>
                {
                    b.Navigation("UserTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
