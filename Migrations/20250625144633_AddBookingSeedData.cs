using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Enskilt_Projektarbete.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CourtNumber", "CustomerId", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2025, 6, 26, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 26, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 2, new DateTime(2025, 6, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 26, 14, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
