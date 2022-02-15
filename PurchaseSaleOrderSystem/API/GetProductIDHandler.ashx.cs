using PurchaseSaleOrderSystem.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseSaleOrderSystem.API
{
    /// <summary>
    /// GetProductIDHandler 的摘要描述
    /// </summary>
    public class GetProductIDHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string ProductName = context.Request.Form["ProductName"];
            LinQDBTool PTool = new LinQDBTool();
            string PID = PTool.GetProductID(ProductName);
            context.Response.Write(PID);
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