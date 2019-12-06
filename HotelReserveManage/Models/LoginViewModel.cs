using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReserveManage.Models
{
    public class LoginViewModel
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 用户身份证
        /// </summary>
        public string IdCard { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string Name { get; set; }

    }
}