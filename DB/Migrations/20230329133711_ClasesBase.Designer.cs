﻿// <auto-generated />
using System;
using DB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DB.Migrations
{
    [DbContext(typeof(FactuContext))]
    [Migration("20230329133711_ClasesBase")]
    partial class ClasesBase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DB.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("IdFiscal")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("DB.Models.Concepto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("FacturaId")
                        .HasColumnType("int");

                    b.Property<double>("importe")
                        .HasColumnType("float");

                    b.Property<double>("iva")
                        .HasColumnType("float");

                    b.Property<double>("retencion")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("FacturaId");

                    b.ToTable("Concepto", (string)null);
                });

            modelBuilder.Entity("DB.Models.Contacto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<bool>("EnvioFactura")
                        .HasMaxLength(200)
                        .HasColumnType("bit");

                    b.Property<int>("TipoId")
                        .HasColumnType("int");

                    b.Property<int>("TratamientoId")
                        .HasColumnType("int");

                    b.Property<string>("valor")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("TipoId");

                    b.HasIndex("TratamientoId");

                    b.ToTable("Contacto", (string)null);
                });

            modelBuilder.Entity("DB.Models.Entidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CCC")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("EntidadBancaria")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("IdFiscal")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Entidad", (string)null);
                });

            modelBuilder.Entity("DB.Models.EntidadesBancarias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("EntidadesBancarias", (string)null);
                });

            modelBuilder.Entity("DB.Models.Factura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("BaseImponible")
                        .HasColumnType("float");

                    b.Property<int>("ClienteIdId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFactura")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<double>("Retenciones")
                        .HasColumnType("float");

                    b.Property<double>("TotalFactura")
                        .HasColumnType("float");

                    b.Property<double>("TotalImpuesto")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClienteIdId");

                    b.ToTable("Factura", (string)null);
                });

            modelBuilder.Entity("DB.Models.Loggins", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateAccess")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Loggins", (string)null);
                });

            modelBuilder.Entity("DB.Models.TipoContacto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("TipoContacto", (string)null);
                });

            modelBuilder.Entity("DB.Models.Tratamiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Tratamiento", (string)null);
                });

            modelBuilder.Entity("DB.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("DB.Models.Concepto", b =>
                {
                    b.HasOne("DB.Models.Factura", null)
                        .WithMany("Conceptos")
                        .HasForeignKey("FacturaId");
                });

            modelBuilder.Entity("DB.Models.Contacto", b =>
                {
                    b.HasOne("DB.Models.Cliente", null)
                        .WithMany("Contactos")
                        .HasForeignKey("ClienteId");

                    b.HasOne("DB.Models.TipoContacto", "Tipo")
                        .WithMany()
                        .HasForeignKey("TipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Models.Tratamiento", "Tratamiento")
                        .WithMany()
                        .HasForeignKey("TratamientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tipo");

                    b.Navigation("Tratamiento");
                });

            //modelBuilder.Entity("DB.Models.Factura", b =>
            //    {
            //        b.HasOne("DB.Models.Cliente", "ClienteId")
            //            .WithMany()
            //            .HasForeignKey("ClienteIdId")
            //            .OnDelete(DeleteBehavior.Cascade)
            //            .IsRequired();

            //        b.Navigation("ClienteId");
            //    });

            modelBuilder.Entity("DB.Models.Loggins", b =>
                {
                    b.HasOne("DB.Models.User", "User")
                        .WithMany("Loggins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DB.Models.Cliente", b =>
                {
                    b.Navigation("Contactos");
                });

            modelBuilder.Entity("DB.Models.Factura", b =>
                {
                    b.Navigation("Conceptos");
                });

            modelBuilder.Entity("DB.Models.User", b =>
                {
                    b.Navigation("Loggins");
                });
#pragma warning restore 612, 618
        }
    }
}
