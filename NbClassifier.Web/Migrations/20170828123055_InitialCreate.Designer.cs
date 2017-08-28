﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using NbClassifier.Web.DAL;
using System;

namespace NbClassifier.Web.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20170828123055_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NbClassifier.Web.DAL.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("NbClassifier.Web.DAL.Entities.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Language")
                        .IsRequired();

                    b.Property<string>("Text")
                        .IsRequired();

                    b.HasKey("ReviewId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("NbClassifier.Web.DAL.Entities.ReviewCategory", b =>
                {
                    b.Property<int>("ReviewId");

                    b.Property<int>("CategoryId");

                    b.HasKey("ReviewId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ReviewCategory");
                });

            modelBuilder.Entity("NbClassifier.Web.DAL.Entities.ReviewCategory", b =>
                {
                    b.HasOne("NbClassifier.Web.DAL.Entities.Category", "Category")
                        .WithMany("ReviewCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NbClassifier.Web.DAL.Entities.Review", "Review")
                        .WithMany("ReviewCategories")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
