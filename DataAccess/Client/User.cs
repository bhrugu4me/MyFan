using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYFAN.DataAccess.Client
{
    public class User : BaseDAC
    {
        public List<BusinessObjects.User> ReadAll()
        {
            List<BusinessObjects.User> users = new List<BusinessObjects.User>();
            List<SqlParameter> param = new List<SqlParameter>();
            DataTable dt = Read(param.ToArray(), "SP_User_Read");
            foreach (DataRow row in dt.Rows)
            {
                users.Add(MapToUser(row));
            }
            return users;
        }
        public BusinessObjects.User Read(long ID)
        {
            BusinessObjects.User User = new BusinessObjects.User();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@UserID", ID));
            DataTable dt = Read(param.ToArray(), "SP_User_Read");
            if (dt.Rows.Count > 0)
            {
                User = MapToUser(dt.Rows[0]);
            }
            return User;
        }

        public int Create(BusinessObjects.User User)
        {
            int retVal = -1;
            SqlParameter sqlparm = new SqlParameter();
            sqlparm.ParameterName = "@EffectedIDUserID";
            sqlparm.Direction = ParameterDirection.Output;
            sqlparm.DbType = DbType.Int32;
            List<string> outParmNames = new List<string>();
            List<SqlParameter> param = new List<SqlParameter>();
            outParmNames.Add(sqlparm.ParameterName);
            Dictionary<string, Object> dic = new Dictionary<string, Object>();
            param.Add(new SqlParameter("@UserParentID", User.parentID));
            param.Add(new SqlParameter("@UserName", User.Name));
            param.Add(sqlparm);
            dic = Execute("SP_User_CreateUpdate", param.ToArray(), outParmNames);
            retVal = (int)dic[sqlparm.ParameterName];
            return retVal;
        }
  
        private BusinessObjects.User MapToUser(DataRow dr)
        {
            BusinessObjects.User User = new BusinessObjects.User();
            User.ID = Convert.ToInt32(dr["PK_User_ID"]);
            User.Name = Convert.ToString(dr["User_Name"]);
            User.parentID = (BusinessObjects.MyFanCommon.eParentUser)Convert.ToInt16(dr["User_Parent_Id"]);
            return User;
        }

        public bool Delete(BusinessObjects.User User)
        {
            long retVal = -1;
            List<SqlParameter> param = new List<SqlParameter>();
            Dictionary<string, Object> dic = new Dictionary<string, Object>();
            param.Add(new SqlParameter("@PK_User_ID", User.PK_User_Id));
            retVal = Execute("SP_User_Delete", param.ToArray());
            return retVal > 0;
        }
    }
}
