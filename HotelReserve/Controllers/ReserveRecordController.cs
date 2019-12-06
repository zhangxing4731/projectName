using HotelReserve_BLL;
using HotelReserve_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReserve.Controllers
{
    public class ReserveRecordController : Controller
    {
        bllReserve bllReserve = new bllReserve();
        bllRoom bllRoom = new bllRoom();
        /// <summary>
        /// 我的预定
        /// </summary>
        /// <returns></returns>
        // GET: ReserveRecord
        public ViewResult Index()
        {
            //获取userid
            int UserId = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserId"].ToString());
            bllUser getuser = new bllUser();
            T_User userInfo = getuser.GetuserInfo(UserId);
            string ReserveUser = userInfo.UserName;
            List<T_Reserve> reserveInfo = bllReserve.GetreserveInfo(ReserveUser);
            return View(reserveInfo);
        }
      
        [HttpPost]
        public ActionResult DelReserve(string RoomNumber)
        {
            //根据获取的房间号信息将预定订单中的关于此房间的预定状态修改为1
            bllReserve.ChangeReserveState(RoomNumber);
            // //根据获取的房间号信息将房间表中的关于此房间的房间状态修改为0
            bllRoom.ChangeRoomstate(RoomNumber);
            return View();
        }
        }
}