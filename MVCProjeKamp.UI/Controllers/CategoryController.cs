using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MVCProjeKamp.UI.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager();

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult GetCategoryList()
        {
            var categories = cm.GetAllBl();
            return View(categories);
        }
    }
}
