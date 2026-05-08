using System.ComponentModel.DataAnnotations;

namespace SmartNutrition.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        
        [Required, MaxLength(100)]
        public string Nom { get; set; }
        
        [Range(0, 9000)]
        public double CaloriesParUnite { get; set; }
        
        // Macronutriments optionnels
        public double? Proteines { get; set; }
        public double? Glucides { get; set; }
        public double? Lipides { get; set; }
        
        // FK → Unite
        [Required]
        public int UniteId { get; set; }
        public Unite Unite { get; set; }
        
        // Navigation property
        public ICollection<RecetteIngredient> RecetteIngredients { get; set; } = new List<RecetteIngredient>();
    }
}
