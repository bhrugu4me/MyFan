using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MYFAN.DataAccess
{
    public class AuthType : BaseDAC
    {
        public List<BusinessObjects.AuthType> ReadAll()
        {
            List<BusinessObjects.AuthType> countries = new List<BusinessObjects.AuthType>();
            List<SqlParameter> param = new List<SqlParameter>();
            DataTable dt = Read(param.ToArray(), "SP_AuthType_Read");
            foreach (DataRow dr in dt.Rows)
            {
                countries.Add(new BusinessObjects.AuthType { Auth_Id = Convert.ToInt32(dr["Auth_Id"]), Auth_Type = Convert.ToString(dr["AuthType"])});
            }
            return countries;
        }

        public BusinessObjects.AuthType Read(long ID)
        {
            BusinessObjects.AuthType AuthType = new BusinessObjects.AuthType();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Auth_Id", ID));
            DataTable dt = Read(param.ToArray(), "SP_AuthType_Read");
            if (dt.Rows.Count > 0)
            {
                AuthType = MapToParents(dt.Rows[0]);
            }
            return AuthType;
        }

        private BusinessObjects.AuthType MapToParents(DataRow dr)
        {
            BusinessObjects.AuthType AuthType = new BusinessObjects.AuthType();
            AuthType.Auth_Id = Convert.ToInt32(dr["Auth_Id"]);
            AuthType.Auth_Type = Convert.ToString(dr["AuthType"]);
            return AuthType;
        }

      
    }
}
