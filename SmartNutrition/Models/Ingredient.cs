using System.ComponentModel.DataAnnotations;

namespace SmartNutrition.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        
        [Required]
        public string Nom { get; set; }
        
        public double CaloriesParUnite { get; set; }
        
        // Navigation property
        public ICollection<RecetteIngredient> RecetteIngredients { get; set; }
    }
}
