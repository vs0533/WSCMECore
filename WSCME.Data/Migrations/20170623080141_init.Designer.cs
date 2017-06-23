using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WSCME.Data;

namespace WSCME.Data.Migrations
{
    [DbContext(typeof(CMEDbContext))]
    [Migration("20170623080141_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WSCME.Domain.TrainingCentre", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("CategoryId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email");

                    b.Property<string>("LinkMain");

                    b.Property<string>("Name");

                    b.Property<string>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TypeId");

                    b.ToTable("TrainingCentres");
                });

            modelBuilder.Entity("WSCME.Domain.TrainingCentreCategory", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TrainingCentreCategorys");
                });

            modelBuilder.Entity("WSCME.Domain.TrainingCentreType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<int>("Desc");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TrainingCentreTypes");
                });

            modelBuilder.Entity("WSCME.Domain.TrainingCentre", b =>
                {
                    b.HasOne("WSCME.Domain.TrainingCentreCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("WSCME.Domain.TrainingCentreType", "Type")
                        .WithMany("TrainingCentre")
                        .HasForeignKey("TypeId");
                });
        }
    }
}
