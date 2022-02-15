using System;
using PurchaseSaleOrderSystem.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using PurchaseSaleOrderSystem.Models;
using CrystalDecisions.Shared;

namespace PurchaseSaleOrderSystem
{
    public partial class PurchaseOrderList : System.Web.UI.Page
    {
        //引用BL工具LoginHelper、內建驗證登入之方法
        LoginHelper helper = new LoginHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            //C#內建Session使用，儲存使用者資訊
            LoginInfo Info = (LoginInfo)Session["IsLogined"];
            // 檢查使用者資訊，如果已經有session，且符合資料庫內使用者資訊則顯示歡迎字串於本頁面左上角
            if (helper.HasLogIned())
            {
                User_Message.Text = $"歡迎!{Info.Name}";
            }
            //如果是第一次登入則載入建立資料表方法，顯示資料表
            if (!IsPostBack)
            {
                BuildDataTableCommit();
            }
        }
        //進貨單列表建立方法
        public void BuildDataTableCommit()
        {
            ////取得頁數QueryString，並設定頁面索引變數
            //string qpage = Request.QueryString["Page"];
            //int pIndex;
            ////如果qpage為空則設定pIndex為1
            //if (string.IsNullOrEmpty(qpage))
            //{
            //    pIndex = 1;
            //}
            ////如果不為空則將qpage安全轉型成整數並設定為pIndex輸出，如果pIndex<=0則將pIndex設定為1，表只有一頁
            //else
            //{
            //    int.TryParse(qpage, out pIndex);

            //    if (pIndex <= 0)
            //        pIndex = 1;
            //}
            //page，定義儲存頁數之變數
            //int page;

            //dBTool定義連接資料庫之BL工具
            LinQDBTool dBTool = new LinQDBTool(); 

            //使用查詢進貨單之方法並將結果儲存於result變數
            //將回傳的資料輸出至資料來源
            //使用資料
            var result = dBTool.GetPurchaseOrder();
            RepPurchaseOrderList.DataSource = result;
            RepPurchaseOrderList.DataBind();
        }
        //登出按鈕事件
        protected void Logout_Click(object sender, EventArgs e)
        {
            //引用BL登入工具，使用登出方法解除使用者資訊並返回登入畫面
            LoginHelper helper = new LoginHelper();
            helper.Logout();
            Response.Redirect("~/Login.aspx");
        }
        //新增按鈕事件，點擊新增畫面轉至新增進貨單畫面
        protected void NewAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ProductCRUD.aspx");
        }
        //刪除按鈕事件
        protected void Delete_Click(object sender, EventArgs e)
        {
            //定義delpur 建立刪除清單將勾選之CheckBoxD值放入
            List<string> delpur = new List<string>();
            foreach (RepeaterItem item in RepPurchaseOrderList.Items)
            {
                CheckBox CB = item.FindControl("CheckBoxD") as CheckBox;
                if (CB.Checked)
                {
                    delpur.Add(CB.ToolTip);
                }
            }
            //使用BL工具LinQDBTool，並使用裡面之刪除訂單方法，刪除訂單
            //重新載入資料表建立方法重新顯示資料表
            LinQDBTool dbTool = new LinQDBTool();
            dbTool.DelPurchaseOrder(delpur);
            BuildDataTableCommit();
        }
        //水晶報表輸出按鈕，點擊後引用水晶輸出方法
        protected void ReportOutput_Click(object sender, EventArgs e)
        {
            OutputPurchase();
        }
        //水晶報表輸出方法
        public void OutputPurchase()
        {
            //使用BL工具透過PSOrderSystemContext連結資料庫
            using (var context = new PSOrderSystemContext())
            {
                //var rep =
                //     (from obj in context.PurchaseOrders
                //      select new { obj.purchaseorder_orderid, obj.purchaseorder_pid,obj.purchaseorder_date, obj.purchaseorder_productnum, obj.purchaseorder_totalcost }).ToList();

                //從PurchaseOrders表篩選資料，以日期排序且條件是刪除者為空值，將重複的值同樣進貨單ID(purchaseorder_orderid)與進貨日期(purchaseorder_date)組成一列，避免過多重複顯示
                var rep =
                            from purchaseorders in context.PurchaseOrders
                            orderby purchaseorders.purchaseorder_date descending
                            where purchaseorders.purchaseorder_remover == null
                            group purchaseorders by new
                            {
                                purchaseorders.purchaseorder_orderid,
                                purchaseorders.purchaseorder_date,
                            }
                            into p
                            select new
                            {
                                Purchaseorder_orderid = p.Key.purchaseorder_orderid,
                                Purchaseorder_pid = p.Count(),
                                Purchaseorder_productnum = p.Sum(o => o.purchaseorder_productnum),
                                Purchaseorder_date = p.Key.purchaseorder_date,
                                Purchaseorder_totalcost = p.Sum(o => o.purchaseorder_totalcost)
                            };
                //引用內建之水晶報表方法
                PurchaseOrderListReport cr = new PurchaseOrderListReport();
                //將篩選出的資料放入方法
                cr.SetDataSource(rep);

                //放入方法後的篩選資料設定至資料來源
                CrystalReportViewer.ReportSource = cr;
                
                //將水晶報表輸出
                cr.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "発注書一覧表");
            }
        }
    }
}