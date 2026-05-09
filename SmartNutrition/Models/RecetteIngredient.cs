using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartNutrition.Models
{
    public class RecetteIngredient
    {
        public int Id { get; set; }
        
        public int RecetteId { get; set; }
        public Recette Recette { get; set; }
        
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        
        public int UniteId { get; set; }
        public Unite Unite { get; set; }
        
        [Range(0.01, 10000)]
        public double Quantite { get; set; }
        
        // Propriété calculée pour l'affichage
        [NotMapped]
        public string Affichage => $"{Quantite} {Unite?.Symbole} {Ingredient?.Nom}";
    }
}
