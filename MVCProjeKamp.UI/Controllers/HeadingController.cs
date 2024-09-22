using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using X.PagedList.Extensions;

namespace MVCProjeKamp.UI.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        WriterManager wm = new WriterManager(new EFWriterDal());

        public IActionResult Index(int page = 1)
        {
            return View(hm.GetListWithInclude().ToPagedList(page, 5));
        }

        [HttpGet]
        public IActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.ValueCategory = valueCategory;

            List<SelectListItem> writerValue = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + x.WriterSurname,
                                                    Value = x.WriterID.ToString()
                                                }).ToList();
            ViewBag.ValueWriter = writerValue;

            return View();
        }
        [HttpPost]
        public IActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.HeadingStatus = true;
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.ValueCategory = valueCategory;

            var heading = hm.GetByID(id);
            return View(heading);
        }

        [HttpPost]
        public IActionResult EditHeading(Heading p)
        {
            p.HeadingStatus = true;
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteHeading(int id)
        {
            var heading = hm.GetByID(id);
            heading.HeadingStatus = false;
            hm.HeadingRemove(heading);
            return RedirectToAction("Index");
        }
    }
}
