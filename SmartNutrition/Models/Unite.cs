using System.ComponentModel.DataAnnotations;

namespace SmartNutrition.Models
{
    public class Unite
    {
        public int Id { get; set; }
        
        [Required, MaxLength(30)]
        public string Libelle { get; set; } // "Gramme", "Millilitre"
        
        [Required, MaxLength(10)]
        public string Symbole { get; set; } // "g", "ml", "pcs"
        
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}
