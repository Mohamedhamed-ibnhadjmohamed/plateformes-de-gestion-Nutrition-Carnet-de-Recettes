using SmartNutrition.Models;

namespace SmartNutrition.Services
{
    public interface ITypeCuisineService
    {
        Task<IEnumerable<TypeCuisine>> GetAllTypesCuisineAsync();
        Task<TypeCuisine?> GetTypeCuisineByIdAsync(int id);
        Task<TypeCuisine> CreateTypeCuisineAsync(TypeCuisine typeCuisine);
        Task<TypeCuisine?> UpdateTypeCuisineAsync(int id, TypeCuisine typeCuisine);
        Task<bool> DeleteTypeCuisineAsync(int id);
        Task<bool> TypeCuisineExistsAsync(int id);
    }
}
