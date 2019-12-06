using HotelReserve.Models;
using HotelReserve_BLL;
using HotelReserve_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReserve.Controllers
{
    public class ReserveController : Controller
    {       
        bllRoom bllRoom = new bllRoom();
        /// <summary>
        /// 预定酒店
        /// </summary>
        /// <returns></returns>
        // GET: Reserve
        public ActionResult Index()
        {          
            return View();
        }
        public ActionResult AddReserve()
        {
            return View();
        }      
        public ActionResult Reserve(RoomReserveViewModel m)
        {
            Session["RoomNumber"] = m.RoomNumber;
            Session["RoomType"] = m.RoomType;
            Session["RoomPrice"] = m.RoomPrice;
            return View();
        }
        public ActionResult MyReserve()
        {
            RoomReserveViewModel Room = new RoomReserveViewModel()
            {
                RoomNumber = Session["RoomNumber"].ToString(),
                RoomType = Session["RoomType"].ToString(),
                RoomPrice = Session["RoomPrice"].ToString(),
            };
            return View(Room);
        }
        /// <summary>
        /// 将根据ID信息查找到的房间信息展示在模态框里面
        /// </summary>
        /// <param name="RoomId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddReserve(RoomReserveViewModel m)
        {
            //获取userid
            int UserId = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserId"].ToString());
            bllUser getuser = new bllUser();
            T_User userInfo = getuser.GetuserInfo(UserId);
            string ReserveUser = userInfo.UserName;
            //预定状态数据
            int ReserveState = 0;
            //将订单信息存入表中
            bllRoom.PutroomInfo(ReserveUser,m.RoomNumber, m.RoomType, m.RoomPrice,m.RoomStart,m.RoomEnd,ReserveState);
            //将房间表中得此房间状态改为1（繁忙）
            bllRoom.ChangeRoomState(m.RoomNumber);
            return View();
        }
        /// <summary>
        /// 接收来至Index的RoomType,并将之存在session
        /// </summary>
        /// <param name="RoomType"></param>
        /// <returns></returns>
        public ViewResult Srarch(string RoomType)
        {
            Session["RoomType"] = RoomType;
            return View();
        }
        public ViewResult SrarchRoom(string RoomType, int RoomState = 0)
        {
            RoomType = Session["RoomType"].ToString();
            List<T_searhRoom> search = bllRoom.SearchroomReserve(RoomType,RoomState);
            return View(search);
        }
        /// <summary>
        /// 展示所有为0的房间信息
        /// </summary>
        /// <returns></returns>
        public ActionResult DtaReserve(int RoomState = 0)
        {
            List<T_Room> reserve = bllRoom.GetroomReserve(RoomState);
            return View(reserve);
        }
    }
}