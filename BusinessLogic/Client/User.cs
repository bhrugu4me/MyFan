using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYFAN.BusinessLogic
{
    public class User
    {
        //check by userid,by username(email) and password and default readall
        //you can pass username or email id and password to login at that time pass userid=0
        public List<BusinessObjects.User> ReadAll(int userId,string UserName="",string Password="")
        {
            List<BusinessObjects.User> Users = new List<BusinessObjects.User>();
            try
            {
                Users = (new DataAccess.Client.User()).ReadAll(userId, UserName, Password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Users;
        }
        public BusinessObjects.User Read(long ID)
        {
            BusinessObjects.User UserItem = new BusinessObjects.User();
            try
            {
                UserItem = (new DataAccess.Client.User()).Read(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return UserItem;
        }

        //if registration from facebook,google+ or any other social then pass isdirect=0
        public int CreateLogin(BusinessObjects.User UserItem,int isdirect=1)
        {
            int retVal = -1;
            try
            {
                retVal = (new DataAccess.Client.User()).Create(UserItem,isdirect);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retVal;
        }

        public long CreateUser(BusinessObjects.User UserItem)
        {
            long retVal = -1;
            try
            {
                retVal = (new DataAccess.Client.User()).CreateUserProfile(UserItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retVal;
        }
        public bool Delete(BusinessObjects.User UserItem)
        {
            bool retVal = false;
            try
            {
                retVal = (new DataAccess.Client.User()).Delete(UserItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retVal;
        }
    }
}
