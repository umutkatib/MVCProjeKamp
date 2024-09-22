using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MVCProjeKamp.UI.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactDal());
        ContactValidator cb = new ContactValidator();
        public IActionResult Index()
        {
            var contacts = cm.GetList();
            return View(contacts);
        }

        public IActionResult GetContactDetails(int id)
        {
            var contact = cm.GetByID(id);
            return View(contact);
        }

        public PartialViewResult LeftSideMenu()
        {
            return PartialView();
        }
    }
}
