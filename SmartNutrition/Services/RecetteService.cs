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

        // Méthodes pour RecetteIngredient
        public async Task<List<RecetteIngredient>> GetRecetteIngredientsAsync()
        {
            return await _dbContext.RecetteIngredients
                .Include(ri => ri.Recette)
                .Include(ri => ri.Ingredient)
                .Include(ri => ri.Unite)
                .ToListAsync();
        }

        public async Task<RecetteIngredient?> GetRecetteIngredientByIdAsync(int id)
        {
            return await _dbContext.RecetteIngredients
                .Include(ri => ri.Recette)
                .Include(ri => ri.Ingredient)
                .Include(ri => ri.Unite)
                .FirstOrDefaultAsync(ri => ri.Id == id);
        }

        public async Task<List<RecetteIngredient>> GetRecetteIngredientsByRecetteIdAsync(int recetteId)
        {
            return await _dbContext.RecetteIngredients
                .Include(ri => ri.Recette)
                .Include(ri => ri.Ingredient)
                .Include(ri => ri.Unite)
                .Where(ri => ri.RecetteId == recetteId)
                .ToListAsync();
        }

        public async Task AddRecetteIngredientAsync(RecetteIngredient recetteIngredient)
        {
            _dbContext.RecetteIngredients.Add(recetteIngredient);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRecetteIngredientAsync(RecetteIngredient recetteIngredient)
        {
            _dbContext.RecetteIngredients.Update(recetteIngredient);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRecetteIngredientAsync(int id)
        {
            var recetteIngredient = await _dbContext.RecetteIngredients.FindAsync(id);
            if (recetteIngredient != null)
            {
                _dbContext.RecetteIngredients.Remove(recetteIngredient);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Recette>> SearchRecettesAsync(string searchTerm)
        {
            return await _dbContext.Recettes
                .Include(r => r.Categorie)
                .Include(r => r.TypeCuisine)
                .Where(r => r.Nom.Contains(searchTerm))
                .OrderBy(r => r.Nom)
                .ToListAsync();
        }
    }
}
