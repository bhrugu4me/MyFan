using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYFAN.BusinessLogic
{
    public class City
    {
        public List<BusinessObjects.City> ReadAll()
        {
            List<BusinessObjects.City> Citys = new List<BusinessObjects.City>();
            try
            {
                Citys = (new DataAccess.City()).ReadAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Citys;
        }
        public BusinessObjects.City Read(long ID)
        {
            BusinessObjects.City CityItem = new BusinessObjects.City();
            try
            {
                CityItem = (new DataAccess.City()).Read(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return CityItem;
        }
        public int CreateUpdate(BusinessObjects.City CityItem)
        {
            int retVal = -1;
            try
            {
                retVal = (new DataAccess.City()).Create(CityItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retVal;
        }
        public bool Delete(BusinessObjects.City CityItem)
        {
            bool retVal = false;
            try
            {
                retVal = (new DataAccess.City()).Delete(CityItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retVal;
        }

    }
}
