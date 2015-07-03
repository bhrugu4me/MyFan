using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYFAN.BusinessLogic
{
    public class AuthType
    {
        public List<BusinessObjects.AuthType> ReadAll()
        {
            List<BusinessObjects.AuthType> AuthTypes = new List<BusinessObjects.AuthType>();
            try
            {
                AuthTypes = (new DataAccess.AuthType()).ReadAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return AuthTypes;
        }
        public BusinessObjects.AuthType Read(long ID)
        {
            BusinessObjects.AuthType AuthTypeItem = new BusinessObjects.AuthType();
            try
            {
                AuthTypeItem = (new DataAccess.AuthType()).Read(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return AuthTypeItem;
        }
       
    }
}
