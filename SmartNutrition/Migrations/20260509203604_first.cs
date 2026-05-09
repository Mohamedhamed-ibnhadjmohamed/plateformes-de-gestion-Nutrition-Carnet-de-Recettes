using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartNutrition.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Icone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesCuisine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Pays = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesCuisine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Symbole = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recettes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    NbPersonnes = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DureePreparation = table.Column<int>(type: "INTEGER", nullable: true),
                    CategorieId = table.Column<int>(type: "INTEGER", nullable: false),
                    TypeCuisineId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recettes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recettes_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recettes_TypesCuisine_TypeCuisineId",
                        column: x => x.TypeCuisineId,
                        principalTable: "TypesCuisine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CaloriesParUnite = table.Column<double>(type: "REAL", nullable: false),
                    Proteines = table.Column<double>(type: "REAL", nullable: true),
                    Glucides = table.Column<double>(type: "REAL", nullable: true),
                    Lipides = table.Column<double>(type: "REAL", nullable: true),
                    UniteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Unites_UniteId",
                        column: x => x.UniteId,
                        principalTable: "Unites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecetteIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RecetteId = table.Column<int>(type: "INTEGER", nullable: false),
                    IngredientId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantite = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecetteIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecetteIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecetteIngredients_Recettes_RecetteId",
                        column: x => x.RecetteId,
                        principalTable: "Recettes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Icone", "Libelle" },
                values: new object[,]
                {
                    { 1, "🌅", "Petit-déjeuner" },
                    { 2, "☀️", "Déjeuner" },
                    { 3, "🌙", "Dîner" },
                    { 4, "🍰", "Dessert" }
                });

            migrationBuilder.InsertData(
                table: "TypesCuisine",
                columns: new[] { "Id", "Libelle", "Pays" },
                values: new object[,]
                {
                    { 1, "Tunisienne", "Tunisie" },
                    { 2, "Française", "France" },
                    { 3, "Italienne", "Italie" },
                    { 4, "Méditerranéenne", "Méditerranée" }
                });

            migrationBuilder.InsertData(
                table: "Unites",
                columns: new[] { "Id", "Libelle", "Symbole" },
                values: new object[,]
                {
                    { 1, "Gramme", "g" },
                    { 2, "Kilogramme", "kg" },
                    { 3, "Millilitre", "ml" },
                    { 4, "Centilitre", "cl" },
                    { 5, "Pièce", "pcs" },
                    { 6, "Cuillère à soupe", "c.s" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_UniteId",
                table: "Ingredients",
                column: "UniteId");

            migrationBuilder.CreateIndex(
                name: "IX_RecetteIngredients_IngredientId",
                table: "RecetteIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecetteIngredients_RecetteId",
                table: "RecetteIngredients",
                column: "RecetteId");

            migrationBuilder.CreateIndex(
                name: "IX_Recettes_CategorieId",
                table: "Recettes",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Recettes_TypeCuisineId",
                table: "Recettes",
                column: "TypeCuisineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecetteIngredients");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recettes");

            migrationBuilder.DropTable(
                name: "Unites");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "TypesCuisine");
        }
    }
}
