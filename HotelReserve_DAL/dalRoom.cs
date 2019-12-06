using HotelReserve_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReserve_DAL
{
    public class dalRoom
    {

        public bool Addroom(string sql)
        {
            return SqlHelper.ExecuteNonquery(sql, CommandType.Text) > 0;
        }
        public bool Changeroom(string sql)
        {
            return SqlHelper.ExecuteNonquery(sql, CommandType.Text) > 0;
        }
    }
}
