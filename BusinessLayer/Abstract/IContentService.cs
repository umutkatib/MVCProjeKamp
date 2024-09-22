using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService 
    {
        List<Content> GetList();
        void ContentAddBL(Content content);
        Content GetByID(int id);
        void ContentRemoveBL(Content content);
        void ContentUpdateBL(Content content);
    }
}
