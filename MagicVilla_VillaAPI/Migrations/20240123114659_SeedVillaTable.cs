using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVillaVillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "DateCreated", "Location", "Name", "Rate", "SqFt", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 23, 17, 16, 59, 418, DateTimeKind.Local).AddTicks(2120), "Chennai", "Royal Villa", 4200, 3550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 1, 23, 17, 16, 59, 418, DateTimeKind.Local).AddTicks(2140), "MGR Chennai", "Grand Villa", 2200, 4550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 1, 23, 17, 16, 59, 418, DateTimeKind.Local).AddTicks(2143), "Chennai ECR", "Luxury Villa", 1200, 1550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
