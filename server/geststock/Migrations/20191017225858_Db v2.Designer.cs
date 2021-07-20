﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using geststock.Models;

namespace geststock.Migrations
{
    [DbContext(typeof(GeststockContext))]
    [Migration("20191017225858_Db v2")]
    partial class Dbv2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("geststock.Controllers.Models.Hellos", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Libelle");

                    b.HasKey("Id");

                    b.ToTable("Hellos");
                });

            modelBuilder.Entity("geststock.Models.Parametrage.Categorie", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Libelle");

                    b.HasKey("id");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("geststock.Models.Parametrage.Hello", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Libelle");

                    b.HasKey("Id");

                    b.ToTable("Hello");
                });

            modelBuilder.Entity("geststock.Models.Parametrage.PieceModel", b =>
                {
                    b.Property<int>("IdPiece")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("Libelle");

                    b.HasKey("IdPiece");

                    b.ToTable("Piece");
                });

            modelBuilder.Entity("geststock.Models.Parametrage.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Intitule");

                    b.HasKey("Id");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("geststock.Models.Parametrage.Transport", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Libelle");

                    b.Property<string>("Voix");

                    b.HasKey("Code");

                    b.ToTable("Transport");
                });
#pragma warning restore 612, 618
        }
    }
}
