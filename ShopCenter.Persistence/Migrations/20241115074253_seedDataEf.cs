using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopCenter.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seedDataEf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 15, 11, 12, 51, 371, DateTimeKind.Local).AddTicks(8475), "Elh@m3605", "Vacations" },
                    { 2, new DateTime(2024, 11, 15, 11, 12, 51, 382, DateTimeKind.Local).AddTicks(1047), "123456", "Eli" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
