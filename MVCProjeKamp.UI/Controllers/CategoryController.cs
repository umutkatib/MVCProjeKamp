using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace MVCProjeKamp.UI.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCategoryList()
        {
            var categories = cm.GetList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult validationResult = validationRules.Validate(p);

            if (validationResult.IsValid)
            {
                cm.CategoryAddBL(p);
            return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach(var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
    }
}
