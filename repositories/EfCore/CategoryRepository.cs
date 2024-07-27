using entites.Models;
using entities.Models;
using Microsoft.EntityFrameworkCore;
using repositories.Contracts;
using repositories.EfCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repositories.EfCore
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneCategory(Category category)
        => Create(category);

        public void DeleteOneCategory(Category category)
        => Delete(category);

        public async Task<IEnumerable<Category>> GetAllCategoryAsync(bool trackChanges)
        => await FindAll(trackChanges)
            .OrderBy(c => c.CategoryName)
            .ToListAsync();

        public async Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges)
       => await FindByCondition(c => c.CategoryId.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void UpdateOneCategory(Category category)
        => Update(category);
    }
}
