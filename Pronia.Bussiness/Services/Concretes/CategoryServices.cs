using Pronia.Bussiness.Exceptions;
using Pronia.Bussiness.Services.Abstracts;
using Pronia.Core.Models;
using Pronia.Core.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Bussiness.Services.Concretes
{
    public class CategoryServices : ICategoryServices
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void AddCategory(Category category)
        {
            if (category == null) throw new NullReferenceException("null ola bilmez");
            if (!_categoryRepository.GetAll().Any(x => x.Name == category.Name))
            {
                _categoryRepository.Add(category);
                _categoryRepository.Commit();

            }
            else
            {
                throw new DuplicateCategoryException("eyni adda ikinci category olmaz");
            }
        }

        public void DeleteCategory(int id)
        {
            var existCategory = _categoryRepository.Get(x => x.Id == id);
            if (existCategory == null) throw new NullReferenceException("null ola bilmez");
            _categoryRepository.Delete(existCategory);
            _categoryRepository.Commit();

        }

        public List<Category> GetAllCategories(Func<Category, bool>? func = null)
        {
            return _categoryRepository.GetAll(func);
        }

        public Category GetCategory(Func<Category, bool>? func = null)
        {
            return _categoryRepository.Get(func);

        }

        public void UpdateCategory(int id, Category newCategory)
        {
            var existCategory = _categoryRepository.Get(x => x.Id == id);
            if (existCategory == null) throw new NullReferenceException("null ola bilmez");
            if (!_categoryRepository.GetAll().Any(x => x.Name == newCategory.Name))
            {
                existCategory.Name = newCategory.Name;
                _categoryRepository.Commit();
            }
            else
            {
                throw new DuplicateCategoryException("category adi eyni ola bilmez");
            }

        }
    
    }
}
