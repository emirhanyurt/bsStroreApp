using entities.Models;

namespace services.Contracts
{
    public interface ICategoryService
    {


        Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);
        Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges);






    }
}
