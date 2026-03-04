using System.ComponentModel.DataAnnotations;

namespace SmartNutrition.Models
{
    public class Recette
    {
        public int Id { get; set; }
        
        [Required]
        public string Nom { get; set; }
        
        public int NbPersonnes { get; set; }
        
        public string Categorie { get; set; } // "Petit-déjeuner" | "Déjeuner" | "Dîner" | "Dessert"
        
        public string TypeCuisine { get; set; } // "Tunisienne" | "Française" | "Italienne" | "Méditerranéenne"
        
        public ICollection<RecetteIngredient> RecetteIngredients { get; set; }
    }
}
