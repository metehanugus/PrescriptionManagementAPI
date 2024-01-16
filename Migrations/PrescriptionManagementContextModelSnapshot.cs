﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrescriptionManagementAPI.Data;

#nullable disable

namespace PrescriptionManagementAPI.Migrations
{
    [DbContext(typeof(PrescriptionManagementContext))]
    partial class PrescriptionManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PrescriptionManagementAPI.Models.Medicine", b =>
                {
                    b.Property<int>("MedicineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicineID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("MedicineID");

                    b.ToTable("Medicine", (string)null);
                });

            modelBuilder.Entity("PrescriptionManagementAPI.Models.Patient", b =>
                {
                    b.Property<int>("PatientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientID"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TCIDNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientID");

                    b.ToTable("Patient", (string)null);
                });

            modelBuilder.Entity("PrescriptionManagementAPI.Models.PaymentReport", b =>
                {
                    b.Property<int>("PaymentReportID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentReportID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("EmailSent")
                        .HasColumnType("bit");

                    b.Property<int>("PharmacyID")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmountDue")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("PaymentReportID");

                    b.HasIndex("PharmacyID");

                    b.ToTable("PaymentReport", (string)null);
                });

            modelBuilder.Entity("PrescriptionManagementAPI.Models.Pharmacy", b =>
                {
                    b.Property<int>("PharmacyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PharmacyID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PharmacyID");

                    b.ToTable("Pharmacy", (string)null);
                });

            modelBuilder.Entity("PrescriptionManagementAPI.Models.Prescription", b =>
                {
                    b.Property<int>("PrescriptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrescriptionID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.Property<int>("PharmacyID")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("PrescriptionID");

                    b.HasIndex("PatientID");

                    b.HasIndex("PharmacyID");

                    b.ToTable("Prescription", (string)null);
                });

            modelBuilder.Entity("PrescriptionManagementAPI.Models.PrescriptionDetail", b =>
                {
                    b.Property<int>("PrescriptionDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrescriptionDetailID"));

                    b.Property<int>("MedicineID")
                        .HasColumnType("int");

                    b.Property<int>("PrescriptionID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("PrescriptionDetailID");

                    b.HasIndex("MedicineID");

                    b.HasIndex("PrescriptionID");

                    b.ToTable("PrescriptionDetail", (string)null);
                });

            modelBuilder.Entity("PrescriptionManagementAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("PrescriptionManagementAPI.Models.PaymentReport", b =>
                {
                    b.HasOne("PrescriptionManagementAPI.Models.Pharmacy", "Pharmacy")
                        .WithMany()
                        .HasForeignKey("PharmacyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pharmacy");
                });

            modelBuilder.Entity("PrescriptionManagementAPI.Models.Prescription", b =>
                {
                    b.HasOne("PrescriptionManagementAPI.Models.Patient", "Patient")
                        .WithMany("Prescriptions")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrescriptionManagementAPI.Models.Pharmacy", "Pharmacy")
                        .WithMany("Prescriptions")
                        .HasForeignKey("PharmacyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");

                    b.Navigation("Pharmacy");
                });

            modelBuilder.Entity("PrescriptionManagementAPI.Models.PrescriptionDetail", b =>
                {
                    b.HasOne("PrescriptionManagementAPI.Models.Medicine", "Medicine")
                        .WithMany("PrescriptionDetails")
                        .HasForeignKey("MedicineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrescriptionManagementAPI.Models.Prescription", "Prescription")
                        .WithMany("PrescriptionDetails")
                        .HasForeignKey("PrescriptionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicine");

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("PrescriptionManagementAPI.Models.Medicine", b =>
                {
                    b.Navigation("PrescriptionDetails");
                });

            modelBuilder.Entity("PrescriptionManagementAPI.Models.Patient", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("PrescriptionManagementAPI.Models.Pharmacy", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("PrescriptionManagementAPI.Models.Prescription", b =>
                {
                    b.Navigation("PrescriptionDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
