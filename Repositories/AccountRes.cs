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
                    Account.Age = string.IsNullOrEmpty(dr["Age"].ToString()) ? 0 : int.Parse(dr["Age"].ToString());
                    Account.Gender = string.IsNullOrEmpty(dr["Gender"].ToString()) ? 0 : int.Parse(dr["Gender"].ToString());
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
                Account.Age = string.IsNullOrEmpty(dr["Age"].ToString()) ? 0 : int.Parse(dr["Age"].ToString());
                Account.Gender = string.IsNullOrEmpty(dr["Gender"].ToString()) ? 0 : int.Parse(dr["Gender"].ToString());
                Account.Address = dr["Address"].ToString();

                if (Account.Password == password)
                    return Account;
            }

            return null;
        }


         
        // public static bool Insert(Account Account)
        // {
        //     object[] value =
        //     {
        //         Account.FullName, 
        //         Account.UserName, 
        //         Account.PassWord, 
        //         Account.RoleName,  
        //         DateTime.Now
        //     };

        //     SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
        //     DataTable result = connection.Select("Account_Insert ", value);
        //     if (connection.errorCode == 0 && connection.errorMessage == "")
        //         return true;
        //     return false;
        // }

        // public static Account Detail(int id)
        // {
        //     object[] value =
        //     {
        //         id
        //     };

        //     SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
        //     DataTable result = connection.Select("Account_Detail ", value);
        //     Account Account = new Account();

        //     if (connection.errorCode == 0 && result.Rows.Count > 0)
        //     {
        //         var dr = result.Rows[0];
        //         Account.ID = string.IsNullOrEmpty(dr["ID"].ToString()) ? 0 : int.Parse(dr["ID"].ToString());
        //         Account.FullName = dr["FullName"].ToString();
        //         Account.UserName = dr["UserName"].ToString();
        //         Account.PassWord = dr["PassWord"].ToString();
        //         Account.RoleName = dr["RoleName"].ToString();
        //         Account.CreatedDate = string.IsNullOrEmpty(dr["CreatedDate"].ToString()) ? default : DateTime.Parse(dr["CreatedDate"].ToString());

        //     }
        //     return Account;
        // }

        // public static bool Edit(Account Account)
        // {
        //     Console.WriteLine(Account.FullName);
        //     object[] value =
        //     {
        //         Account.ID, Account.FullName, Account.UserName, Account.PassWord, Account.RoleName
        //     };

        //     SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
        //     DataTable result = connection.Select("Account_Update ", value);
        //     if (connection.errorCode == 0 && connection.errorMessage == "")
        //         return true;
        //     return false;
        // }

        // public static bool Delete(int id)
        // {
        //     object[] value =
        //     {
        //         id
        //     };

        //     SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
        //     DataTable result = connection.Select("Account_Delete ", value);
        //     if (connection.errorCode == 0 && connection.errorMessage == "")
        //         return true;
        //     return false;
        // }

        // public static Account CheckAccount(string username, string password)
        // {
        //     object[] value =
        //     {
        //         username
        //     };

        //     SQLCommand connection = new SQLCommand(ConstValue.ConnectionString);
        //     DataTable result = connection.Select("Account_CheckLogin", value);
        //     Account Account = new Account();

        //     if (connection.errorCode == 0 && result.Rows.Count > 0)
        //     {
        //         var dr = result.Rows[0];
        //         Account.ID = string.IsNullOrEmpty(dr["ID"].ToString()) ? 0 : int.Parse(dr["ID"].ToString());
        //         Account.FullName = dr["FullName"].ToString();
        //         Account.UserName = dr["UserName"].ToString();
        //         Account.PassWord = dr["PassWord"].ToString();
        //         Account.RoleName = dr["RoleName"].ToString();
        //         Account.CreatedDate = string.IsNullOrEmpty(dr["CreatedDate"].ToString()) ? default : DateTime.Parse(dr["CreatedDate"].ToString());

        //         if (Account.PassWord == password)
        //             return Account;
        //     }

        //     return null;
        // }
    }
}
