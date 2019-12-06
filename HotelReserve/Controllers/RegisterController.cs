using HotelReserve.Extesion;
using HotelReserve.Models;
using HotelReserve_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReserve.Controllers
{
    public class RegisterController : Controller
    {
        UserInfoService userInfoService = new UserInfoService();
        bllUser bllUser = new bllUser();
        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Index(RegisterViewModel m)
        {
            string strpwd = Md5Connvert.MD5Encoding(m.PassWord);
            if (string.IsNullOrEmpty(m.UserName) || string.IsNullOrEmpty(m.IdCard)|| string.IsNullOrEmpty(m.Name) || string.IsNullOrEmpty(strpwd))
            {
                return Json(new { Status = false, Message = "不能留空" });

            }
            if (bllUser.bllRegister(m.UserName, m.IdCard,m.Name ,strpwd))
            {
                return Json(new { Status = true, Message = "" });
            }
            return Json(new { Status = false, Message = "用户名已经存在" });
        }
        }
}