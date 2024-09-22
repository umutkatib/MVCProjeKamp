using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MVCProjeKamp.UI.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDal());
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ContentByHeading(int id)
        {
            var contents = cm.GetListWithInclude(id);
            return View(contents);
        }

    }
}
