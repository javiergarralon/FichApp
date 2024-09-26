using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FichApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAndSeedTimesheetTable : Migration
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
                    { 1, new DateTime(2024, 9, 26, 13, 24, 30, 499, DateTimeKind.Local).AddTicks(3653), null, new TimeSpan(0, 0, 0, 0, 0) },
                    { 2, null, new DateTime(2024, 9, 26, 18, 24, 53, 499, DateTimeKind.Local).AddTicks(3701), new TimeSpan(0, 5, 0, 23, 0) },
                    { 3, new DateTime(2024, 9, 26, 13, 24, 30, 499, DateTimeKind.Local).AddTicks(3706), null, new TimeSpan(0, 5, 0, 23, 0) }
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
