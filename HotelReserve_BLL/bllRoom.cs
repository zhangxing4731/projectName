using HotelReserve_DAL;
using HotelReserve_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HotelReserve_BLL
{
    public class bllRoom
    {
        dalRoom dalRoom = new dalRoom();  
        /// <summary>
        /// 列出所有房间信息
        /// </summary>
        /// <returns></returns>
        public List<T_Room> GetroomInfo()
        {
            string sql = "select * from T_Room,T_RoomState where T_Room.RoomState=T_RoomState.RoomState";
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text);         
            List<T_Room> Room = new List<T_Room>();
            for (int i = 0; i < da.Rows.Count; i++)
            {
                T_Room roomInfo = new T_Room();
                loadEntity(roomInfo, da.Rows[i]);
                Room.Add(roomInfo);
            }
            return Room;
        }
        /// <summary>
        /// 将所有房间状态为0的房间信息列在预定表中
        /// </summary>
        /// <param name="RoomState"></param>
        /// <returns></returns>
        public List<T_Room> GetroomReserve (int RoomState) {           
            string sql = "select * from T_Room where RoomState=0";
            SqlParameter[] pars = {
                                 new SqlParameter("@RoomState",SqlDbType.NVarChar,32),
                                 };
            pars[0].Value = RoomState;
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, pars);
            List<T_Room> Room = new List<T_Room>();
            for (int i = 0; i<da.Rows.Count; i++)
            {
                T_Room roomInfo = new T_Room();
                LoadEntity(roomInfo, da.Rows[i]);
                Room.Add(roomInfo);
            }
            return Room;
        }
        /// <summary>
        /// 根据用户选择的RoomType将所有房间信息列出来
        /// </summary>
        /// <param name="RoomType"></param>
        /// <returns></returns>
        public List<T_Room> GetroomInfo(string RoomType)
        {
            string sql = string.Format("select * from T_Room,T_RoomState where RoomType='{0}' and T_Room.RoomState=T_RoomState.RoomState", RoomType);
            SqlParameter[] pars = {
                                 new SqlParameter("@RoomState",SqlDbType.NVarChar,32),
                                 };
            pars[0].Value = RoomType;
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, pars);
            List<T_Room> Room = new List<T_Room>();
            for (int i = 0; i < da.Rows.Count; i++)
            {
                T_Room roomInfo = new T_Room();
                loadEntity(roomInfo, da.Rows[i]);
                Room.Add(roomInfo);
            }
            return Room;
        }
        /// <summary>
        /// 根据用户选择条件将空闲房间列在表格中
        /// </summary>
        /// <param name="RoomState"></param>
        /// <returns></returns>
        public List<T_searhRoom> SearchroomReserve(string RoomType,int RoomState)
        {
            string sql = string.Format("select * from T_Room where RoomState=0 and RoomType='{0}'", RoomType);
            SqlParameter[] pars = {
                                 new SqlParameter("@RoomState",SqlDbType.NVarChar,32),
                                 };
            pars[0].Value = RoomState;
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, pars);
            List<T_searhRoom> Room = new List<T_searhRoom>();
            for (int i = 0; i < da.Rows.Count; i++)
            {
                T_searhRoom roomInfo = new T_searhRoom();
                Loadentity(roomInfo, da.Rows[i]);
                Room.Add(roomInfo);
            }
            return Room;
        }
        /// <summary>
        /// 点击预定后将当前点击的预定房间得所有信息存入reserve表中
        /// </summary>
        /// <returns></returns>
        public bool PutroomInfo(string ReserveUser, string RoomNumber,string RoomType,string RoomPrice,string RoomStart,string RoomEnd,int ReserveState)
        {
            string sql = string.Format("INSERT INTO T_Reserve(ReserveUser,RoomNumber,RoomType,RoomPrice,RoomStart,RoomEnd,ReserveState) Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", ReserveUser,RoomNumber, RoomType, RoomPrice,RoomStart,RoomEnd,ReserveState);
            bool b = dalRoom.Addroom(sql);
            return b;
        }
        public void loadEntity(T_Room roomInfo, DataRow row)
        {
            roomInfo.RoomId = Convert.ToInt32(row["RoomId"]);
            roomInfo.RoomNumber = row["RoomNumber"] != DBNull.Value ? row["RoomNumber"].ToString() : string.Empty;
            roomInfo.RoomType = row["RoomType"] != DBNull.Value ? row["RoomType"].ToString() : string.Empty;
            roomInfo.RoomPrice = row["RoomPrice"] != DBNull.Value ? row["RoomPrice"].ToString() : string.Empty;
            roomInfo.RoomState = row["RoomState"] != DBNull.Value ? row["RoomState"].ToString() : string.Empty;
            roomInfo.State = row["State"] != DBNull.Value ? row["State"].ToString() : string.Empty;
        }
        public void LoadEntity(T_Room roomInfo, DataRow row)
        {
            roomInfo.RoomId = Convert.ToInt32(row["RoomId"]);
            roomInfo.RoomNumber = row["RoomNumber"] != DBNull.Value ? row["RoomNumber"].ToString() : string.Empty;
            roomInfo.RoomType = row["RoomType"] != DBNull.Value ? row["RoomType"].ToString() : string.Empty;
            roomInfo.RoomPrice = row["RoomPrice"] != DBNull.Value ? row["RoomPrice"].ToString() : string.Empty;
            roomInfo.RoomState = row["RoomState"] != DBNull.Value ? row["RoomState"].ToString() : string.Empty;
        }
        public void Loadentity(T_searhRoom roomInfo, DataRow row)
        {
            roomInfo.RoomId = Convert.ToInt32(row["RoomId"]);
            roomInfo.RoomNumber = row["RoomNumber"] != DBNull.Value ? row["RoomNumber"].ToString() : string.Empty;
            roomInfo.RoomType = row["RoomType"] != DBNull.Value ? row["RoomType"].ToString() : string.Empty;
            roomInfo.RoomPrice = row["RoomPrice"] != DBNull.Value ? row["RoomPrice"].ToString() : string.Empty;
            roomInfo.RoomState = row["RoomState"] != DBNull.Value ? row["RoomState"].ToString() : string.Empty;
        }
        /// <summary>
        /// 添加房间
        /// </summary>
        /// <param name="RoomNumber"></param>
        /// <param name="RoomType"></param>
        /// <param name="RoomPrice"></param>
        /// <param name="RoomState"></param>
        /// <returns></returns>
        public bool bllAddroom(string RoomNumber, string RoomType, string RoomPrice, string RoomState)
        {
            string sql = string.Format("INSERT INTO T_Room(RoomNumber,RoomType,RoomPrice,RoomState) Values('{0}','{1}','{2}','{3}')", RoomNumber, RoomType, RoomPrice, RoomState);
            bool b = dalRoom.Addroom(sql);
            return b;

        }
        /// <summary>
        /// 根据房间号RoomNumber修改房间表中的房间状态RoomState为1
        /// </summary>
        /// <returns></returns>
        public bool ChangeRoomState(string RoomNumber)
        {
            string sql = string.Format("update T_Room set RoomState=1 where RoomNumber={0}", RoomNumber);
            bool b = dalRoom.Changeroom(sql);
            return b;
        }
        /// <summary>
        /// 根据房间号RoomNumber修改房间表中的房间状态RoomState为0
        /// </summary>
        /// <returns></returns>
        public bool ChangeRoomstate(string RoomNumber)
        {
            string sql = string.Format("update T_Room set RoomState=0 where RoomNumber={0}", RoomNumber);
            bool b = dalRoom.Changeroom(sql);
            return b;
        }
        /// <summary>
        /// 根据用户选择的要删除房子的ID信息删除该房间
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DelRoom(int Id)
        {
            string sql = string.Format("delete from T_Room where RoomId = '{0}'", Id);
            bool b = dalRoom.Changeroom(sql);
            return b;
        }
    }
}
