using CAIT.SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using QLLopHocTrucTuyen.Const;
using QLLopHocTrucTuyen.Models;

namespace QLLopHocTrucTuyen.Repositories
{
    public class NotificationRes
    {
        public static List<Notification> GetAll()
        {
            object[] value = { };
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Notification_GetAll", value);
            
            List<Notification> lstResult = new List<Notification>();
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    Notification Notification = new Notification();

                    Notification.ID = string.IsNullOrEmpty(dr["ID"].ToString()) ? 0 : int.Parse(dr["ID"].ToString());
                    Notification.Title = dr["Title"].ToString();
                    Notification.Content = dr["Content"].ToString();

                    lstResult.Add(Notification);
                }
            }

            return lstResult;
        }
    }
}
