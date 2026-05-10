using SmartNutrition.Models;

namespace SmartNutrition.Services
{
    public interface ICategorieService
    {
        Task<IEnumerable<Categorie>> GetAllCategoriesAsync();
        Task<Categorie?> GetCategorieByIdAsync(int id);
        Task<Categorie> CreateCategorieAsync(Categorie categorie);
        Task<Categorie?> UpdateCategorieAsync(int id, Categorie categorie);
        Task<bool> DeleteCategorieAsync(int id);
        Task<bool> CategorieExistsAsync(int id);
        Task<IEnumerable<Categorie>> SearchCategoriesAsync(string searchTerm);
    }
}
