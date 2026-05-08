using System.ComponentModel.DataAnnotations;

namespace SmartNutrition.Models
{
    public class TypeCuisine
    {
        public int Id { get; set; }
        
        [Required, MaxLength(60)]
        public string Libelle { get; set; } // "Tunisienne", "Française"…
        
        public string? Pays { get; set; } // "Tunisie", "France"…
        
        public ICollection<Recette> Recettes { get; set; } = new List<Recette>();
    }
}
