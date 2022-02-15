using PurchaseSaleOrderSystem.Models;
using PurchaseSaleOrderSystem.Utility;
using PurchaseSaleOrderSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PurchaseSaleOrderSystem
{
    public partial class ProductCRUD : System.Web.UI.Page
    {
        static string PurchaseID;
        static string PurchaseDate;
        protected void Page_Load(object sender, EventArgs e)
        {
            LinQDBTool PTool = new LinQDBTool();
            List<string> ProductList = PTool.GetPL();
            AddProdcut.DataSource = ProductList;

            if (!IsPostBack)
            {
                if (PStaticModel.FakePID == 0)
                {
                    BuildProductTable();
                    AddProdcut.DataBind();
                }
                else
                {
                    BuildProductTableTemp();
                    AddProdcut.DataBind();
                }

                //BuildDDLCateCommit();
            }
            //LoginInfo Info = (LoginInfo)Session["IsLogined"];

            //DateTime nowtime = DateTime.Now;
            //PurchaseID = $"A{nowtime.ToString("yyyyMMddHHmm")}-{Info.UserID}";
            //PurchaseOrderNum.Text = PurchaseID;
            //PurchaseDate = nowtime.ToString("yyyy-MM-dd HH:mm");
            //datepicker.Text = PurchaseDate;

            //LinQDBTool PTool = new LinQDBTool();
            //List<string> ProductList = PTool.GetPL();
            //AddProdcut.DataSource = ProductList;
            //AddProdcut.DataBind();


        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            LoginHelper helper = new LoginHelper();
            helper.Logout();
            Response.Redirect("~/Login.aspx");
        }

        public void BuildProductTable()
        {
            LoginInfo Info = Session["IsLogined"] as LoginInfo;
            string Pid = Request.QueryString["ID"];
            string Ppage = Request.QueryString["Page"];

            int Pindex;
            if (string.IsNullOrEmpty(Ppage))
                Pindex = 1;
            else
            {
                int.TryParse(Ppage, out Pindex);

                if (Pindex <= 0)
                    Pindex = 1;
            }

            if (string.IsNullOrEmpty(Pid))
            {
                DateTime nowtime = DateTime.Now;
                PurchaseID = $"A{nowtime.ToString("yyyyMMddHHmm")}-{Info.UserID}";
                PurchaseOrderNum.Text = PurchaseID;
                PurchaseDate = nowtime.ToString("yyyy-MM-dd HH:mm");
                datepicker.Text = PurchaseDate;

                PStaticModel.ProductTotal = 0;
                PStaticModel.NowProduct = new List<OrderView>();

                TotalPrice.Text = $"總計 NT{PStaticModel.ProductTotal}";
            }
            else
            {
                PurchaseOrderNum.Text = Pid;

                LinQDBTool dBTool = new LinQDBTool();
                datepicker.Text = dBTool.GetPurchaseDate(Pid);
                decimal fullprice;
                int page;
                var result = dBTool.GetOrder(Pid, out fullprice, out page, Pindex);
                PStaticModel.ProductTotal = fullprice;
                PStaticModel.NowProduct = result;
                RepProductList.DataSource = PStaticModel.NowProduct.Skip(10 * (Pindex - 1)).Take(10);
                RepProductList.DataBind();


                TotalPrice.Text = $"總計 NT{PStaticModel.ProductTotal}";
            }
        }

        public void BuildProductTableTemp()
        {
            string Pid = Request.QueryString["ID"];
            string Ppage = Request.QueryString["Page"];

            int Pindex;
            if (string.IsNullOrWhiteSpace(Ppage))
            {
                Pindex = 1;
            }

            else
            {
                int.TryParse(Ppage, out Pindex);

                if (Pindex <= 0)
                {
                    Pindex = 1;
                }
            }

            if (string.IsNullOrWhiteSpace(Pid))
            {
                PurchaseOrderNum.Text = PurchaseID;
                datepicker.Text = PurchaseDate;

                int page = (PStaticModel.NowProduct.Count / 10) + 1;
                var resultDB =
                    from orders in PStaticModel.NowProduct
                    where orders.Product_Pid > 0
                    orderby orders.Product_Pid descending
                    select orders;
                var resultTemp =
                    from orders in PStaticModel.NowProduct
                    where orders.Product_Pid < 0
                    orderby orders.Product_Pid
                    select orders;
                var result = resultTemp.ToList();
                foreach (var item in resultDB.ToList())
                {
                    result.Add(item);
                }
                RepProductList.DataSource = result.Skip(10 * (Pindex - 1)).Take(10);
                RepProductList.DataBind();

                TotalPrice.Text = $"總計 NT{PStaticModel.ProductTotal}";
            }
            else
            {
                PurchaseOrderNum.Text = Pid;

                LinQDBTool dBTool = new LinQDBTool();
                datepicker.Text = dBTool.GetPurchaseDate(Pid);
                var resultDB =
                    from orders in PStaticModel.NowProduct
                    where orders.Product_Pid > 0
                    orderby orders.Product_Pid descending
                    select orders;
                var resultTemp =
                    from orders in PStaticModel.NowProduct
                    where orders.Product_Pid < 0
                    orderby orders.Product_Pid
                    select orders;
                var result = resultTemp.ToList();
                foreach (var item in resultDB.ToList())
                {
                    result.Add(item);
                }
                RepProductList.DataSource = result;
                RepProductList.DataBind();


                TotalPrice.Text = $"總計 NT{PStaticModel.ProductTotal}";
            }
        }

        protected void DelProduct_Click(object sender, EventArgs e)
        {
            List<string> DelOrder = new List<string>();
            foreach (RepeaterItem item in RepProductList.Items) 
            {
                CheckBox checkBox = item.FindControl("CheckBoxD") as CheckBox;
                if (checkBox.Checked)
                {
                    DelOrder.Add(checkBox.ToolTip);
                }
            }
            LinQDBTool linQDB = new LinQDBTool();
            linQDB.DelOrderProduct(DelOrder);
            BuildProductTableTemp();
        }

        protected void CreateOrder_Click(object sender, EventArgs e)
        {
            string qid = Request.QueryString["ID"];
            LinQDBTool dBTool = new LinQDBTool();
            PSOrderSystemContext context = new PSOrderSystemContext();
            DateTime purchasedate = Convert.ToDateTime(datepicker.Text);
            var nowassests = context.Moneys.Where(obj => obj.money_totalmoneyID == 1).FirstOrDefault();
            decimal assests = nowassests.money_totalmoney;
            if (string.IsNullOrEmpty(qid))
            {
                dBTool.InsertPurchase(PurchaseOrderNum.Text, purchasedate, assests, PStaticModel.NowProduct);
                nowassests.money_totalmoney = assests - PStaticModel.ProductTotal;
                context.SaveChanges();
                PStaticModel.NowProduct.Clear();
                PStaticModel.ProductTotal = 0;
                PStaticModel.FakePID = 0;
                Response.Redirect("~/PurchaseOrderList.aspx");
            }
            else
            {
                dBTool.UpdatePurchase(qid, purchasedate, assests, PStaticModel.NowProduct);
                nowassests.money_totalmoney = assests - PStaticModel.ProductTotal;
                context.SaveChanges();
                PStaticModel.NowProduct.Clear();
                PStaticModel.ProductTotal = 0;
                PStaticModel.FakePID = 0;
                Response.Redirect("~/PurchaseOrderList.aspx");
            }
        }

        protected void CancelOrder_Click(object sender, EventArgs e)
        {
            PStaticModel.NowProduct.Clear();
            PStaticModel.ProductTotal = 0;
            PStaticModel.FakePID = 0;
            Response.Redirect("~/PurchaseOrderList.aspx");
        }
    }
}
