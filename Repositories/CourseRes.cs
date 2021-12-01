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
    public class CourseRes
    {
        public static List<Course> GetAll()
        {
            object[] value = { };
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Course_GetAll", value);
            
            List<Course> lstResult = new List<Course>();
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    Course Course = new Course();

                    Course.ID = string.IsNullOrEmpty(dr["ID"].ToString()) ? 0 : int.Parse(dr["ID"].ToString());
                    Course.Name = dr["Name"].ToString();
                    Course.Fee = dr["Fee"].ToString();
                    Course.Description = dr["Description"].ToString();
                    Course.Teacher = dr["Teacher"].ToString();
                    lstResult.Add(Course);
                }
            }

            return lstResult;
        }

         
        public static bool Insert(Course course)
        {
            object[] value =
            {
                course.Name, course.Fee, course.Description, course.Teacher
            };

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Course_Insert ", value);
            if (connection.errorCode == 0 && connection.errorMessage == "")
                return true;
            return false;
        }
         
        public static bool Update(Course course)
        {
            object[] value =
            {
                course.ID, course.Name, course.Fee, course.Description, course.Teacher
            };

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Course_Update ", value);
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
            DataTable result = connection.Select("Course_Delete ", value);
            if (connection.errorCode == 0 && connection.errorMessage == "")
                return true;
            return false;
        }
    }
}
