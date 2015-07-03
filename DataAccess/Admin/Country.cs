using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MYFAN.DataAccess
{
    public class Country : BaseDAC
    {
        public List<BusinessObjects.Country> ReadCountries()
        {
            List<BusinessObjects.Country> countries = new List<BusinessObjects.Country>();
            List<SqlParameter> param = new List<SqlParameter>();
            DataTable dt = Read(param.ToArray(), "SP_Country_Read");
            foreach (DataRow dr in dt.Rows)
            {
                countries.Add(new BusinessObjects.Country { ID = Convert.ToInt32(dr["PK_Country_ID"]), Name = Convert.ToString(dr["Country_Name"]), Icon = Convert.ToString(dr["Country_Icon"]), Image = Convert.ToString(dr["Country_Image"]) });
            }
            return countries;
        }

        public BusinessObjects.Country Read(long ID)
        {
            BusinessObjects.Country Country = new BusinessObjects.Country();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Country_Id", ID));
            DataTable dt = Read(param.ToArray(), "SP_Country_Read");
            if (dt.Rows.Count > 0)
            {
                Country = MapToParents(dt.Rows[0]);
            }
            return Country;
        }

        private BusinessObjects.Country MapToParents(DataRow dr)
        {
            BusinessObjects.Country Country = new BusinessObjects.Country();
            Country.ID = Convert.ToInt32(dr["PK_Country_ID"]);
            Country.Name = Convert.ToString(dr["Country_Name"]);
            Country.Icon = Convert.ToString(dr["Country_Icon"]);
            Country.Image = Convert.ToString(dr["Country_Image"]);
            return Country;
        }

        public int CreateUpdate(BusinessObjects.Country Country)
        {
            int retVal = -1;
            SqlParameter sqlparm = new SqlParameter();
            sqlparm.ParameterName = "@EffectedIDCountryID";
            sqlparm.Direction = ParameterDirection.Output;
            sqlparm.DbType = DbType.Int32;
            List<string> outParmNames = new List<string>();
            List<SqlParameter> param = new List<SqlParameter>();
            outParmNames.Add(sqlparm.ParameterName);
            Dictionary<string, Object> dic = new Dictionary<string, Object>();
            param.Add(new SqlParameter("@CountryID", Country.ID));
            param.Add(new SqlParameter("@CountryName", Country.Name));
            param.Add(new SqlParameter("@CountryIcon", Country.Icon));
            param.Add(new SqlParameter("@CountryImage", Country.Image));
            param.Add(new SqlParameter("@RequestorID", Country.Updated_By));
            param.Add(sqlparm);
            dic = Execute("SP_Country_CreateUpdate", param.ToArray(), outParmNames);
            retVal = (int)dic[sqlparm.ParameterName];
            return retVal;
        }
        public bool Delete(BusinessObjects.Country Country)
        {
            long retVal = -1;
            List<SqlParameter> param = new List<SqlParameter>();
            Dictionary<string, Object> dic = new Dictionary<string, Object>();
            param.Add(new SqlParameter("@CountryID", Country.ID));
            retVal = Execute("SP_Country_Delete", param.ToArray());
            return retVal > 0;
        }
    }
}
