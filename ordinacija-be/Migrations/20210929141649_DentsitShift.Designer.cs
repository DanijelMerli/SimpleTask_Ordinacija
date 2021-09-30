﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ordinacija_be.Data;

namespace ordinacija_be.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210929141649_DentsitShift")]
    partial class DentsitShift
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("ordinacija_be.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAndTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Jmbg")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("ordinacija_be.Models.Dentist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("CodeHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("CodeSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("ShiftEnd")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("ShiftStart")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Dentists");
                });
#pragma warning restore 612, 618
        }
    }
}
