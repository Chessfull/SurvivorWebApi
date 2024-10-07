using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SurvivorWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddingSampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 7, 14, 46, 7, 648, DateTimeKind.Local).AddTicks(7677), false, new DateTime(2024, 10, 7, 14, 46, 7, 648, DateTimeKind.Local).AddTicks(7687), "Celebrities" },
                    { 2, new DateTime(2024, 10, 7, 14, 46, 7, 648, DateTimeKind.Local).AddTicks(7693), false, new DateTime(2024, 10, 7, 14, 46, 7, 648, DateTimeKind.Local).AddTicks(7693), "Volunteers" }
                });

            migrationBuilder.InsertData(
                table: "Competitors",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "FirstName", "IsDeleted", "LastName", "ModifiedDate" },
                values: new object[] { 1, 2, new DateTime(2024, 10, 7, 14, 46, 7, 648, DateTimeKind.Local).AddTicks(7800), "Mert", false, "Topcu", new DateTime(2024, 10, 7, 14, 46, 7, 648, DateTimeKind.Local).AddTicks(7800) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Competitors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
