﻿// <auto-generated />
using System;
using DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(MyConnectionDbContext))]
    partial class MyConnectionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EntityLayer.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AdminId");

                    b.HasIndex("RoleId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("EntityLayer.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BlogContent")
                        .HasColumnType("longtext");

                    b.Property<string>("BlogImage")
                        .HasColumnType("longtext");

                    b.Property<bool>("BlogStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("BlogThumbnailImage")
                        .HasColumnType("longtext");

                    b.Property<string>("BlogTitle")
                        .HasColumnType("longtext");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BlogId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("EntityLayer.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("CategoryName")
                        .HasColumnType("longtext");

                    b.Property<bool>("CategoryStatus")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EntityLayer.Comments", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<string>("CommentContent")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("CommentStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("CommentTitle")
                        .HasColumnType("longtext");

                    b.Property<string>("CommentUserName")
                        .HasColumnType("longtext");

                    b.HasKey("CommentId");

                    b.HasIndex("BlogId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("EntityLayer.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("ContactDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ContactMail")
                        .HasColumnType("longtext");

                    b.Property<string>("ContactMessage")
                        .HasColumnType("longtext");

                    b.Property<bool>("ContactStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ContactSubject")
                        .HasColumnType("longtext");

                    b.Property<string>("ContactUserName")
                        .HasColumnType("longtext");

                    b.HasKey("ContactId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("EntityLayer.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Rolename")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EntityLayer.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EntityLayer.Writer", b =>
                {
                    b.Property<int>("WriterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("WriterAbout")
                        .HasColumnType("longtext");

                    b.Property<string>("WriterImage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("WriterMail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("WriterName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("WriterPassword")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("WriterStatus")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("WriterId");

                    b.HasIndex("RoleId");

                    b.ToTable("Writers");
                });

            modelBuilder.Entity("EntityLayer.Admin", b =>
                {
                    b.HasOne("EntityLayer.Role", "Roles")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("EntityLayer.Blog", b =>
                {
                    b.HasOne("EntityLayer.Category", "Category")
                        .WithMany("Blogs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.User", "User")
                        .WithMany("Blog")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EntityLayer.Comments", b =>
                {
                    b.HasOne("EntityLayer.Blog", "Blog")
                        .WithMany("Comment")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("EntityLayer.User", b =>
                {
                    b.HasOne("EntityLayer.Role", "Roles")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("EntityLayer.Writer", b =>
                {
                    b.HasOne("EntityLayer.Role", "Roles")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("EntityLayer.Blog", b =>
                {
                    b.Navigation("Comment");
                });

            modelBuilder.Entity("EntityLayer.Category", b =>
                {
                    b.Navigation("Blogs");
                });

            modelBuilder.Entity("EntityLayer.User", b =>
                {
                    b.Navigation("Blog");
                });
#pragma warning restore 612, 618
        }
    }
}
