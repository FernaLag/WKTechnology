﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WKTechnology.Persistence;

#nullable disable

namespace WKTechnology.Persistence.Migrations
{
    [DbContext(typeof(WKTechnologyDbContext))]
    [Migration("20230531213304_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WKTechnology.Domain.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AtualizadoEm")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 5, 31, 18, 33, 4, 751, DateTimeKind.Local).AddTicks(9798));

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 5, 31, 18, 33, 4, 751, DateTimeKind.Local).AddTicks(9517));

                    b.Property<string>("ModificadoPor")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasDefaultValue("system");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("WKTechnology.Domain.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AtualizadoEm")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 5, 31, 18, 33, 4, 752, DateTimeKind.Local).AddTicks(1028));

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 5, 31, 18, 33, 4, 752, DateTimeKind.Local).AddTicks(721));

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<string>("ModificadoPor")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasDefaultValue("system");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("WKTechnology.Domain.Produto", b =>
                {
                    b.HasOne("WKTechnology.Domain.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("WKTechnology.Domain.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
