using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCPos.Classes
{
    internal class Payment
    {
        public int? PaymentID { get; set; }
        public int? MemberID { get; set; }
        public string PaymentType { get; set; }
        public decimal Amount { get; set; } = 0m;
        public string Ref { get; set; } = string.Empty;
        public int OrderID { get; set; }
        public int AgentID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Payment()
        {
            CreatedAt = DateTime.Now;
        }
    }
}

