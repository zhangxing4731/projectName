using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReserve_DAL
{
   public class dalReserve
    {
        public bool ChangeReserveState(string sql)
        {
            return SqlHelper.ExecuteNonquery(sql, CommandType.Text) == 0;
        }
    }
}
