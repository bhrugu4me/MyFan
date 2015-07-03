using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYFAN.DataAccess
{
    public class City : BaseDAC
    {
        public List<BusinessObjects.City> ReadAll()
        {
            List<BusinessObjects.City> Citys = new List<BusinessObjects.City>();
            List<SqlParameter> param = new List<SqlParameter>();
            DataTable dt = Read(param.ToArray(), "SP_City_Read");
            foreach (DataRow row in dt.Rows)
            {
                Citys.Add(MapToParents(row));
            }
            return Citys;
        }

        public BusinessObjects.City Read(long ID)
        {
            BusinessObjects.City City = new BusinessObjects.City();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@CityID", ID));
            DataTable dt = Read(param.ToArray(), "SP_City_Read");
            if (dt.Rows.Count > 0)
            {
                City = MapToParents(dt.Rows[0]);
            }
            return City;
        }

        private BusinessObjects.City MapToParents(DataRow dr)
        {
            BusinessObjects.City City = new BusinessObjects.City();
            City.ID = Convert.ToInt32(dr["PK_City_ID"]);
            City.Name = Convert.ToString(dr["City_Name"]);
            City.State = new BusinessObjects.State() { ID = Convert.ToInt32(dr["PK_State_ID"]), Name = Convert.ToString(dr["State_Name"]), Abbr = Convert.ToString(dr["State_Abbr"]) };
            City.State.Country = new BusinessObjects.Country() { ID = Convert.ToInt32(dr["PK_Country_ID"]), Name = Convert.ToString(dr["Country_Name"]), Icon = Convert.ToString(dr["Country_Icon"]), Image = Convert.ToString(dr["Country_Image"]) };
            return City;
        }

        public int Create(BusinessObjects.City City)
        {
            int retVal = -1;
            SqlParameter sqlparm = new SqlParameter();
            sqlparm.ParameterName = "@EffectedIDCityID";
            sqlparm.Direction = ParameterDirection.Output;
            sqlparm.DbType = DbType.Int32;
            List<string> outParmNames = new List<string>();
            List<SqlParameter> param = new List<SqlParameter>();
            outParmNames.Add(sqlparm.ParameterName);
            Dictionary<string, Object> dic = new Dictionary<string, Object>();
            param.Add(new SqlParameter("@CityID", City.ID));
            param.Add(new SqlParameter("@StateID", City.State.ID));
            param.Add(new SqlParameter("@CityName", City.Name));
            param.Add(new SqlParameter("@RequestorID", City.Updated_By));
            param.Add(sqlparm);
            dic = Execute("SP_City_CreateUpdate", param.ToArray(), outParmNames);
            retVal = (int)dic[sqlparm.ParameterName];
            return retVal;
        }
     
        public bool Delete(BusinessObjects.City City)
        {
            long retVal = -1;
            List<SqlParameter> param = new List<SqlParameter>();
            Dictionary<string, Object> dic = new Dictionary<string, Object>();
            param.Add(new SqlParameter("@CityID", City.ID));
            retVal = Execute("SP_City_Delete", param.ToArray());
            return retVal > 0;
        }

    }
}
