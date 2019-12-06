using HotelReserve.Models;
using System.Data.Entity;


namespace HotelReserve.DAL
{
    public class HotelDbContext: DbContext
    {
        public HotelDbContext():base("T_HotelReserve"){ }
        public DbSet<RoomViewModel> Rooms { get; set; }
    }
}