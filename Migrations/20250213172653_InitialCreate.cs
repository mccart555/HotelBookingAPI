using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.API.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Hotel",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                postcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                web_address = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_Hotel", x => x.id); });

        migrationBuilder.CreateTable(
            name: "Room",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                hotel_id = table.Column<int>(type: "int", nullable: false),
                capacity = table.Column<int>(type: "int", nullable: false),
                room_type = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Room", x => x.id);
                table.ForeignKey(
                    name: "FK_Room_Hotel_hotel_id",
                    column: x => x.hotel_id,
                    principalTable: "Hotel",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Booking",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                room_id = table.Column<int>(type: "int", nullable: false),
                title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                email_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                paid = table.Column<bool>(type: "bit", nullable: false),
                arrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                departure = table.Column<DateTime>(type: "datetime2", nullable: false),
                number_of_guests = table.Column<int>(type: "int", nullable: false),
                breakfast = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Booking", x => x.id);
                table.ForeignKey(
                    name: "FK_Booking_Room_room_id",
                    column: x => x.room_id,
                    principalTable: "Room",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Booking_room_id",
            table: "Booking",
            column: "room_id");

        migrationBuilder.CreateIndex(
            name: "IX_Room_hotel_id",
            table: "Room",
            column: "hotel_id");

        // Add a check constraint for RoomType
        migrationBuilder.Sql(
            "ALTER TABLE Room ADD CONSTRAINT CK_Room_RoomType CHECK (room_type IN ('Single', 'Double', 'Deluxe'))");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Booking");

        migrationBuilder.DropTable(
            name: "Room");

        migrationBuilder.DropTable(
            name: "Hotel");
    }
}

