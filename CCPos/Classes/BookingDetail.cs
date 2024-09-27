using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCPos.Classes
{
    internal class BookingDetail
    {
        public int DetailID { get; set; }
        public int BookingID { get; set; }
        public DateTime ServingTime { get; set; }
        public int ItemGroupID { get; set; }
        public int ItemID { get; set; }
        public int Qty { get; set; }
        public int ServedQty { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice { get; set; }
    }
}
