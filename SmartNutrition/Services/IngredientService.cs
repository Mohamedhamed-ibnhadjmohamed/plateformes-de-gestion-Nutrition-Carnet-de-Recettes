using Microsoft.EntityFrameworkCore;
using SmartNutrition.Data;
using SmartNutrition.Models;

namespace SmartNutrition.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly AppDbContext _context;

        public IngredientService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ingredient>> GetAllIngredientsAsync()
        {
            return await _context.Ingredients
                .Include(i => i.Unite)
                .Include(i => i.RecetteIngredients)
                .OrderBy(i => i.Nom)
                .ToListAsync();
        }

        public async Task<Ingredient?> GetIngredientByIdAsync(int id)
        {
            return await _context.Ingredients
                .Include(i => i.Unite)
                .Include(i => i.RecetteIngredients)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Ingredient>> GetIngredientsByUniteIdAsync(int uniteId)
        {
            return await _context.Ingredients
                .Include(i => i.Unite)
                .Where(i => i.UniteId == uniteId)
                .OrderBy(i => i.Nom)
                .ToListAsync();
        }

        public async Task<Ingredient> CreateIngredientAsync(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();
            return ingredient;
        }

        public async Task<Ingredient?> UpdateIngredientAsync(int id, Ingredient ingredient)
        {
            var existingIngredient = await _context.Ingredients.FindAsync(id);
            if (existingIngredient == null)
                return null;

            existingIngredient.Nom = ingredient.Nom;
            existingIngredient.CaloriesParUnite = ingredient.CaloriesParUnite;
            existingIngredient.Proteines = ingredient.Proteines;
            existingIngredient.Glucides = ingredient.Glucides;
            existingIngredient.Lipides = ingredient.Lipides;
            existingIngredient.UniteId = ingredient.UniteId;

            try
            {
                await _context.SaveChangesAsync();
                return existingIngredient;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await IngredientExistsAsync(id))
                    return null;
                throw;
            }
        }

        public async Task<bool> DeleteIngredientAsync(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null)
                return false;

            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IngredientExistsAsync(int id)
        {
            return await _context.Ingredients.AnyAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Ingredient>> SearchIngredientsAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return await GetAllIngredientsAsync();

            return await _context.Ingredients
                .Include(i => i.Unite)
                .Include(i => i.RecetteIngredients)
                .Where(i => i.Nom.Contains(searchTerm) ||
                            (i.Unite != null && i.Unite.Libelle.Contains(searchTerm)))
                .OrderBy(i => i.Nom)
                .ToListAsync();
        }
    }
}
