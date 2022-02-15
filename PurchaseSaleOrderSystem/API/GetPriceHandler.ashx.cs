using PurchaseSaleOrderSystem.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseSaleOrderSystem.API
{
    /// <summary>
    /// GetPriceHandler 的摘要描述
    /// </summary>
    public class GetPriceHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string ProductName = context.Request.Form["ProductName"];
            LinQDBTool PTool = new LinQDBTool();
            int Price = PTool.GetPrice(ProductName);
            context.Response.Write(Price);
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