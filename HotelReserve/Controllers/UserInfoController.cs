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
    public class UserInfoController : Controller
    {
        bllUser bllUser = new bllUser();
        /// <summary>
        /// 个人资料
        /// </summary>
        /// <returns></returns>
        // GET: UserInfo
        public ActionResult Index()
        {
            int UserId = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserId"].ToString());
            bllUser bllUser = new bllUser();
            T_User userInfo = bllUser.GetuserInfo(UserId);
            UserDataViewModel loginViewModel = new UserDataViewModel
            {
                UserId = userInfo.UserId,
                UserName = userInfo.UserName,
                Name = userInfo.Name,
                IdCard = userInfo.IdCard,                  
            };
            return View(loginViewModel);
        }
        /// <summary>
        /// 个人资料编辑，获取要编辑的资料
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit()
        {
            int UserId = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserId"].ToString());
            bllUser getuser = new bllUser();
            T_User userInfo = getuser.GetuserInfo(UserId);
            UserDataViewModel loginViewModel = new UserDataViewModel
            {
                UserId = userInfo.UserId,
                UserName = userInfo.UserName,
                Name = userInfo.Name,
                IdCard = userInfo.IdCard,
            };
            Session["loginViewModel"] = loginViewModel;
            return View(loginViewModel);
        }
        /// <summary>
        /// 个人资料编辑，修改要编辑的资料
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public ActionResult EditInfo(LoginViewModel m)
        {
            int UserId = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserId"].ToString());
            bllUser.EditUser(UserId,m.UserName, m.Name, m.IdCard);
            return View();
        }
    }
}