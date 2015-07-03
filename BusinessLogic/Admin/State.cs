using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYFAN.BusinessLogic
{
    public class State
    {
        public List<BusinessObjects.State> ReadAll()
        {
            List<BusinessObjects.State> States = new List<BusinessObjects.State>();
            try
            {
                States = (new DataAccess.State()).ReadAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return States;
        }
        public BusinessObjects.State Read(long ID)
        {
            BusinessObjects.State StateItem = new BusinessObjects.State();
            try
            {
                StateItem = (new DataAccess.State()).Read(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return StateItem;
        }
        public int CreateUpdate(BusinessObjects.State StateItem)
        {
            int retVal = -1;
            try
            {
                retVal = (new DataAccess.State()).Create(StateItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retVal;
        }
        public bool Delete(BusinessObjects.State StateItem)
        {
            bool retVal = false;
            try
            {
                retVal = (new DataAccess.State()).Delete(StateItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retVal;
        }

    }
}
