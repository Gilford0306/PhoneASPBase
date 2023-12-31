﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhoneASPBase.Controllers;

#nullable disable

namespace PhoneASPBase.Migrations
{
    [DbContext(typeof(PhoneContext))]
    partial class PhoneContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PhoneASPBase.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Baterry")
                        .HasColumnType("int");

                    b.Property<int>("Camera")
                        .HasColumnType("int");

                    b.Property<int>("Display")
                        .HasColumnType("int");

                    b.Property<int>("Memory")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("PhoneASPBase.Phone", b =>
                {
                    b.OwnsOne("PhoneASPBase.Brand", "Brand", b1 =>
                        {
                            b1.Property<int>("PhoneId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .HasColumnType("int");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PhoneId");

                            b1.ToTable("Brands");

                            b1.WithOwner()
                                .HasForeignKey("PhoneId");
                        });

                    b.Navigation("Brand")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
