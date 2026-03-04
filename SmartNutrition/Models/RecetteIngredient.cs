namespace SmartNutrition.Models
{
    public class RecetteIngredient
    {
        public int Id { get; set; }
        
        public int RecetteId { get; set; }
        public Recette Recette { get; set; }
        
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        
        public double Quantite { get; set; }
    }
}
