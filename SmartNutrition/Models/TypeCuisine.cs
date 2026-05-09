using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartNutrition.Models
{
    public class TypeCuisine
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Le libellé est obligatoire")]
        [MaxLength(60, ErrorMessage = "Le libellé ne peut pas dépasser 60 caractères")]
        [Display(Name = "Libellé")]
        public string Libelle { get; set; } = string.Empty;
        
        [MaxLength(100, ErrorMessage = "Le pays ne peut pas dépasser 100 caractères")]
        [Display(Name = "Pays d'origine")]
        public string? Pays { get; set; }
        
        [Display(Name = "Date de création")]
        public DateTime DateCreation { get; set; } = DateTime.Now;
        
        [Display(Name = "Date de modification")]
        public DateTime? DateModification { get; set; }
        
        // Propriété calculée pour l'affichage
        [NotMapped]
        public string Affichage => !string.IsNullOrEmpty(Pays) ? $"{Libelle} ({Pays})" : Libelle;
        
        // Propriété calculée pour le nombre de recettes
        [NotMapped]
        public int NombreRecettes => Recettes?.Count ?? 0;
        
        // Navigation property
        public ICollection<Recette> Recettes { get; set; } = new List<Recette>();
        
        // Méthode pour mettre à jour la date de modification
        public void MettreAJourDateModification()
        {
            DateModification = DateTime.Now;
        }
    }
}
