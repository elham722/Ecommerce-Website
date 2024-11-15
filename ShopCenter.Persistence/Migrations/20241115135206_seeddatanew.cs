using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopCenter.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seeddatanew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 11, 15, 17, 22, 5, 759, DateTimeKind.Local).AddTicks(4822));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 11, 15, 17, 22, 5, 760, DateTimeKind.Local).AddTicks(2885));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 11, 15, 11, 12, 51, 371, DateTimeKind.Local).AddTicks(8475));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 11, 15, 11, 12, 51, 382, DateTimeKind.Local).AddTicks(1047));
        }
    }
}
