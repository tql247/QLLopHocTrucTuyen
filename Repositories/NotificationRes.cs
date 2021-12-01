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
                    Notification.CreatedDate = string.IsNullOrEmpty(dr["CreatedDate"].ToString()) ? default : DateTime.Parse(dr["CreatedDate"].ToString());
                    lstResult.Add(Notification);
                }
            }

            return lstResult;
        }

         
        public static bool Insert(Notification notification)
        {
            object[] value =
            {
                notification.Title, notification.Content
            };

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Notification_Insert ", value);
            if (connection.errorCode == 0 && connection.errorMessage == "")
                return true;
            return false;
        }


        public static bool Delete(int id)
        {
            object[] value =
            {
                id
            };

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Notification_Delete ", value);
            if (connection.errorCode == 0 && connection.errorMessage == "")
                return true;
            return false;
        }
    }
}
