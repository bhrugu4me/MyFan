using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYFAN.BusinessLogic
{
    public class Country
    {
        public List<BusinessObjects.Country> ReadAll()
        {
            List<BusinessObjects.Country> categories = new List<BusinessObjects.Country>();
            try
            {
                categories = (new DataAccess.Country()).ReadCountries();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return categories;
        }

        public BusinessObjects.Country Read(long ID)
        {
            BusinessObjects.Country Country = new BusinessObjects.Country();
            try
            {
                Country = (new DataAccess.Country()).Read(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Country;
        }
        public int CreateUpdate(BusinessObjects.Country Country)
        {
            int retVal = -1;
            try
            {
                retVal = (new DataAccess.Country()).CreateUpdate(Country);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retVal;
        }

        public bool Delete(BusinessObjects.Country Country)
        {
            bool retVal = false;
            try
            {
                retVal = (new DataAccess.Country()).Delete(Country);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retVal;
        }
    }
}
