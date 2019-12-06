using HotelReserve_DAL;
using HotelReserve_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReserve_BLL
{
    public class bllUser
    {
        dalRoom dalRoom = new dalRoom();
        dalUser dalUser = new dalUser();
        /// <summary>
        /// 根据Id(int)获取单个用户信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T_User GetuserInfo(int Id)
        {
            string sql = "select * from T_User where UserId=@Id";
            SqlParameter[] pars = {
                                 new SqlParameter("@Id",SqlDbType.NVarChar,32),
                                 };
            pars[0].Value = Id;

            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, pars);
            T_User userInfo = null;

            if (da.Rows.Count > 0)
            {
                userInfo = new T_User();

                LoadEntity(userInfo, da.Rows[0]);
            }
            return userInfo;
        }
        /// <summary>
        ///  根据Id(string)获取单个用户信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T_User GetuserInfo(string Id)
        {
            string sql = "select * from T_User where UserId=@Id";
            SqlParameter[] pars = {
                                 new SqlParameter("@Id",SqlDbType.NVarChar,32),
                                 };
            pars[0].Value = Id;

            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, pars);
            T_User userInfo = null;

            if (da.Rows.Count > 0)
            {
                userInfo = new T_User();

                LoadEntity(userInfo, da.Rows[0]);
            }
            return userInfo;
        }
        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        public List<T_User> GetallUserInfo()
        {
            string sql = "select * from T_User";
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text);
            List<T_User> User = new List<T_User>();
            for (int i = 0; i < da.Rows.Count; i++)
            {
                T_User userInfo = new T_User();
                LoadEntity(userInfo, da.Rows[i]);
                User.Add(userInfo);
            }
            return User;
        }
        /// <summary>
        /// 根据用户输入的用户账号查询相关用户
        /// </summary>
        /// <param name="UserSerch"></param>
        /// <returns></returns>
        public List<T_User> GetSerarchUser(string UserSerch)
        {
            string sql = string.Format("select * from T_User where UserName='{0}'", UserSerch);
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text);
            List<T_User> User = new List<T_User>();
            for (int i = 0; i < da.Rows.Count; i++)
            {
                T_User userInfo = new T_User();
                LoadEntity(userInfo, da.Rows[i]);
                User.Add(userInfo);
            }
            return User;
        }
        public void LoadEntity(T_User userInfo, DataRow row)
        {
            userInfo.UserId = Convert.ToInt32(row["UserId"]);
            userInfo.UserName = row["UserName"] != DBNull.Value ? row["UserName"].ToString() : string.Empty;
            userInfo.PassWord = row["PassWord"] != DBNull.Value ? row["PassWord"].ToString() : string.Empty;
            userInfo.IdCard = row["IdCard"] != DBNull.Value ? row["IdCard"].ToString() : string.Empty;
            userInfo.Name = row["Name"] != DBNull.Value ? row["Name"].ToString() : string.Empty;
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="IdCard"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        public bool bllRegister(string UserName, string IdCard, string Name,string PassWord)
        {
            string sql = string.Format("INSERT INTO T_User(UserName,IdCard,Name,PassWord) Values('{0}','{1}','{2}','{3}')", UserName, IdCard, Name, PassWord);

            bool b = dalUser.Addroom(sql);
            return b;

        }
        /// <summary>
        ///  修改用户资料UserId()int
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="UserName"></param>
        /// <param name="Name"></param>
        /// <param name="IdCard"></param>
        /// <returns></returns>
        public bool EditUser(int UserId, string UserName, string Name, string IdCard)
        {
            string sql = string.Format("update T_User set UserName='{1}',Name='{2}',IdCard='{3}' where UserId={0}", UserId, UserName, Name, IdCard);
            bool b = dalRoom.Changeroom(sql);
            return b;
        }
        /// <summary>
        ///  修改用户资料UserId(string)
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="UserName"></param>
        /// <param name="Name"></param>
        /// <param name="IdCard"></param>
        /// <returns></returns>
        public bool EditUser(string UserId, string UserName, string Name, string IdCard)
        {
            string sql = string.Format("update T_User set UserName='{1}',Name='{2}',IdCard='{3}' where UserId={0}", UserId, UserName, Name, IdCard);
            bool b = dalRoom.Changeroom(sql);
            return b;
        }
        /// <summary>
        /// 根据用户Id删除用户
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool DelUser(string UserId)
        {
            string sql = string.Format("delete from T_User where UserId='{0}'", UserId);
            bool b = dalRoom.Changeroom(sql);
            return b;
        }
        /// <summary>
        /// 根据用户Id，初始化该用户密码
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool UpPassWord(string Password, string UserId)
        {
            string sql = string.Format("update T_User set Password='{1}' where UserId='{0}'", UserId, Password);
            bool b = dalRoom.Changeroom(sql);
            return b;
        }
    }
}
