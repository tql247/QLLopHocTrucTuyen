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
    public class AccountRes
    {
        public static List<Account> GetAll()
        {
            object[] value = { };
            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Account_GetAll", value);
            
            List<Account> lstResult = new List<Account>();
            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    Account Account = new Account();

                    Account.ID = string.IsNullOrEmpty(dr["ID"].ToString()) ? 0 : int.Parse(dr["ID"].ToString());
                    Account.FullName = dr["FullName"].ToString();
                    Account.Username = dr["UserName"].ToString();
                    Account.Password = dr["PassWord"].ToString();
                    Account.RoleName = dr["RoleName"].ToString();
                    Account.Email = dr["Email"].ToString();
                    Account.Phone = dr["Phone"].ToString();
                    Account.Address = dr["Address"].ToString();

                    lstResult.Add(Account);
                }
            }

            return lstResult;
        }
        public static Account CheckAccount(string username, string password)
        {
            object[] value =
            {
                username
            };

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Account_CheckLogin", value);
            Account Account = new Account();

            if (connection.errorCode == 0 && result.Rows.Count > 0)
            {
                var dr = result.Rows[0];
                
                Account.ID = string.IsNullOrEmpty(dr["ID"].ToString()) ? 0 : int.Parse(dr["ID"].ToString());
                Account.FullName = dr["FullName"].ToString();
                Account.Username = dr["UserName"].ToString();
                Account.Password = dr["PassWord"].ToString();
                Account.RoleName = dr["RoleName"].ToString();
                Account.Email = dr["Email"].ToString();
                Account.Phone = dr["Phone"].ToString();
                Account.Address = dr["Address"].ToString();

                if (Account.Password == password)
                    return Account;
            }

            return null;
        }


        public static bool Insert(Account Account)
        {
            object[] value =
            {
                Account.Username, 
                Account.Password, 
                Account.FullName, 
                Account.RoleName,  
                Account.Email,  
                Account.Phone,  
                Account.Address,  
            };

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Account_Insert ", value);
            if (connection.errorCode == 0 && connection.errorMessage == "")
                return true;


            Console.WriteLine(connection.errorMessage);

            return false;
        }

        public static bool Update(Account Account)
        {
            object[] value =
            {
                Account.ID, 
                Account.Username, 
                Account.Password, 
                Account.FullName, 
                Account.RoleName, 
                Account.Email,
                Account.Phone,
                Account.Address,
            };

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Account_Update ", value);
            if (connection.errorCode == 0 && connection.errorMessage == "")
                return true;

            Console.WriteLine(connection.errorMessage);
            return false;
        }

        public static bool Delete(int id)
        {
            object[] value =
            {
                id
            };

            SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
            DataTable result = connection.Select("Account_Delete ", value);
            if (connection.errorCode == 0 && connection.errorMessage == "")
                return true;
            return false;
        }
    }
}
