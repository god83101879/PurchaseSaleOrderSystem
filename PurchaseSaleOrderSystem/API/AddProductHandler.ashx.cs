using PurchaseSaleOrderSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseSaleOrderSystem.API
{
    /// <summary>
    /// AddProductHandler 的摘要描述
    /// </summary>
    public class AddProductHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string Product_ID = context.Request.Form["Product_ID"];
            string Product_Name = context.Request.Form["Product_Name"];
            string Product_Num = context.Request.Form["Product_Num"];
            string Product_Price = context.Request.Form["Product_Price"];



            PStaticModel.FakePID--;
            OrderView order = new OrderView()
            {
                PO_OrderID = PStaticModel.FakePID,
                Product_Pid = Convert.ToInt32(Product_ID),
                Product_Name = Product_Name,
                Product_Num = Convert.ToInt32(Product_Num),
                Product_Price = Convert.ToInt32(Product_Price),
            };
            PStaticModel.ProductTotal += (order.Product_Price * order.Product_Num);
            PStaticModel.NowProduct.Add(order);

            context.Response.Write(0);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}