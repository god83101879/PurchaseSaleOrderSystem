using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseSaleOrderSystem.ViewModels
{
    public class PStaticModel
    {
        public static List<OrderView> NowProduct { get; set; }
        public static decimal ProductTotal { get; set; }
        public static int FakePID { get; set; }
    }
}