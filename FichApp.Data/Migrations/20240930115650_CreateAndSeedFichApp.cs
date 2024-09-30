using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FichApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateAndSeedFichApp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Timesheets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Checkout = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Checkin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeSpent = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timesheets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Timesheets",
                columns: new[] { "Id", "Checkin", "Checkout", "TimeSpent" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 30, 13, 56, 49, 720, DateTimeKind.Local).AddTicks(8726), null, new TimeSpan(0, 0, 0, 0, 0) },
                    { 2, new DateTime(2024, 9, 30, 13, 56, 49, 720, DateTimeKind.Local).AddTicks(8794), new DateTime(2024, 9, 30, 18, 57, 12, 720, DateTimeKind.Local).AddTicks(8795), new TimeSpan(0, 5, 0, 23, 0) },
                    { 3, new DateTime(2024, 9, 30, 13, 56, 49, 720, DateTimeKind.Local).AddTicks(8800), null, new TimeSpan(0, 5, 0, 23, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Timesheets");
        }
    }
}
