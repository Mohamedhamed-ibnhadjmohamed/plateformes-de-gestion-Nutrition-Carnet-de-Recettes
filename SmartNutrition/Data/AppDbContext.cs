using Microsoft.EntityFrameworkCore;
using SmartNutrition.Models;

namespace SmartNutrition.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // ── Tables principales ──────────────────────────
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recette> Recettes { get; set; }
        public DbSet<RecetteIngredient> RecetteIngredients { get; set; }

        // ── Tables de référence ─────────────────────────
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<TypeCuisine> TypesCuisine { get; set; }
        public DbSet<Unite> Unites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ── Relations RecetteIngredient ─────────────
            modelBuilder.Entity<RecetteIngredient>()
                .HasOne(ri => ri.Recette)
                .WithMany(r => r.RecetteIngredients)
                .HasForeignKey(ri => ri.RecetteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RecetteIngredient>()
                .HasOne(ri => ri.Ingredient)
                .WithMany(i => i.RecetteIngredients)
                .HasForeignKey(ri => ri.IngredientId)
                .OnDelete(DeleteBehavior.Restrict);

            // ── Relations Recette → Categorie / TypeCuisine
            modelBuilder.Entity<Recette>()
                .HasOne(r => r.Categorie)
                .WithMany(c => c.Recettes)
                .HasForeignKey(r => r.CategorieId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Recette>()
                .HasOne(r => r.TypeCuisine)
                .WithMany(tc => tc.Recettes)
                .HasForeignKey(r => r.TypeCuisineId)
                .OnDelete(DeleteBehavior.Restrict);

            // ── Relation Ingredient → Unite ─────────────
            modelBuilder.Entity<Ingredient>()
                .HasOne(i => i.Unite)
                .WithMany(u => u.Ingredients)
                .HasForeignKey(i => i.UniteId)
                .OnDelete(DeleteBehavior.Restrict);

            // ── Seed — données initiales ────────────────
            modelBuilder.Entity<Categorie>().HasData(
                new Categorie { Id = 1, Libelle = "Petit-déjeuner", Icone = "🌅" },
                new Categorie { Id = 2, Libelle = "Déjeuner", Icone = "☀️" },
                new Categorie { Id = 3, Libelle = "Dîner", Icone = "🌙" },
                new Categorie { Id = 4, Libelle = "Dessert", Icone = "🍰" }
            );

            modelBuilder.Entity<TypeCuisine>().HasData(
                new TypeCuisine { Id = 1, Libelle = "Tunisienne", Pays = "Tunisie" },
                new TypeCuisine { Id = 2, Libelle = "Française", Pays = "France" },
                new TypeCuisine { Id = 3, Libelle = "Italienne", Pays = "Italie" },
                new TypeCuisine { Id = 4, Libelle = "Méditerranéenne", Pays = "Méditerranée" }
            );

            modelBuilder.Entity<Unite>().HasData(
                new Unite { Id = 1, Libelle = "Gramme", Symbole = "g" },
                new Unite { Id = 2, Libelle = "Kilogramme", Symbole = "kg" },
                new Unite { Id = 3, Libelle = "Millilitre", Symbole = "ml" },
                new Unite { Id = 4, Libelle = "Centilitre", Symbole = "cl" },
                new Unite { Id = 5, Libelle = "Pièce", Symbole = "pcs" },
                new Unite { Id = 6, Libelle = "Cuillère à soupe", Symbole = "c.s" }
            );
        }
    }
}
