using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingdal;

        public HeadingManager(IHeadingDal headingdal)
        {
            _headingdal = headingdal;
        }

        public Heading GetByID(int id)
        {
            return _headingdal.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetList()
        {
            return _headingdal.List();
        }

        public List<Heading> GetListWithInclude()
        {
            return _headingdal.ListWithInclude(x => x.Category);
        }

        public void HeadingAdd(Heading heading)
        {
            _headingdal.Insert(heading);
        }

        public void HeadingRemove(Heading heading)
        {
            _headingdal.Delete(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingdal.Update(heading);
        }
    }
}
