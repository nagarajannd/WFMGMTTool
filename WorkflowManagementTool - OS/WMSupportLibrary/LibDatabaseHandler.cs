using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace WMSupportLibrary
{
    public class LibDatabaseHandler
    {
        SqlConnection cn; SqlCommand cmd; SqlDataAdapter da;
        private string conString = WMSupportLibrary.Properties.Settings.Default.connectionstring_rpa;

        public bool DBConnect()
        {
            if (cn == null) { cn = new SqlConnection(conString); }
            cn.Open();
            if (cn.State == ConnectionState.Open)
                return true;
            else
                return false;
        }
        public void DBDisconnect()
        {
            if (cn != null)
                if (cn.State == ConnectionState.Open)
                    cn.Close();
        }
        public int ExecuteQuery(string qry)
        {
            if (cmd == null) { cmd = new SqlCommand(); }
            cmd.Connection = cn;
            cmd.CommandText = qry;
            cmd.CommandType = CommandType.Text;
            return cmd.ExecuteNonQuery();
        }
        public int ExecuteScalar(string qry)
        {
            string result = string.Empty;
            if (cmd == null) { cmd = new SqlCommand(); }
            cmd.Connection = cn;
            cmd.CommandText = qry;
            cmd.CommandType = CommandType.Text;
            result = cmd.ExecuteScalar().ToString();
            return int.Parse(result);
        }
        public int ExecuteStoreProcedure(string procedure, string[] procArgs, string[] argVals)
        {
            int result = 0;
            if (procArgs.Length == argVals.Length)
            {
                if (cmd == null) { cmd = new SqlCommand(); }
                cmd.Connection = cn;
                cmd.CommandText = procedure;
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < procArgs.Length; i++)
                    cmd.Parameters.AddWithValue(procArgs[i], argVals[i]);
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }
        public DataTable OpenRecordset(string qry)
        {
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(qry, cn);
            da.Fill(dt);
            return dt;
        }
    }
}
