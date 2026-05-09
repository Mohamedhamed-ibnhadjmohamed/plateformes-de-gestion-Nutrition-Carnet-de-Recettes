using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartNutrition.Migrations
{
    /// <inheritdoc />
    public partial class AddTypeCuisineDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreation",
                table: "TypesCuisine",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModification",
                table: "TypesCuisine",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TypesCuisine",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreation", "DateModification" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "TypesCuisine",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreation", "DateModification" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "TypesCuisine",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreation", "DateModification" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "TypesCuisine",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreation", "DateModification" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreation",
                table: "TypesCuisine");

            migrationBuilder.DropColumn(
                name: "DateModification",
                table: "TypesCuisine");
        }
    }
}
