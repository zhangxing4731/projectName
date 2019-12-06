using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReserve.Models
{
    public class UserDataViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCard { get; set; }
    }
}