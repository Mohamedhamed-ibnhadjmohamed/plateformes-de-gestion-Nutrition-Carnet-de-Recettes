using SmartNutrition.Models;

namespace SmartNutrition.Services
{
    public interface IIngredientService
    {
        Task<IEnumerable<Ingredient>> GetAllIngredientsAsync();
        Task<Ingredient?> GetIngredientByIdAsync(int id);
        Task<IEnumerable<Ingredient>> GetIngredientsByUniteIdAsync(int uniteId);
        Task<Ingredient> CreateIngredientAsync(Ingredient ingredient);
        Task<Ingredient?> UpdateIngredientAsync(int id, Ingredient ingredient);
        Task<bool> DeleteIngredientAsync(int id);
        Task<bool> IngredientExistsAsync(int id);
        Task<IEnumerable<Ingredient>> SearchIngredientsAsync(string searchTerm);
    }
}
