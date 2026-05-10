using Microsoft.EntityFrameworkCore;
using SmartNutrition.Data;
using SmartNutrition.Models;

namespace SmartNutrition.Services
{
    public class UniteService : IUniteService
    {
        private readonly AppDbContext _context;

        public UniteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Unite>> GetAllUnitesAsync()
        {
            return await _context.Unites
                .OrderBy(u => u.Libelle)
                .ToListAsync();
        }

        public async Task<Unite?> GetUniteByIdAsync(int id)
        {
            return await _context.Unites
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Unite> CreateUniteAsync(Unite unite)
        {
            _context.Unites.Add(unite);
            await _context.SaveChangesAsync();
            return unite;
        }

        public async Task<Unite?> UpdateUniteAsync(int id, Unite unite)
        {
            var existingUnite = await _context.Unites.FindAsync(id);
            if (existingUnite == null)
                return null;

            existingUnite.Libelle = unite.Libelle;
            existingUnite.Symbole = unite.Symbole;

            await _context.SaveChangesAsync();
            return existingUnite;
        }

        public async Task<bool> DeleteUniteAsync(int id)
        {
            var unite = await _context.Unites.FindAsync(id);
            if (unite == null)
                return false;

            // Vérifier si des ingrédients utilisent cette unité
            var hasIngredients = await _context.Ingredients
                .AnyAsync(i => i.UniteId == id);

            if (hasIngredients)
                throw new InvalidOperationException("Impossible de supprimer cette unité car elle est utilisée par des ingrédients");

            _context.Unites.Remove(unite);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UniteExistsAsync(int id)
        {
            return await _context.Unites.AnyAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Unite>> SearchUnitesAsync(string searchTerm)
        {
            return await _context.Unites
                .Where(u => u.Libelle.Contains(searchTerm) || 
                            u.Symbole.Contains(searchTerm))
                .OrderBy(u => u.Libelle)
                .ToListAsync();
        }
    }
}
