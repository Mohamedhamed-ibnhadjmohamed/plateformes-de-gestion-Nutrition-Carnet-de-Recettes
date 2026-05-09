using SmartNutrition.Data;
using SmartNutrition.Models;
using Microsoft.EntityFrameworkCore;

namespace SmartNutrition.Services
{
    public class RecetteService : IRecetteService
    {
        private readonly AppDbContext _dbContext;
        
        public RecetteService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Recette>> GetRecettesAsync()
        {
            return await _dbContext.Recettes
                .Include(r => r.Categorie)
                .Include(r => r.TypeCuisine)
                .Include(r => r.RecetteIngredients)
                    .ThenInclude(ri => ri.Ingredient)
                        .ThenInclude(i => i.Unite)
                .ToListAsync();
        }

        public async Task<List<Ingredient>> GetIngredientsAsync()
        {
            return await _dbContext.Ingredients
                .Include(i => i.Unite)
                .ToListAsync();
        }

        public async Task<List<Categorie>> GetCategoriesAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<List<TypeCuisine>> GetTypesCuisineAsync()
        {
            return await _dbContext.TypesCuisine.ToListAsync();
        }

        public async Task<List<Unite>> GetUnitesAsync()
        {
            return await _dbContext.Unites.ToListAsync();
        }

        public async Task<Recette?> GetRecetteByIdAsync(int id)
        {
            return await _dbContext.Recettes
                .Include(r => r.Categorie)
                .Include(r => r.TypeCuisine)
                .Include(r => r.RecetteIngredients)
                    .ThenInclude(ri => ri.Ingredient)
                        .ThenInclude(i => i.Unite)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Ingredient?> GetIngredientByIdAsync(int id)
        {
            return await _dbContext.Ingredients
                .Include(i => i.Unite)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task AddRecetteAsync(Recette recette)
        {
            _dbContext.Recettes.Add(recette);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddIngredientAsync(Ingredient ingredient)
        {
            _dbContext.Ingredients.Add(ingredient);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRecetteAsync(Recette recette)
        {
            _dbContext.Recettes.Update(recette);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateIngredientAsync(Ingredient ingredient)
        {
            _dbContext.Ingredients.Update(ingredient);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRecetteAsync(int id)
        {
            var recette = await _dbContext.Recettes.FindAsync(id);
            if (recette != null)
            {
                _dbContext.Recettes.Remove(recette);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteIngredientAsync(int id)
        {
            var ingredient = await _dbContext.Ingredients.FindAsync(id);
            if (ingredient != null)
            {
                _dbContext.Ingredients.Remove(ingredient);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
