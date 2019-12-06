using HotelReserve.Extesion;
using HotelReserve_BLL;
using HotelReserve_Model;
using HotelReserveManage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReserveManage.Controllers
{
    public class LoginController : Controller
    {
        UserInfoService userInfoService = new UserInfoService();
        bllUser bllUser = new bllUser();
        // GET: Login
        /// <summary>
        /// 登陆
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 登陆验证
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(LoginViewModel m)
        {
            var mess = string.Empty;
            string strpwd = Md5Connvert.MD5Encoding(m.PassWord);
            T_User userInfo = userInfoService.GetUserInfo(m.UserName, strpwd);

            if (userInfo != null)
            {
                System.Web.HttpContext.Current.Session["UserName"] = userInfo.UserName;
                //Session["userName"] = userInfo.UserName;
                System.Web.HttpContext.Current.Session["UserId"] = userInfo.UserId;
                return RedirectToAction("Index", "RoomQuery");
            }
            else
            {
                return Index();
            }

        }
    }
}