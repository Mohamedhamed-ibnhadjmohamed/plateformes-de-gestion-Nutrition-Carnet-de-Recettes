using Microsoft.EntityFrameworkCore;
using SmartNutrition.Data;
using SmartNutrition.Models;

namespace SmartNutrition.Services
{
    public class CategorieService : ICategorieService
    {
        private readonly AppDbContext _context;

        public CategorieService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categorie>> GetAllCategoriesAsync()
        {
            return await _context.Categories
                .Include(c => c.Recettes)
                .OrderBy(c => c.Libelle)
                .ToListAsync();
        }

        public async Task<Categorie?> GetCategorieByIdAsync(int id)
        {
            return await _context.Categories
                .Include(c => c.Recettes)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Categorie> CreateCategorieAsync(Categorie categorie)
        {
            _context.Categories.Add(categorie);
            await _context.SaveChangesAsync();
            return categorie;
        }

        public async Task<Categorie?> UpdateCategorieAsync(int id, Categorie categorie)
        {
            var existingCategorie = await _context.Categories.FindAsync(id);
            if (existingCategorie == null)
                return null;

            existingCategorie.Libelle = categorie.Libelle;
            existingCategorie.Icone = categorie.Icone;

            try
            {
                await _context.SaveChangesAsync();
                return existingCategorie;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CategorieExistsAsync(id))
                    return null;
                throw;
            }
        }

        public async Task<bool> DeleteCategorieAsync(int id)
        {
            var categorie = await _context.Categories.FindAsync(id);
            if (categorie == null)
                return false;

            _context.Categories.Remove(categorie);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CategorieExistsAsync(int id)
        {
            return await _context.Categories.AnyAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Categorie>> SearchCategoriesAsync(string searchTerm)
        {
            return await _context.Categories
                .Include(c => c.Recettes)
                .Where(c => c.Libelle.Contains(searchTerm) || 
                           (c.Icone != null && c.Icone.Contains(searchTerm)))
                .OrderBy(c => c.Libelle)
                .ToListAsync();
        }
    }
}
