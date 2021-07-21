﻿// <auto-generated />
using System;
using Blog.Web2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Blog.Web2.Migrations
{
    [DbContext(typeof(BlogWeb2Context))]
    [Migration("20210721085145_secondaa")]
    partial class secondaa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Blog.Web2.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Consigliato")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contenuto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Periodo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Sconsigliato")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titolo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Post");
                });
#pragma warning restore 612, 618
        }
    }
}
