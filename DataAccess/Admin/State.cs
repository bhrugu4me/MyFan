using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYFAN.DataAccess
{
    public class State :BaseDAC
    {
        public List<BusinessObjects.State> ReadAll()
        {
            List<BusinessObjects.State> States = new List<BusinessObjects.State>();
            List<SqlParameter> param = new List<SqlParameter>();
            DataTable dt = Read(param.ToArray(), "SP_State_Read");
            foreach (DataRow row in dt.Rows)
            {
                States.Add(MapToParents(row));
            }
            return States;
        }

        public BusinessObjects.State Read(long ID)
        {
            BusinessObjects.State State = new BusinessObjects.State();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@StateID", ID));
            DataTable dt = Read(param.ToArray(), "SP_State_Read");
            if (dt.Rows.Count > 0)
            {
                State = MapToParents(dt.Rows[0]);
            }
            return State;
        }

        private BusinessObjects.State MapToParents(DataRow dr)
        {
            BusinessObjects.State State = new BusinessObjects.State();
            State.ID = Convert.ToInt32(dr["PK_State_ID"]);
            State.Name = Convert.ToString(dr["State_Name"]);
            State.Abbr = Convert.ToString(dr["State_Abbr"]);
            State.Country = new BusinessObjects.Country() { ID = Convert.ToInt32(dr["PK_Country_ID"]), Name = Convert.ToString(dr["Country_Name"]), Icon = Convert.ToString(dr["Country_Icon"]), Image = Convert.ToString(dr["Country_Image"]) };
            return State;
        }

        public int Create(BusinessObjects.State State)
        {
            int retVal = -1;
            SqlParameter sqlparm = new SqlParameter();
            sqlparm.ParameterName = "@EffectedIDStateID";
            sqlparm.Direction = ParameterDirection.Output;
            sqlparm.DbType = DbType.Int32;
            List<string> outParmNames = new List<string>();
            List<SqlParameter> param = new List<SqlParameter>();
            outParmNames.Add(sqlparm.ParameterName);
            Dictionary<string, Object> dic = new Dictionary<string, Object>();
            param.Add(new SqlParameter("@StateID", State.ID));
            param.Add(new SqlParameter("@CountryID", State.Country.ID));
            param.Add(new SqlParameter("@StateName", State.Name));
            param.Add(new SqlParameter("@StateAbbr", State.Abbr));
            param.Add(new SqlParameter("@RequestorID", State.Updated_By));
            param.Add(sqlparm);
            dic = Execute("SP_State_CreateUpdate", param.ToArray(), outParmNames);
            retVal = (int)dic[sqlparm.ParameterName];
            return retVal;
        }
     
        public bool Delete(BusinessObjects.State State)
        {
            long retVal = -1;
            List<SqlParameter> param = new List<SqlParameter>();
            Dictionary<string, Object> dic = new Dictionary<string, Object>();
            param.Add(new SqlParameter("@StateID", State.ID));
            retVal = Execute("SP_State_Delete", param.ToArray());
            return retVal > 0;
        }

    }
}
