﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tarea2.Data;

#nullable disable

namespace Tarea2.Migrations
{
    [DbContext(typeof(Tarea2DBContext))]
    partial class Tarea2DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Tarea2.Data.Entidades.AgrupadoModulos", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasColumnName("Descripcion");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("AgrupadoModulos");
                });

            modelBuilder.Entity("Tarea2.Data.Entidades.Modulo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AgrupadoModulosId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Controller")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasColumnName("Controller");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<string>("Metodo")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasColumnName("Metodo");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasColumnName("Nombre");

                    b.HasKey("Id");

                    b.HasIndex("AgrupadoModulosId");

                    b.ToTable("Modulo");
                });

            modelBuilder.Entity("Tarea2.Data.Entidades.ModulosRoles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<Guid>("ModuloId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RolId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ModuloId");

                    b.HasIndex("RolId");

                    b.ToTable("ModulosRoles");
                });

            modelBuilder.Entity("Tarea2.Data.Entidades.RegistroDiario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Combustible")
                        .HasColumnType("decimal(12,2)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Gastos")
                        .HasColumnType("decimal(12,2)");

                    b.Property<string>("Observacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PagoBase")
                        .HasColumnType("decimal(12,2)");

                    b.Property<decimal>("PagoConductor")
                        .HasColumnType("decimal(12,2)");

                    b.Property<decimal>("PagoDueño")
                        .HasColumnType("decimal(12,2)");

                    b.Property<Guid>("TaxiId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalDia")
                        .HasColumnType("decimal(12,2)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TaxiId");

                    b.ToTable("RegistrosDiarios");
                });

            modelBuilder.Entity("Tarea2.Data.Entidades.Rol", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasColumnName("Descripcion");

                    b.Property<string>("Descripcion2")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasColumnName("Descripcion2");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("Tarea2.Data.Entidades.Taxi", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<string>("Observacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Taxis");
                });

            modelBuilder.Entity("Tarea2.Data.Entidades.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CretedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("RolId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Tarea2.Data.Entidades.Modulo", b =>
                {
                    b.HasOne("Tarea2.Data.Entidades.AgrupadoModulos", "AgrupadoModulos")
                        .WithMany("Modulos")
                        .HasForeignKey("AgrupadoModulosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AgrupadoModulos");
                });

            modelBuilder.Entity("Tarea2.Data.Entidades.ModulosRoles", b =>
                {
                    b.HasOne("Tarea2.Data.Entidades.Modulo", "Modulo")
                        .WithMany("ModulosRoles")
                        .HasForeignKey("ModuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tarea2.Data.Entidades.Rol", "Rol")
                        .WithMany("ModulosRoles")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modulo");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Tarea2.Data.Entidades.RegistroDiario", b =>
                {
                    b.HasOne("Tarea2.Data.Entidades.Taxi", "Taxi")
                        .WithMany("Registros")
                        .HasForeignKey("TaxiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Taxi");
                });

            modelBuilder.Entity("Tarea2.Data.Entidades.Usuario", b =>
                {
                    b.HasOne("Tarea2.Data.Entidades.Rol", "Rol")
                        .WithMany("Usuario")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Tarea2.Data.Entidades.AgrupadoModulos", b =>
                {
                    b.Navigation("Modulos");
                });

            modelBuilder.Entity("Tarea2.Data.Entidades.Modulo", b =>
                {
                    b.Navigation("ModulosRoles");
                });

            modelBuilder.Entity("Tarea2.Data.Entidades.Rol", b =>
                {
                    b.Navigation("ModulosRoles");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Tarea2.Data.Entidades.Taxi", b =>
                {
                    b.Navigation("Registros");
                });
#pragma warning restore 612, 618
        }
    }
}
