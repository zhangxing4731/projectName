using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReserve_BLL
{
   public class UserInfoService
    {
        HotelReserve_DAL.dalUser UserInfoDal = new HotelReserve_DAL.dalUser();
        public HotelReserve_Model.T_User GetUserInfo(string UserName, string PassWord)
        {
            return UserInfoDal.GetUserInfo(UserName, PassWord);
        }
    }
}
