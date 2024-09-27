using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCPos.Classes
{
    internal class Wallet
    {
        public int WalletID { get; set; }
        public int MemberID { get; set; }
        public decimal Prepayment {  get; set; }
        public decimal PrepaymentBal { get; set; }
        public decimal Personal { get; set; }
        public decimal PersonalBal { get; set; }
        public decimal Discretionary { get; set; }
        public decimal DiscretionaryBal { get; set; }
        public decimal Rollover { get; set; }
        public decimal RolloverBal { get; set; }
    }
}
