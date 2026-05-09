using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartNutrition.Migrations
{
    /// <inheritdoc />
    public partial class SimplifyModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreation",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "DateModification",
                table: "Ingredients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreation",
                table: "Ingredients",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModification",
                table: "Ingredients",
                type: "TEXT",
                nullable: true);
        }
    }
}
