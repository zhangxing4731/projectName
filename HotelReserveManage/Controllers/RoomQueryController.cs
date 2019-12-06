using HotelReserve_BLL;
using HotelReserve_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReserveManage.Controllers
{
    public class RoomQueryController : Controller
    {
        bllRoom bllRoom = new bllRoom();
        /// <summary>
        /// 房间查询
        /// </summary>
        /// <returns></returns>
        // GET: RoomQuery
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 列出所有房间信息
        /// </summary>
        /// <returns></returns>
        public ActionResult DtaRoom()
        {
            List<T_Room> room = bllRoom.GetroomInfo();
            return View(room);
        }
        /// <summary>
        /// 获取从INDEX页面传来的ROOMTYPE数据，并将之存在session
        /// </summary>
        /// <param name="RoomType"></param>
        /// <returns></returns>
        public ViewResult Srarch(string RoomType)
        {
            Session["RoomType"] = RoomType;
            return View();
        }
        /// <summary>
        /// 列出用户加入了搜索条件（房间类型）的所有房间信息
        /// </summary>
        /// <returns></returns>
        public ViewResult SrarchRoom(string RoomType)
        {
            RoomType = Session["RoomType"].ToString();
            List<T_Room> search = bllRoom.GetroomInfo(RoomType);
            return View(search);
        }
    }
}