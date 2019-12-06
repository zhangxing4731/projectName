using System;
using System.ComponentModel.DataAnnotations;

namespace HotelReserveManage.Models
{    
    public class RoomViewModel
    {
        /// <summary>
        /// 房间ID
        /// </summary>
        [Display(Name = "房间编号")]
        public int RoomId { get; set; }
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
        /// 房间状态
        /// </summary>
        [Display(Name = "房间状态")]
        public string RoomState { get; set; }
    }
}