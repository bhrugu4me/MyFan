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
        public List<BusinessObjects.User> ReadAll(long UserID=0,string UserName="",string Password="")
        {
            List<BusinessObjects.User> users = new List<BusinessObjects.User>();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@PK_User_Id", UserID));
            param.Add(new SqlParameter("@UserName", UserName));
            param.Add(new SqlParameter("@password", Password));
            DataTable dt = Read(param.ToArray(), "SP_User_Read");
            foreach (DataRow row in dt.Rows)
            {
                users.Add(MapToUser(row));
            }
            return users;
        }
        public BusinessObjects.User Read(long UserID)
        {
            BusinessObjects.User User = new BusinessObjects.User();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@PK_User_Id", UserID));
            param.Add(new SqlParameter("@UserName", ""));
            param.Add(new SqlParameter("@password", ""));
            DataTable dt = Read(param.ToArray(), "SP_User_Read");
            if (dt.Rows.Count > 0)
            {
                User = MapToUser(dt.Rows[0]);
            }
            return User;
        }

        public int Create(BusinessObjects.User User,int isdirect=1)
        {
            int retVal = -1;
            SqlParameter sqlparm = new SqlParameter();
            sqlparm.ParameterName = "@EffectiveUserId";
            sqlparm.Direction = ParameterDirection.Output;
            sqlparm.DbType = DbType.Int32;
            List<string> outParmNames = new List<string>();
            List<SqlParameter> param = new List<SqlParameter>();
            outParmNames.Add(sqlparm.ParameterName);
            Dictionary<string, Object> dic = new Dictionary<string, Object>();
            param.Add(new SqlParameter("@UserName", User.UserLogin.UserName));
            param.Add(new SqlParameter("@Password", User.UserLogin.Password));
            param.Add(new SqlParameter("@EmailId", User.UserLogin.EmailID));
            param.Add(new SqlParameter("@AuthType", User.UserLogin.AuthType.Auth_Id));
            param.Add(sqlparm);
            dic = Execute("SP_UserLogin_Create", param.ToArray(), outParmNames);
            retVal = (int)dic[sqlparm.ParameterName];
            User.PK_User_Id = retVal;
            if (isdirect==1)
            {
                CreateUserProfile(User);
            }
            return retVal;
        }

        public long CreateUserProfile(BusinessObjects.User User)
        {
            long flg = 0;
            List<SqlParameter> param1 = new List<SqlParameter>();
            Dictionary<string, Object> dic1 = new Dictionary<string, Object>();
            param1.Add(new SqlParameter("@PK_User_Id", User.PK_User_Id));
            param1.Add(new SqlParameter("@FK_Utype_Id", User.UserType.PK_UserType_Id));
            param1.Add(new SqlParameter("@LastName", User.LastName));
            param1.Add(new SqlParameter("@FirstName", User.FirstName));
            param1.Add(new SqlParameter("@BirthDate", User.Birthdate));
            param1.Add(new SqlParameter("@Age", User.Age));
            param1.Add(new SqlParameter("@Gender", User.Gender));
            param1.Add(new SqlParameter("@UserEmpType", User.UserEmpType));
            param1.Add(new SqlParameter("@Education", User.Education));
            param1.Add(new SqlParameter("@Occupation", User.Occupation));
            param1.Add(new SqlParameter("@MaritalStatus", User.MaritalStatus));
            param1.Add(new SqlParameter("@City", User.City));
            param1.Add(new SqlParameter("@State", User.State));
            param1.Add(new SqlParameter("@Country", User.Country));
            param1.Add(new SqlParameter("@Area", User.Area));
            param1.Add(new SqlParameter("@IsOther", User.IsOther));
            param1.Add(new SqlParameter("@OtherLocation", User.OtherLocation));
            param1.Add(new SqlParameter("@ZipCode", User.ZipCode));
            param1.Add(new SqlParameter("@Mobile1", User.Mobile1));
            param1.Add(new SqlParameter("@Mobile2", User.Mobile2));
            param1.Add(new SqlParameter("@Fax", User.Fax));
            param1.Add(new SqlParameter("@IsVerified", User.IsVerified));
            param1.Add(new SqlParameter("@RequestorId", User.Updated_By));

            flg = Execute("SP_User_Create", param1.ToArray());
            return flg;
        }
        private BusinessObjects.User MapToUser(DataRow dr)
        {
            BusinessObjects.User User = new BusinessObjects.User();
            User.PK_User_Id = Convert.ToInt32(dr["PK_User_ID"]);
            User.UserLogin.PK_User_Id = Convert.ToInt32(dr["PK_User_ID"]);
            User.UserLogin.UserName = Convert.ToString(dr["User_Name"]);
            User.UserType.PK_UserType_Id = Convert.ToInt16(dr["FK_Utype_Id"]);
            User.Age = Convert.ToInt16(dr["Age"]);
            User.State = Convert.ToInt32(dr["State"]);
            User.City = Convert.ToInt32(dr["City"]);
            User.Country = Convert.ToInt32(dr["Country"]);
            User.UserLogin.AuthType.Auth_Id = Convert.ToInt16(dr["AuthType"]);
            User.UserEmpType = Convert.ToInt16(dr["UserEmpType"]);
            User.IsOther = Convert.ToInt16(dr["IsOther"]);
            User.IsVerified = Convert.ToInt16(dr["IsVerified"]);
            User.Area = Convert.ToString(dr["User_Name"]);
            User.Education = Convert.ToString(dr["User_Name"]);
            User.Fax = Convert.ToString(dr["User_Name"]);
            User.FirstName = Convert.ToString(dr["User_Name"]);
            User.Gender = Convert.ToString(dr["User_Name"]);
            User.LastName = Convert.ToString(dr["User_Name"]);
            User.MaritalStatus = Convert.ToString(dr["User_Name"]);
            User.Mobile1 = Convert.ToString(dr["User_Name"]);
            User.Mobile2 = Convert.ToString(dr["User_Name"]);
            User.Occupation = Convert.ToString(dr["User_Name"]);
            User.OtherLocation = Convert.ToString(dr["User_Name"]);
            User.ZipCode = Convert.ToString(dr["User_Name"]);
            User.Birthdate = Convert.ToDateTime(dr["BirthDate"]);
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
