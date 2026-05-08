using System.ComponentModel.DataAnnotations;

namespace SmartNutrition.Models
{
    public class Recette
    {
        public int Id { get; set; }
        
        [Required, MaxLength(120)]
        public string Nom { get; set; }
        
        [Range(1, 100)]
        public int NbPersonnes { get; set; }
        
        public string? Description { get; set; }
        
        [Range(1, 600)]
        public int? DureePreparation { get; set; } // en minutes
        
        // FK → Categorie (remplace string Categorie)
        [Required]
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }
        
        // FK → TypeCuisine (remplace string TypeCuisine)
        [Required]
        public int TypeCuisineId { get; set; }
        public TypeCuisine TypeCuisine { get; set; }
        
        public ICollection<RecetteIngredient> RecetteIngredients { get; set; } = new List<RecetteIngredient>();
    }
}
