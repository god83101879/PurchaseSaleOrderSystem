using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseSaleOrderSystem.ViewModels
{
    public class PurchaseOrderListModel
    {
        public string PurchaseOrderID { get; set; }
        public string PurchaseOrder_PID { get; set; }
        public int ProductNum { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchaseOrderCost { get; set; }
    }
}