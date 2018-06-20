using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace WMSupportLibrary
{
    public class LibGlobalSettings
    {
        public static Dictionary<string, string> Settings = new Dictionary<string, string>();
        public LibGlobalSettings()
        {
            LibDatabaseHandler db = new LibDatabaseHandler();
            db.DBConnect();
            DataTable dt = db.OpenRecordset("select * from WorkFlowMGMTSettings where deleteflag = 'N'");
            foreach (DataRowView dv in dt.DefaultView)
            {
                Settings.Add(dv["FieldKey"].ToString(), dv["FieldValue"].ToString());
            }
            db.DBDisconnect();
        }
        public static Dictionary<string, string> getGlobalSetting()
        {
            LibGlobalSettings gbs = new LibGlobalSettings();
            return Settings;
        }
    }
}
