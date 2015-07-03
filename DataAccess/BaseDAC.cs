using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MYFAN.DataAccess
{
    public abstract class BaseDAC
    {

        private string GetConnection()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["myfan"].ConnectionString; 
        }
        protected DataSet Read(string procName, SqlParameter[] param)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(GetConnection());
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = procName;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(param);
            adp.SelectCommand = cmd;
            adp.Fill(ds);
            con.Close();
            return ds;
        }
        protected DataTable Read(SqlParameter[] param, string procName)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(GetConnection());
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = procName;
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(param);
            adp.SelectCommand = cmd;
            adp.Fill(dt);
            con.Close();
            return dt;
        }
        protected long Execute(string procName, SqlParameter[] param)
        {
            long retVal = -1;
            SqlConnection con = new SqlConnection(GetConnection());
            SqlCommand cmd = null;
            try
            {
                
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = procName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(param);
                cmd.Connection = con;
                retVal = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                    con.Close();
                }
            }
            return retVal;
        }
        protected Dictionary<string, Object> Execute(string procName, SqlParameter[] param, List<string> outparm)
        {
            Dictionary<string, Object> outParams = new Dictionary<string, object>();
            SqlCommand cmd = null;
            SqlConnection con = new SqlConnection(GetConnection());
            try
            {
                
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = procName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(param);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                foreach (var item in outparm)
                {
                    outParams.Add(item, cmd.Parameters[item].Value);
                }
            }
            catch (Exception)
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                    con.Close();
                }
            }
            return outParams;
        }
        protected Object ExecuteScalar(string procName, SqlParameter[] param)
        {
            Object retVal = null;
            SqlCommand cmd = null; 
            SqlConnection con = new SqlConnection(GetConnection());
            try
            {
               
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = procName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(param);
                cmd.Connection = con;
                retVal = cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                    con.Close();
                }
            }
            return retVal;
        }
    }

}