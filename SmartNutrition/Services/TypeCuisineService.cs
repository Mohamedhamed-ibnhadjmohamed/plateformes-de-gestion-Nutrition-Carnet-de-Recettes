using Microsoft.EntityFrameworkCore;
using SmartNutrition.Data;
using SmartNutrition.Models;

namespace SmartNutrition.Services
{
    public class TypeCuisineService : ITypeCuisineService
    {
        private readonly AppDbContext _context;

        public TypeCuisineService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TypeCuisine>> GetAllTypesCuisineAsync()
        {
            return await _context.TypesCuisine
                .Include(tc => tc.Recettes)
                .OrderBy(tc => tc.Libelle)
                .ToListAsync();
        }

        public async Task<TypeCuisine?> GetTypeCuisineByIdAsync(int id)
        {
            return await _context.TypesCuisine
                .Include(tc => tc.Recettes)
                .FirstOrDefaultAsync(tc => tc.Id == id);
        }

        public async Task<TypeCuisine> CreateTypeCuisineAsync(TypeCuisine typeCuisine)
        {
            typeCuisine.DateCreation = DateTime.Now;
            _context.TypesCuisine.Add(typeCuisine);
            await _context.SaveChangesAsync();
            return typeCuisine;
        }

        public async Task<TypeCuisine?> UpdateTypeCuisineAsync(int id, TypeCuisine typeCuisine)
        {
            var existingTypeCuisine = await _context.TypesCuisine.FindAsync(id);
            if (existingTypeCuisine == null)
                return null;

            existingTypeCuisine.Libelle = typeCuisine.Libelle;
            existingTypeCuisine.Pays = typeCuisine.Pays;
            existingTypeCuisine.DateModification = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
                return existingTypeCuisine;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TypeCuisineExistsAsync(id))
                    return null;
                throw;
            }
        }

        public async Task<bool> DeleteTypeCuisineAsync(int id)
        {
            var typeCuisine = await _context.TypesCuisine.FindAsync(id);
            if (typeCuisine == null)
                return false;

            _context.TypesCuisine.Remove(typeCuisine);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> TypeCuisineExistsAsync(int id)
        {
            return await _context.TypesCuisine.AnyAsync(tc => tc.Id == id);
        }
    }
}
