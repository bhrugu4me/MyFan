using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYFAN.BusinessLogic
{
    public class Category
    {
        public List<BusinessObjects.Category> ReadAll()
        {
            List<BusinessObjects.Category> categories = new List<BusinessObjects.Category>();
            try
            {
                categories =  (new DataAccess.Category()).ReadAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return categories;
        }

        public BusinessObjects.Category Read(long ID)
        {
            BusinessObjects.Category Category = new BusinessObjects.Category();
            try
            {
                Category = (new DataAccess.Category()).Read(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Category;
        }
        public int CreateUpdate(BusinessObjects.Category category)
        {
            int retVal = -1;
            try
            {
                retVal = (new DataAccess.Category()).Create(category);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retVal;
        }

        public bool Delete(BusinessObjects.Category category)
        {
            bool retVal = false;
            try
            {
                retVal = (new DataAccess.Category()).Delete(category);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retVal;
        }
    }
}
