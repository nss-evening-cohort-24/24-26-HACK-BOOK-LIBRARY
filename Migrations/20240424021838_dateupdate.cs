using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _24HackBookLibrary.Migrations
{
    public partial class dateupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePosted",
                value: new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DatePosted",
                value: new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DatePosted",
                value: new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "DatePosted",
                value: new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "DatePosted",
                value: new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "DatePosted",
                value: new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "DatePosted",
                value: new DateTime(2024, 3, 11, 0, 0, 0, 0, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePosted",
                value: new DateTime(2024, 3, 5, 0, 2, 48, 848, DateTimeKind.Utc).AddTicks(1170));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DatePosted",
                value: new DateTime(2024, 4, 3, 0, 2, 48, 848, DateTimeKind.Utc).AddTicks(1177));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DatePosted",
                value: new DateTime(2024, 2, 22, 0, 2, 48, 848, DateTimeKind.Utc).AddTicks(1178));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "DatePosted",
                value: new DateTime(2024, 3, 12, 0, 2, 48, 848, DateTimeKind.Utc).AddTicks(1179));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "DatePosted",
                value: new DateTime(2024, 3, 13, 0, 2, 48, 848, DateTimeKind.Utc).AddTicks(1180));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "DatePosted",
                value: new DateTime(2024, 4, 14, 0, 2, 48, 848, DateTimeKind.Utc).AddTicks(1181));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "DatePosted",
                value: new DateTime(2024, 4, 22, 0, 2, 48, 848, DateTimeKind.Utc).AddTicks(1182));
        }
    }
}
