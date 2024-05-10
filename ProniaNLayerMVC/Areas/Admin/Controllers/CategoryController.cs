using Microsoft.AspNetCore.Mvc;
using Pronia.Bussiness.Services.Abstracts;
using Pronia.Core.Models;

namespace ProniaNLayerMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public IActionResult Index()
        {
            var categories = _categoryServices.GetAllCategories();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)

                return View();
            _categoryServices.AddCategory(category);
            return RedirectToAction("Index");


        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var category = _categoryServices.GetCategory(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            _categoryServices.DeleteCategory(id);
            return RedirectToAction("Index");
        }

    }
}
