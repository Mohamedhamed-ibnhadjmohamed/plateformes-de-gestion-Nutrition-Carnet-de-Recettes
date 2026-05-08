using System.ComponentModel.DataAnnotations;

namespace SmartNutrition.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        
        [Required, MaxLength(50)]
        public string Libelle { get; set; } // "Déjeuner", "Dîner"…
        
        public string? Icone { get; set; } // "☀️", "🌙"…
        
        // Navigation property
        public ICollection<Recette> Recettes { get; set; } = new List<Recette>();
    }
}
