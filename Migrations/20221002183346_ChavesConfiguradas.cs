using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourHotel.Migrations
{
    public partial class ChavesConfiguradas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeRoomId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "PaymentMethods",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientsId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethodsId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookingRoom",
                columns: table => new
                {
                    BookingsId = table.Column<int>(type: "int", nullable: false),
                    RoomsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingRoom", x => new { x.BookingsId, x.RoomsId });
                    table.ForeignKey(
                        name: "FK_BookingRoom_Bookings_BookingsId",
                        column: x => x.BookingsId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingRoom_Rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_TypeRoomId",
                table: "Rooms",
                column: "TypeRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_BookingId",
                table: "PaymentMethods",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_BookingId",
                table: "Clients",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRoom_RoomsId",
                table: "BookingRoom",
                column: "RoomsId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_TypeRooms_TypeRoomId",
                table: "Rooms",
                column: "TypeRoomId",
                principalTable: "TypeRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Bookings_BookingId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethods_Bookings_BookingId",
                table: "PaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_TypeRooms_TypeRoomId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "BookingRoom");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_TypeRoomId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethods_BookingId",
                table: "PaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_Clients_BookingId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "TypeRoomId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ClientsId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PaymentMethodsId",
                table: "Bookings");
        }
    }
}
