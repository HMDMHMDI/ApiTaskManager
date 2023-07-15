﻿// <auto-generated />
using System;
using ApiTaskManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiTaskManager.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230715095200_fhjhbjklk")]
    partial class fhjhbjklk
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AdminClient", b =>
                {
                    b.Property<int>("AdminsId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.HasKey("AdminsId", "ClientId");

                    b.HasIndex("ClientId");

                    b.ToTable("AdminClients");
                });

            modelBuilder.Entity("AdminTask", b =>
                {
                    b.Property<int>("AdminsId")
                        .HasColumnType("int");

                    b.Property<int>("TasksId")
                        .HasColumnType("int");

                    b.HasKey("AdminsId", "TasksId");

                    b.HasIndex("TasksId");

                    b.ToTable("AdminTasks");
                });

            modelBuilder.Entity("ApiTaskManager.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClientsId")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("TasksId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AdminsId")
                        .HasColumnType("int");

                    b.Property<int>("CompletedTask")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("TasksId")
                        .HasColumnType("int");

                    b.Property<int>("UnCompletedTask")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ClientTask", b =>
                {
                    b.Property<int>("ClientsId")
                        .HasColumnType("int");

                    b.Property<int>("TasksId")
                        .HasColumnType("int");

                    b.HasKey("ClientsId", "TasksId");

                    b.HasIndex("TasksId");

                    b.ToTable("ClientTasks");
                });

            modelBuilder.Entity("Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AdminsId")
                        .HasColumnType("int");

                    b.Property<int>("ClientsId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TasksId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AdminsId")
                        .HasColumnType("int");

                    b.Property<int>("ClientsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdminId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AdminClient", b =>
                {
                    b.HasOne("ApiTaskManager.Models.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("AdminTask", b =>
                {
                    b.HasOne("ApiTaskManager.Models.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Task", "Task")
                        .WithMany()
                        .HasForeignKey("TasksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("ApiTaskManager.Models.Admin", b =>
                {
                    b.HasOne("Owner", "Owner")
                        .WithMany("Admins")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Client", b =>
                {
                    b.HasOne("Owner", "Owner")
                        .WithMany("Clients")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "User")
                        .WithOne("Client")
                        .HasForeignKey("Client", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ClientTask", b =>
                {
                    b.HasOne("Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Task", "Task")
                        .WithMany()
                        .HasForeignKey("TasksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("Owner", b =>
                {
                    b.HasOne("User", "User")
                        .WithOne("Owner")
                        .HasForeignKey("Owner", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Task", b =>
                {
                    b.HasOne("Owner", "Owner")
                        .WithMany("Tasks")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.HasOne("ApiTaskManager.Models.Admin", "Admin")
                        .WithOne("User")
                        .HasForeignKey("User", "AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("ApiTaskManager.Models.Admin", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("Owner", b =>
                {
                    b.Navigation("Admins");

                    b.Navigation("Clients");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Navigation("Client")
                        .IsRequired();

                    b.Navigation("Owner")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
