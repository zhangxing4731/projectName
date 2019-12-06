using HotelReserve_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HotelReserve_DAL
{
   public class dalUser
    {
        public T_User GetUserInfo(string UserName, string PassWord)
        {
            string sql = "select * from T_User where UserName=@UserName and PassWord=@PassWord";
            SqlParameter[] pars = {
                                 new SqlParameter("@UserName",SqlDbType.NVarChar,32),
                                   new SqlParameter("@PassWord",SqlDbType.NVarChar,32),
                                 };
            pars[0].Value = UserName;
            pars[1].Value = PassWord;

            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, pars);
            T_User userInfo = null;

            if (da.Rows.Count > 0)
            {
                userInfo = new T_User();

                LoadEntity(userInfo, da.Rows[0]);
            }
            return userInfo;
        }
        public void LoadEntity(T_User userInfo, DataRow row)
        {
            userInfo.UserId = Convert.ToInt32(row["UserId"]);
            userInfo.UserName = row["UserName"] != DBNull.Value ? row["UserName"].ToString() : string.Empty;
            userInfo.PassWord = row["PassWord"] != DBNull.Value ? row["PassWord"].ToString() : string.Empty;
            userInfo.IdCard = row["IdCard"] != DBNull.Value ? row["IdCard"].ToString() : string.Empty;
            userInfo.Name = row["Name"] != DBNull.Value ? row["Name"].ToString() : string.Empty;
        }
        public bool Addroom(string sql)
        {
            return SqlHelper.ExecuteNonquery(sql, CommandType.Text) > 0;
        }
    }
}
