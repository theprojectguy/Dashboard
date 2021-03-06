﻿// <auto-generated />
using System;
using Dashboard.API.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Dashboard.API.Migrations
{
    [DbContext(typeof(DashboardContext))]
    [Migration("20201215102506_AddDb")]
    partial class AddDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Dashboard.API.Models.Service.ServiceModel", b =>
                {
                    b.Property<Guid>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AccessToken")
                        .HasColumnType("text");

                    b.Property<string>("AuthorizeUrl")
                        .HasColumnType("text");

                    b.Property<string>("ServiceName")
                        .HasColumnType("text");

                    b.Property<string>("UrlImage")
                        .HasColumnType("text");

                    b.HasKey("ServiceId");

                    b.HasIndex("ServiceId")
                        .IsUnique();

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Dashboard.API.Models.ServiceUser.ServiceUserModel", b =>
                {
                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ServiceId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserService");
                });

            modelBuilder.Entity("Dashboard.API.Models.User.UserModel", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Dashboard.API.Models.Widget.WidgetModel", b =>
                {
                    b.Property<Guid>("WidgetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uuid");

                    b.Property<string>("WidgetDescription")
                        .HasColumnType("text");

                    b.Property<string>("WidgetName")
                        .HasColumnType("text");

                    b.HasKey("WidgetId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("WidgetId")
                        .IsUnique();

                    b.ToTable("Widgets");
                });

            modelBuilder.Entity("Dashboard.API.Models.ServiceUser.ServiceUserModel", b =>
                {
                    b.HasOne("Dashboard.API.Models.Service.ServiceModel", "Service")
                        .WithMany("ServiceUsers")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dashboard.API.Models.User.UserModel", "User")
                        .WithMany("ServiceUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dashboard.API.Models.Widget.WidgetModel", b =>
                {
                    b.HasOne("Dashboard.API.Models.Service.ServiceModel", "Service")
                        .WithMany("Widgets")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Dashboard.API.Models.Service.ServiceModel", b =>
                {
                    b.Navigation("ServiceUsers");

                    b.Navigation("Widgets");
                });

            modelBuilder.Entity("Dashboard.API.Models.User.UserModel", b =>
                {
                    b.Navigation("ServiceUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
