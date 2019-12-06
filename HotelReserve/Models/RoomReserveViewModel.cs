using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelReserve.Models
{
    public class RoomReserveViewModel
    {
        /// <summary>
        /// 房间ID
        /// </summary>
        [Display(Name = "订单编号")]
        public int Id { get; set; }
        /// <summary>
        /// 房间号
        /// </summary>
        [Display(Name = "房间号")]
        public string RoomNumber { get; set; }
        /// <summary>
        /// 房间类型
        /// </summary>
        [Display(Name = "房间类型")]
        public string RoomType { get; set; }
        /// <summary>
        /// 房间价格
        /// </summary>
        [Display(Name = "房间价格")]
        public string RoomPrice { get; set; }
        /// <summary>
        /// 入住日期
        /// </summary>
        [Display(Name = "入住日期")]
        public string RoomStart { get; set; }
        /// <summary>
        /// 退房日期
        /// </summary>
        [Display(Name = "退房日期")]
        public string RoomEnd { get; set; }
        /// <summary>
        /// 预定用户
        /// </summary>
        [Display(Name = "订房用户")]
        public string ReserveUser { get; set; }
        /// <summary>
        /// 预定状态
        /// </summary>
        [Display(Name = "预定状态")]
        public string ReserveState { get; set; }
    }
}