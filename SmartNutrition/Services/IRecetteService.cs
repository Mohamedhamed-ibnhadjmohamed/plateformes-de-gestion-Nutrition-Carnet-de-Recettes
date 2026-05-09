using SmartNutrition.Models;

namespace SmartNutrition.Services
{
    public interface IRecetteService
    {
        Task<List<Recette>> GetRecettesAsync();
        Task<List<Ingredient>> GetIngredientsAsync();
        Task<List<Categorie>> GetCategoriesAsync();
        Task<List<TypeCuisine>> GetTypesCuisineAsync();
        Task<List<Unite>> GetUnitesAsync();
        Task<Recette?> GetRecetteByIdAsync(int id);
        Task<Ingredient?> GetIngredientByIdAsync(int id);
        Task AddRecetteAsync(Recette recette);
        Task AddIngredientAsync(Ingredient ingredient);
        Task UpdateRecetteAsync(Recette recette);
        Task UpdateIngredientAsync(Ingredient ingredient);
        Task DeleteRecetteAsync(int id);
        Task DeleteIngredientAsync(int id);
        
        // Méthodes pour RecetteIngredient
        Task<List<RecetteIngredient>> GetRecetteIngredientsAsync();
        Task<RecetteIngredient?> GetRecetteIngredientByIdAsync(int id);
        Task<List<RecetteIngredient>> GetRecetteIngredientsByRecetteIdAsync(int recetteId);
        Task AddRecetteIngredientAsync(RecetteIngredient recetteIngredient);
        Task UpdateRecetteIngredientAsync(RecetteIngredient recetteIngredient);
        Task DeleteRecetteIngredientAsync(int id);
    }
}
