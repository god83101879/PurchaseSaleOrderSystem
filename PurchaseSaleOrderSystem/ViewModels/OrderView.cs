using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseSaleOrderSystem.ViewModels
{
    public class OrderView
    {
        public int PO_OrderID { get; set; }
        public int Product_Pid { get; set; }
        public string Product_Name { get; set; }
        public int Product_Num { get; set; }
        public int Product_Price { get; set; }
        public decimal TotalPrice { get { return Product_Price * Product_Num; } }
    }
}