﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YourHotel.Data;

#nullable disable

namespace YourHotel.Migrations
{
    [DbContext(typeof(ContextBD))]
    [Migration("20221004002622_correcao")]
    partial class correcao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BookingRoom", b =>
                {
                    b.Property<int>("BookingsId")
                        .HasColumnType("int");

                    b.Property<int>("RoomsId")
                        .HasColumnType("int");

                    b.HasKey("BookingsId", "RoomsId");

                    b.HasIndex("RoomsId");

                    b.ToTable("BookingRoom");
                });

            modelBuilder.Entity("YourHotel.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CheckInDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("CheckOutDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(13,2)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ReservationFinalDate")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("ReservationValue")
                        .HasColumnType("decimal(13,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("PaymentMethodId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("YourHotel.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("YourHotel.Models.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("YourHotel.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(13,2)");

                    b.Property<bool>("Reserved")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("TypeRoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeRoomId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("YourHotel.Models.TypeRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("TypeRooms");
                });

            modelBuilder.Entity("BookingRoom", b =>
                {
                    b.HasOne("YourHotel.Models.Booking", null)
                        .WithMany()
                        .HasForeignKey("BookingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YourHotel.Models.Room", null)
                        .WithMany()
                        .HasForeignKey("RoomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YourHotel.Models.Booking", b =>
                {
                    b.HasOne("YourHotel.Models.Client", "Client")
                        .WithMany("Bookings")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YourHotel.Models.PaymentMethod", "PaymentMethod")
                        .WithMany("Bookings")
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("PaymentMethod");
                });

            modelBuilder.Entity("YourHotel.Models.Room", b =>
                {
                    b.HasOne("YourHotel.Models.TypeRoom", "TypeRoom")
                        .WithMany("Rooms")
                        .HasForeignKey("TypeRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeRoom");
                });

            modelBuilder.Entity("YourHotel.Models.Client", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("YourHotel.Models.PaymentMethod", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("YourHotel.Models.TypeRoom", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
