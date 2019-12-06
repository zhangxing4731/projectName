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
   public class bllReserve
    {
        dalReserve dalReserve = new dalReserve();
        /// <summary>
        /// 获取预定表中得所有预定订单信息，根据ReserveUser预定用户
        /// </summary>
        /// <returns></returns>
        public List<T_Reserve> GetreserveInfo(string ReserveUser) {
            string sql = string.Format("select * from T_Reserve,T_ReserveState where T_Reserve.ReserveState=T_ReserveState.ReserveState and ReserveUser={0}", ReserveUser);
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text);
            List<T_Reserve> Reserve = new List<T_Reserve>();
            for (int i = 0; i < da.Rows.Count; i++)
            {
                T_Reserve reserveInfo = new T_Reserve();
                LoadEntity(reserveInfo, da.Rows[i]);
                Reserve.Add(reserveInfo);
            }
            return Reserve;
        }
        /// <summary>
        /// 获取预定表中得所有预定订单信息
        /// </summary>
        /// <returns></returns>
        public List<T_Reserve> GetreserveInfo()
        {
            string sql = string.Format("select * from T_Reserve,T_ReserveState where T_Reserve.ReserveState=T_ReserveState.ReserveState");
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text);
            List<T_Reserve> Reserve = new List<T_Reserve>();
            for (int i = 0; i < da.Rows.Count; i++)
            {
                T_Reserve reserveInfo = new T_Reserve();
                LoadEntity(reserveInfo, da.Rows[i]);
                Reserve.Add(reserveInfo);
            }
            return Reserve;
        }
        /// <summary>
        /// 根据roomnumber信息修改预订订单中的房间状态为1（取消预定）
        /// </summary>
        /// <param name="RoomNumber"></param>
        /// <returns></returns>
        public bool ChangeReserveState(string RoomNumber)
        {
            string sql = string.Format("update T_Reserve set ReserveState=1 where RoomNumber={0}", RoomNumber);
            bool b = dalReserve.ChangeReserveState(sql);
            return b;
        }
        /// <summary>
        /// 根据订单Id信息删除该订单
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DelReserve(string Id)
        {
            string sql = string.Format("delete from T_Reserve where Id='{0}'",Id);
            bool b = dalReserve.ChangeReserveState(sql);
            return b;
        }
        /// <summary>
        /// 根据订单ID信息查询该订单状态
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T_Reserve Reservestate(string Id)
        {
            string sql = "select * from T_Reserve where Id=@Id";
            SqlParameter[] pars = {
                                 new SqlParameter("@Id",SqlDbType.NVarChar,32),
                                 };
            pars[0].Value = Id;

            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, pars);
            T_Reserve reserveInfo = null;

            if (da.Rows.Count > 0)
            {
                reserveInfo = new T_Reserve();

                loadEntity(reserveInfo, da.Rows[0]);
            }
            return reserveInfo;
        }
        public void LoadEntity(T_Reserve reserveInfo, DataRow row)
        {
            reserveInfo.Id = Convert.ToInt32(row["Id"]);
            reserveInfo.ReserveUser = row["ReserveUser"] != DBNull.Value ? row["ReserveUser"].ToString() : string.Empty;
            reserveInfo.RoomNumber = row["RoomNumber"] != DBNull.Value ? row["RoomNumber"].ToString() : string.Empty;
            reserveInfo.RoomType = row["RoomType"] != DBNull.Value ? row["RoomType"].ToString() : string.Empty;
            reserveInfo.RoomPrice = row["RoomPrice"] != DBNull.Value ? row["RoomPrice"].ToString() : string.Empty;
            reserveInfo.RoomStart = row["RoomStart"] != DBNull.Value ? row["RoomStart"].ToString() : string.Empty;
            reserveInfo.RoomEnd = row["RoomEnd"] != DBNull.Value ? row["RoomEnd"].ToString() : string.Empty;
            reserveInfo.ReserveState = row["ReserveState"] != DBNull.Value ? row["ReserveState"].ToString() : string.Empty;
            reserveInfo.State = row["State"] != DBNull.Value ? row["State"].ToString() : string.Empty;
        }
        public void loadEntity(T_Reserve reserveInfo, DataRow row)
        {
            reserveInfo.Id = Convert.ToInt32(row["Id"]);
            reserveInfo.ReserveUser = row["ReserveUser"] != DBNull.Value ? row["ReserveUser"].ToString() : string.Empty;
            reserveInfo.RoomNumber = row["RoomNumber"] != DBNull.Value ? row["RoomNumber"].ToString() : string.Empty;
            reserveInfo.RoomType = row["RoomType"] != DBNull.Value ? row["RoomType"].ToString() : string.Empty;
            reserveInfo.RoomPrice = row["RoomPrice"] != DBNull.Value ? row["RoomPrice"].ToString() : string.Empty;
            reserveInfo.RoomStart = row["RoomStart"] != DBNull.Value ? row["RoomStart"].ToString() : string.Empty;
            reserveInfo.RoomEnd = row["RoomEnd"] != DBNull.Value ? row["RoomEnd"].ToString() : string.Empty;
            reserveInfo.ReserveState = row["ReserveState"] != DBNull.Value ? row["ReserveState"].ToString() : string.Empty;          
        }
    }
}
