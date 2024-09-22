using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MVCProjeKamp.UI.Controllers
{
    public class AboutController : Controller
    {
        AboutManager am = new AboutManager(new EFAboutDal());
        public IActionResult Index()
        {
            var abouts = am.GetList();
            return View(abouts);
        }

        [HttpGet]
        public IActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAbout(About p)
        {
            am.AboutAdd(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}
