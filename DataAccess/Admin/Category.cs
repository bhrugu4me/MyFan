using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYFAN.DataAccess
{
    public class Category : BaseDAC
    {
        public List<BusinessObjects.Category> ReadAll()
        {
            List<BusinessObjects.Category> categories = new List<BusinessObjects.Category>();
            List<SqlParameter> param = new List<SqlParameter>();
            DataTable dt = Read(param.ToArray(), "SP_Category_Read");
            foreach (DataRow row in dt.Rows)
            {
                categories.Add(MapToCategory(row));
            }
            return categories;
        }
        public BusinessObjects.Category Read(long ID)
        {
            BusinessObjects.Category Category = new BusinessObjects.Category();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@CategoryID",ID));
            DataTable dt = Read(param.ToArray(), "SP_Category_Read");
            if (dt.Rows.Count > 0)
            {
                Category = MapToCategory(dt.Rows[0]);   
            }
            return Category;
        }

        public int Create(BusinessObjects.Category category)
        {
            int retVal = -1;
            SqlParameter sqlparm = new SqlParameter();
            sqlparm.ParameterName = "@EffectedIDCategoryID";
            sqlparm.Direction = ParameterDirection.Output;
            sqlparm.DbType = DbType.Int32;
            List<string> outParmNames = new List<string>();
            List<SqlParameter> param = new List<SqlParameter>();
            outParmNames.Add(sqlparm.ParameterName);
            Dictionary<string, Object> dic = new Dictionary<string, Object>();
            param.Add(new SqlParameter("@CategoryParentID", category.parentID));
            param.Add(new SqlParameter("@CategoryName", category.Name));
            param.Add(new SqlParameter("@CategoryID", category.ID));
            param.Add(sqlparm);
            dic = Execute("SP_Category_CreateUpdate", param.ToArray(), outParmNames);
            retVal = (int)dic[sqlparm.ParameterName];
            return retVal;
        }
        public bool Update(BusinessObjects.Category category)
        {
            int retVal = -1;
            SqlParameter sqlparm = new SqlParameter();
            sqlparm.ParameterName = "@EffectedIDCategoryID";
            sqlparm.Direction = ParameterDirection.Output;
            sqlparm.DbType = DbType.Int32;
            List<SqlParameter> param = new List<SqlParameter>();
            List<string> outParmNames = new List<string>();
            outParmNames.Add(sqlparm.ParameterName);
            Dictionary<string, Object> dic = new Dictionary<string, Object>();
            param.Add(new SqlParameter("@CategoryParentID", category.parentID));
            param.Add(new SqlParameter("@CategoryName", category.Name));
            param.Add(new SqlParameter("@CategoryID", category.ID));
            param.Add(sqlparm);
            dic = Execute("SP_Category_CreateUpdate", param.ToArray(), outParmNames);
            retVal = (int)dic[sqlparm.ParameterName];
            return retVal > 0;
        }

        private BusinessObjects.Category MapToCategory(DataRow dr) 
        {
            BusinessObjects.Category Category = new BusinessObjects.Category();
            Category.ID = Convert.ToInt32(dr["PK_Category_ID"]);
            Category.Name = Convert.ToString(dr["Category_Name"]);
            Category.parentID = Convert.ToInt32(dr["Category_Parent_Id"]);
            Category.parentName = Convert.ToString(dr["Category_Parent_Name"]);
            return Category;
        }

        public bool Delete(BusinessObjects.Category Category)
        {
            long retVal = -1;
            List<SqlParameter> param = new List<SqlParameter>();
            Dictionary<string, Object> dic = new Dictionary<string, Object>();
            param.Add(new SqlParameter("@CategoryID", Category.ID));
            retVal = Execute("SP_Category_Delete", param.ToArray());
            return retVal > 0;
        }
    }
}
