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
    [Migration("20210929184711_AppointmentDuration")]
    partial class AppointmentDuration
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

                    b.Property<int?>("DurationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Jmbg")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DurationId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("ordinacija_be.Models.AppointmentDuration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DentistId")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DentistId");

                    b.ToTable("AppointmentDuration");
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

            modelBuilder.Entity("ordinacija_be.Models.Appointment", b =>
                {
                    b.HasOne("ordinacija_be.Models.AppointmentDuration", "Duration")
                        .WithMany()
                        .HasForeignKey("DurationId");

                    b.Navigation("Duration");
                });

            modelBuilder.Entity("ordinacija_be.Models.AppointmentDuration", b =>
                {
                    b.HasOne("ordinacija_be.Models.Dentist", null)
                        .WithMany("Durations")
                        .HasForeignKey("DentistId");
                });

            modelBuilder.Entity("ordinacija_be.Models.Dentist", b =>
                {
                    b.Navigation("Durations");
                });
#pragma warning restore 612, 618
        }
    }
}
