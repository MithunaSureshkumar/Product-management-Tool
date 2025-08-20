using EcommerceApp.Entities;
using EcommerceApp.Repository;

namespace EcommerceApp.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryService()
        {
            _categoryRepository = new CategoryRepository();
        }

        public void AddCategory(Category category)
        {
            _categoryRepository.AddCategory(category);
        }

        public void DeleteCategory(int categoryId)
        {
            _categoryRepository.DeleteCategory(categoryId);
        }

        public List<Category> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }
    }
}

