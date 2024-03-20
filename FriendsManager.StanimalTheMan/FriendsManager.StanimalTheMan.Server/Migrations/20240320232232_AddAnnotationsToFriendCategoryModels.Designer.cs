﻿// <auto-generated />
using System;
using FriendsManager.StanimalTheMan.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FriendsManager.StanimalTheMan.Server.Migrations
{
    [DbContext(typeof(FriendsManagerDbContext))]
    [Migration("20240320232232_AddAnnotationsToFriendCategoryModels")]
    partial class AddAnnotationsToFriendCategoryModels
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FriendsManager.StanimalTheMan.Server.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FriendsManager.StanimalTheMan.Server.Models.Friend", b =>
                {
                    b.Property<int>("FriendID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FriendID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("DesiredContactFrequency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastContactDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastContactType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FriendID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("FriendsManager.StanimalTheMan.Server.Models.Friend", b =>
                {
                    b.HasOne("FriendsManager.StanimalTheMan.Server.Models.Category", "Category")
                        .WithMany("Friends")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FriendsManager.StanimalTheMan.Server.Models.Category", b =>
                {
                    b.Navigation("Friends");
                });
#pragma warning restore 612, 618
        }
    }
}
