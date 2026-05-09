using SmartNutrition.Models;

namespace SmartNutrition.Services
{
    public interface IUniteService
    {
        Task<IEnumerable<Unite>> GetAllUnitesAsync();
        Task<Unite?> GetUniteByIdAsync(int id);
        Task<Unite> CreateUniteAsync(Unite unite);
        Task<Unite?> UpdateUniteAsync(int id, Unite unite);
        Task<bool> DeleteUniteAsync(int id);
        Task<bool> UniteExistsAsync(int id);
    }
}
