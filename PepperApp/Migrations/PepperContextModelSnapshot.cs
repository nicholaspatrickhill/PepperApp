﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PepperApp.Data;

#nullable disable

namespace PepperApp.Migrations
{
    [DbContext(typeof(PepperContext))]
    partial class PepperContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("PepperApp.Entities.Pepper", b =>
                {
                    b.Property<Guid>("PepperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsReadOnly")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PepperHeatClass")
                        .HasColumnType("TEXT");

                    b.Property<string>("PepperName")
                        .HasColumnType("TEXT");

                    b.Property<int>("PepperScovilleUnitMax")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PepperScovilleUnitMin")
                        .HasColumnType("INTEGER");

                    b.HasKey("PepperId");

                    b.ToTable("Peppers");

                    b.HasData(
                        new
                        {
                            PepperId = new Guid("9adbc0ea-4054-4531-a224-7a999395cc7a"),
                            IsReadOnly = true,
                            PepperHeatClass = "mild",
                            PepperName = "Anaheim",
                            PepperScovilleUnitMax = 2500,
                            PepperScovilleUnitMin = 500
                        },
                        new
                        {
                            PepperId = new Guid("bca6042a-f862-446a-8953-4a9dd544b27c"),
                            IsReadOnly = true,
                            PepperHeatClass = "mild",
                            PepperName = "Bell Pepper",
                            PepperScovilleUnitMax = 0,
                            PepperScovilleUnitMin = 0
                        },
                        new
                        {
                            PepperId = new Guid("fcbeaeee-d83a-4b49-89db-fca3f01c55ef"),
                            IsReadOnly = true,
                            PepperHeatClass = "super-hot",
                            PepperName = "Carolina Reaper",
                            PepperScovilleUnitMax = 2200000,
                            PepperScovilleUnitMin = 1400000
                        },
                        new
                        {
                            PepperId = new Guid("f1ee99b2-a44b-4ba8-8c9b-c5c09095763f"),
                            IsReadOnly = true,
                            PepperHeatClass = "medium-hot",
                            PepperName = "Cayenne",
                            PepperScovilleUnitMax = 50000,
                            PepperScovilleUnitMin = 30000
                        },
                        new
                        {
                            PepperId = new Guid("aea587b7-0896-4df0-8b38-c68c650e62fa"),
                            IsReadOnly = true,
                            PepperHeatClass = "mild",
                            PepperName = "Banana Pepper",
                            PepperScovilleUnitMax = 500,
                            PepperScovilleUnitMin = 0
                        },
                        new
                        {
                            PepperId = new Guid("aa84715b-bf26-4de2-9bf8-854c63aab24d"),
                            IsReadOnly = true,
                            PepperHeatClass = "super-hot",
                            PepperName = "Ghost Pepper",
                            PepperScovilleUnitMax = 1100000,
                            PepperScovilleUnitMin = 855000
                        },
                        new
                        {
                            PepperId = new Guid("d8797ab4-2660-4d87-9354-43a417b6c682"),
                            IsReadOnly = true,
                            PepperHeatClass = "hot",
                            PepperName = "Habanero",
                            PepperScovilleUnitMax = 350000,
                            PepperScovilleUnitMin = 100000
                        },
                        new
                        {
                            PepperId = new Guid("0f008a7d-7a39-44c3-a633-aca915d10bc4"),
                            IsReadOnly = true,
                            PepperHeatClass = "medium",
                            PepperName = "Jalapeno",
                            PepperScovilleUnitMax = 8000,
                            PepperScovilleUnitMin = 2500
                        },
                        new
                        {
                            PepperId = new Guid("7e6354ce-9bdb-4d1c-9950-9c5e142af144"),
                            IsReadOnly = true,
                            PepperHeatClass = "mild",
                            PepperName = "Poblano",
                            PepperScovilleUnitMax = 2000,
                            PepperScovilleUnitMin = 1000
                        },
                        new
                        {
                            PepperId = new Guid("2d60a7c6-2580-423b-8b1b-c18ba2741bcc"),
                            IsReadOnly = true,
                            PepperHeatClass = "hot",
                            PepperName = "Scotch Bonnet",
                            PepperScovilleUnitMax = 350000,
                            PepperScovilleUnitMin = 100000
                        },
                        new
                        {
                            PepperId = new Guid("384e7fed-0b0b-4ffa-b2f6-d4dc6c0c6dc6"),
                            IsReadOnly = true,
                            PepperHeatClass = "medium-hot",
                            PepperName = "Serrano",
                            PepperScovilleUnitMax = 23000,
                            PepperScovilleUnitMin = 10000
                        },
                        new
                        {
                            PepperId = new Guid("dd7f3107-61ca-4fa0-989f-c4acf9d442b0"),
                            IsReadOnly = true,
                            PepperHeatClass = "medium-hot",
                            PepperName = "Thai Chili",
                            PepperScovilleUnitMax = 100000,
                            PepperScovilleUnitMin = 50000
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
