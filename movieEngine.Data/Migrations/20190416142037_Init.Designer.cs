﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using movieEngine.Data;

namespace movieEngine.Data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20190416142037_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("movieEngine.Data.Models.Actor", b =>
                {
                    b.Property<int>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.HasKey("ActorId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("movieEngine.Data.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateRegistered");

                    b.Property<string>("Name");

                    b.Property<string>("Token");

                    b.Property<int>("Username");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("movieEngine.Data.Models.Title", b =>
                {
                    b.Property<int>("TitleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.Property<double>("Rating");

                    b.Property<DateTime>("Released");

                    b.Property<int>("TitleTypeId");

                    b.HasKey("TitleId");

                    b.HasIndex("TitleTypeId");

                    b.ToTable("Titles");
                });

            modelBuilder.Entity("movieEngine.Data.Models.TitleActor", b =>
                {
                    b.Property<int>("TitleId");

                    b.Property<int>("ActorId");

                    b.HasKey("TitleId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("TitleActor");
                });

            modelBuilder.Entity("movieEngine.Data.Models.TitleType", b =>
                {
                    b.Property<int>("TitleTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("TitleTypeId");

                    b.ToTable("TitleTypes");
                });

            modelBuilder.Entity("movieEngine.Data.Models.Title", b =>
                {
                    b.HasOne("movieEngine.Data.Models.TitleType", "Type")
                        .WithMany()
                        .HasForeignKey("TitleTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("movieEngine.Data.Models.TitleActor", b =>
                {
                    b.HasOne("movieEngine.Data.Models.Actor", "Actor")
                        .WithMany("Titles")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("movieEngine.Data.Models.Title", "Title")
                        .WithMany("Actors")
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
