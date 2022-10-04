using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourHotel.Migrations
{
    public partial class correcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Bookings_BookingId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethods_Bookings_BookingId",
                table: "PaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethods_BookingId",
                table: "PaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_Clients_BookingId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "PaymentMethodsId",
                table: "Bookings",
                newName: "PaymentMethodId");

            migrationBuilder.RenameColumn(
                name: "ClientsId",
                table: "Bookings",
                newName: "ClientId");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clients",
                type: "varchar(80)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(80)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckOutDate",
                table: "Bookings",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckInDate",
                table: "Bookings",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ClientId",
                table: "Bookings",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PaymentMethodId",
                table: "Bookings",
                column: "PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Clients_ClientId",
                table: "Bookings",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_PaymentMethods_PaymentMethodId",
                table: "Bookings",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Clients_ClientId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_PaymentMethods_PaymentMethodId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ClientId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_PaymentMethodId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "PaymentMethodId",
                table: "Bookings",
                newName: "PaymentMethodsId");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Bookings",
                newName: "ClientsId");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "PaymentMethods",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Email",
                keyValue: null,
                column: "Email",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clients",
                type: "varchar(80)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(80)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckOutDate",
                table: "Bookings",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckInDate",
                table: "Bookings",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_BookingId",
                table: "PaymentMethods",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_BookingId",
                table: "Clients",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Bookings_BookingId",
                table: "Clients",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethods_Bookings_BookingId",
                table: "PaymentMethods",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }
    }
}
