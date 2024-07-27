

using entities.Exceptions;
using entities.Models;
using repositories.Contracts;
using services.Contracts;

namespace services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;
        public CategoryManager(IRepositoryManager manager)
        {
            _manager = manager;
        }



        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
        {
            return await _manager.Category.GetAllCategoryAsync(trackChanges);
        }

        public async Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges)
        {
            var category= await _manager.Category.GetOneCategoryByIdAsync(id, trackChanges);
            if (category == null)
            {
                throw new CategoryNotFoundException(id);
            }
            return category;
        }

      
    }
}
