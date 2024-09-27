using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCPos.Classes
{
    internal class Booking
    {
        public int BookingID { get; set; }
        public int MemberID { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime BookingFrom { get; set; }
        public DateTime BookingTo { get; set; }
        public int GuestCount { get; set; }
        public int RoomID { get; set; }
        public decimal UnitCost { get; set; }
    }
}
