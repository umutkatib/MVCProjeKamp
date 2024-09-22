using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categorydal;

        public CategoryManager(ICategoryDal categorydal)
        {
            _categorydal = categorydal;
        }

        public void CategoryAddBL(Category category)
        {
            category.CategoryStatus = true;
            _categorydal.Insert(category);
        }

        public void CategoryRemoveBL(Category category)
        {
            category.CategoryStatus = false;
            _categorydal.Update(category);
        }

        public void CategoryUpdateBL(Category category)
        {
            category.CategoryStatus = true;
            _categorydal.Update(category);
        }

        public Category GetByID(int id)
        {
            return _categorydal.Get(x => x.CategoryID == id);
        }

        public List<Category> GetList()
        {
            return _categorydal.List(x => x.CategoryStatus == true);
        }


    }
}
