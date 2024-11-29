﻿// <auto-generated />
using System;
using FitVital.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitVital.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20241129015649_InitialBD")]
    partial class InitialBD
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FitVital.DAL.Entities.Administrador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Administradors");
                });

            modelBuilder.Entity("FitVital.DAL.Entities.Cita", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("NutricionistaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("NutricionistaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("FitVital.DAL.Entities.Ejercicio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdministradorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EjercicioUsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdministradorId");

                    b.HasIndex("EjercicioUsuarioId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Ejercicios");
                });

            modelBuilder.Entity("FitVital.DAL.Entities.EjercicioUsuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("EjercicioUsuarios");
                });

            modelBuilder.Entity("FitVital.DAL.Entities.Nutricionista", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Nutricionistas");
                });

            modelBuilder.Entity("FitVital.DAL.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdministradorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EjercicioUsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdministradorId");

                    b.HasIndex("EjercicioUsuarioId");

                    b.HasIndex("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("FitVital.DAL.Entities.Cita", b =>
                {
                    b.HasOne("FitVital.DAL.Entities.Nutricionista", "Nutricionista")
                        .WithMany("Citas")
                        .HasForeignKey("NutricionistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitVital.DAL.Entities.Usuario", "Usuario")
                        .WithMany("Citas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nutricionista");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("FitVital.DAL.Entities.Ejercicio", b =>
                {
                    b.HasOne("FitVital.DAL.Entities.Administrador", "Administrador")
                        .WithMany("Ejercicios")
                        .HasForeignKey("AdministradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitVital.DAL.Entities.EjercicioUsuario", "EjercicioUsuarios")
                        .WithMany("Ejercicios")
                        .HasForeignKey("EjercicioUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrador");

                    b.Navigation("EjercicioUsuarios");
                });

            modelBuilder.Entity("FitVital.DAL.Entities.Usuario", b =>
                {
                    b.HasOne("FitVital.DAL.Entities.Administrador", "Administrador")
                        .WithMany("Usuarios")
                        .HasForeignKey("AdministradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitVital.DAL.Entities.EjercicioUsuario", "EjercicioUsuarios")
                        .WithMany("Usuarios")
                        .HasForeignKey("EjercicioUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrador");

                    b.Navigation("EjercicioUsuarios");
                });

            modelBuilder.Entity("FitVital.DAL.Entities.Administrador", b =>
                {
                    b.Navigation("Ejercicios");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("FitVital.DAL.Entities.EjercicioUsuario", b =>
                {
                    b.Navigation("Ejercicios");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("FitVital.DAL.Entities.Nutricionista", b =>
                {
                    b.Navigation("Citas");
                });

            modelBuilder.Entity("FitVital.DAL.Entities.Usuario", b =>
                {
                    b.Navigation("Citas");
                });
#pragma warning restore 612, 618
        }
    }
}
