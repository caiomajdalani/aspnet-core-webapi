﻿// <auto-generated />
using System;
using Demo.Core.Data.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Demo.API.Migrations
{
    [DbContext(typeof(DbzMySqlContext))]
    [Migration("20181208205058_InitCreate")]
    partial class InitCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Demo.Application.Data.MySql.Entities.CharacterEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BirthDate");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("Kind");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("ID");

                    b.ToTable("character");
                });

            modelBuilder.Entity("Demo.Application.Data.MySql.Entities.FamilyEntity", b =>
                {
                    b.Property<int>("CharacterID");

                    b.Property<int>("RelativeID");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("Kind");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("CharacterID", "RelativeID");

                    b.HasIndex("RelativeID");

                    b.ToTable("family");
                });

            modelBuilder.Entity("Demo.Application.Data.MySql.Entities.FamilyEntity", b =>
                {
                    b.HasOne("Demo.Application.Data.MySql.Entities.CharacterEntity", "Character")
                        .WithMany()
                        .HasForeignKey("CharacterID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Demo.Application.Data.MySql.Entities.CharacterEntity", "Relative")
                        .WithMany("Relatives")
                        .HasForeignKey("RelativeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
