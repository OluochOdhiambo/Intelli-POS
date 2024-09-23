using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCPos.Classes
{
    internal class ItemSplitDetail
    {
        public int? ID {  get; set; }
        public int MemberID { get; set; }
        public string Member { get; set; }
        public long ItemID { get; set; }
        public string Item { get; set; }
        public int OriginalQty { get; set; }
        public int SplitQty { get; set; }
        public decimal Price { get; set; }
    }
}
