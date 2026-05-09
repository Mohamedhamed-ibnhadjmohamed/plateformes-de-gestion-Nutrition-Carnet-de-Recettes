using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartNutrition.Migrations
{
    /// <inheritdoc />
    public partial class AddUniteToRecetteIngredient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UniteId",
                table: "RecetteIngredients",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RecetteIngredients_UniteId",
                table: "RecetteIngredients",
                column: "UniteId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecetteIngredients_Unites_UniteId",
                table: "RecetteIngredients",
                column: "UniteId",
                principalTable: "Unites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecetteIngredients_Unites_UniteId",
                table: "RecetteIngredients");

            migrationBuilder.DropIndex(
                name: "IX_RecetteIngredients_UniteId",
                table: "RecetteIngredients");

            migrationBuilder.DropColumn(
                name: "UniteId",
                table: "RecetteIngredients");
        }
    }
}
