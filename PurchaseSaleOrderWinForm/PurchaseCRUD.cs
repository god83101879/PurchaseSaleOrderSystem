using PurchaseSaleOrderSystem.Models;
using PurchaseSaleOrderSystem.Utility;
using PurchaseSaleOrderSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurchaseSaleOrderWinForm
{
    public partial class PurchaseCRUD : Form
    {
        public PurchaseCRUD()
        {
            InitializeComponent();
        }
        public PurchaseOrderList mainform = null;
        public string ID = null;
        private void PurchaseCRUD_Load(object sender, EventArgs e)
        {
            if (PStaticModel.FakePID == 0)
            {
                BuildProductTable();
            }
            else
            {
                BuildProductTableTemp();
            }
        }

        private void BuildProductTable()
        {
            if (string.IsNullOrWhiteSpace(ID))
            {
                DateTime nowtime = DateTime.Now;
                PurchaseOrderTB.Text = $"A{nowtime.ToString("yyyyMMddHHmm")}-{Program.LoginInfo.User_ID}";
                PurchaseDate.Text = nowtime.ToString("yyyy-MM-dd HH:mm");

                PStaticModel.ProductTotal = 0;
                PStaticModel.NowProduct = new List<OrderView>();

                TotalPrice.Text = $"總計 NT{PStaticModel.ProductTotal}";
            }
            else
            {
                PurchaseOrderTB.Text = ID;

                PurchaseDate.Text = GetPurchaseDate(ID);
                decimal FullPrice;

                using (var context = new PSOrderSystemContext())
                {
                    var orderslist =
                         from orders in context.PurchaseOrders
                         join prouducts in context.Products on orders.purchaseorder_producid equals prouducts.product_id
                         where orders.purchaseorder_orderid == ID && orders.purchaseorder_remover == null
                         orderby orders.purchaseorder_pid descending
                         select new OrderView
                         {
                             PO_OrderID = orders.purchaseorder_pid,
                             Product_Pid = orders.purchaseorder_producid,
                             Product_Name = prouducts.product_name,
                             Product_Num = orders.purchaseorder_productnum,
                             Product_Price = prouducts.product_price
                         };

                    List<OrderView> result = orderslist.ToList();

                    FullPrice = 0;
                    foreach (var item in result)
                    {
                        FullPrice += item.TotalPrice;
                    }
                    PStaticModel.ProductTotal = FullPrice;
                    PStaticModel.NowProduct = result;
                    dataGridView1.DataSource = PStaticModel.NowProduct.ToList();
                }

                TotalPrice.Text = "總計NT" + PStaticModel.ProductTotal.ToString();
                PID.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            }
        }

        public void BuildProductTableTemp()
        {
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
            dataGridView1.DataSource = result.ToList();
            TotalPrice.Text = "總計NT" + PStaticModel.ProductTotal.ToString();
        }

        public string GetPurchaseDate(string PID)
        {
            using (var context = new PSOrderSystemContext())
            {
                var date = from purchase in context.PurchaseOrders
                           where purchase.purchaseorder_orderid == PID
                           select purchase.purchaseorder_date;

                return date.FirstOrDefault().ToString("yyyy-MM-dd HH:mm");
            }
        }

        private void AddProduct_Click(object sender, EventArgs e)
        {
            AddProduct selectform = new AddProduct();
            selectform.mainform = this;
            selectform.Show();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (Del() == true)
            {
                using (var context = new PSOrderSystemContext())
                {
                    int idtemp = Convert.ToInt32(PID.Text);
                    if (idtemp > 0)
                    {
                        var delorder =
                            context.PurchaseOrders.Where(obj => obj.purchaseorder_producid == idtemp && obj.purchaseorder_remover == null).FirstOrDefault();
                        if (delorder != null)
                        {
                            delorder.purchaseorder_remover = "Daniel";
                            delorder.purchaseorder_removedate = DateTime.Now;
                            var prodprice =
                                context.Products.Where(obj => obj.product_id == delorder.purchaseorder_producid).FirstOrDefault();

                            PStaticModel.ProductTotal -= prodprice.product_price * delorder.purchaseorder_productnum;
                            PStaticModel.NowProduct.Remove(PStaticModel.NowProduct.Where(obj => obj.Product_Pid == idtemp).FirstOrDefault());
                        }

                    }
                    else
                    {
                        var selectorder = PStaticModel.NowProduct.Where(obj => obj.Product_Pid == idtemp).FirstOrDefault();
                        PStaticModel.ProductTotal -= selectorder.Product_Num * selectorder.Product_Price;
                        PStaticModel.NowProduct.Remove(selectorder);
                    }

                    context.SaveChanges();
                }
            }
        }

        public static bool Del()
        {
            const string Alertmessage = "確定刪除所選進貨單?";
            const string caption = "Cancel Installer";
            var result = MessageBox.Show(Alertmessage, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            mainform.Show();
            mainform.BuildDataTableCommit();
            this.Close();
        }

        private void Complete_Click(object sender, EventArgs e)
        {
            using (var context = new PSOrderSystemContext())
            {
                DateTime purdate = Convert.ToDateTime(PurchaseDate.Text);
                var totalmoney = context.Moneys.Where(obj => obj.money_totalmoneyID == 1).FirstOrDefault();
                decimal assests = totalmoney.money_totalmoney;
                if (string.IsNullOrEmpty(ID))
                {
                    var updpurchase =
                             context.PurchaseOrders.Where(obj => obj.purchaseorder_orderid == PurchaseOrderTB.Text && obj.purchaseorder_remover == null).FirstOrDefault();
                    if (updpurchase == null)
                    {
                        foreach (var item in PStaticModel.NowProduct)
                        {
                            PurchaseOrder addpur = new PurchaseOrder()
                            {
                                purchaseorder_orderid = PurchaseOrderTB.Text,
                                purchaseorder_userid = Program.LoginInfo.User_ID,
                                purchaseorder_date = purdate,
                                purchaseorder_producid = item.Product_Pid,
                                purchaseorder_productnum = item.Product_Num,
                                purchaseorder_totalcost = (item.Product_Price * item.Product_Num),
                                purchaseorder_creator = "Daniel",
                                purchaseorder_createdate = DateTime.Now
                            };
                            context.PurchaseOrders.Add(addpur);
                            context.SaveChanges();
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    var updpurchase =
                             context.PurchaseOrders.Where(obj => obj.purchaseorder_orderid == PurchaseOrderTB.Text && obj.purchaseorder_remover == null).FirstOrDefault();
                    decimal lastassets = assests + updpurchase.purchaseorder_totalcost;
                    if (updpurchase != null)
                    {
                        foreach (var item in PStaticModel.NowProduct)
                        {
                            var updorder =
                                context.PurchaseOrders.Where(obj => obj.purchaseorder_pid == item.PO_OrderID && obj.purchaseorder_remover == null).FirstOrDefault();
                            if (updorder == null)
                            {
                                PurchaseOrder addpur = new PurchaseOrder()
                                {
                                    purchaseorder_orderid = PurchaseOrderTB.Text,
                                    purchaseorder_userid = Program.LoginInfo.User_ID,
                                    purchaseorder_date = purdate,
                                    purchaseorder_producid = item.Product_Pid,
                                    purchaseorder_productnum = item.Product_Num,
                                    purchaseorder_totalcost = (item.Product_Price * item.Product_Num),
                                    purchaseorder_creator = "Daniel",
                                    purchaseorder_createdate = DateTime.Now
                                };
                                context.PurchaseOrders.Add(addpur);
                                context.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                PStaticModel.NowProduct.Clear();
                PStaticModel.ProductTotal = 0;
                PStaticModel.FakePID = 0;
                mainform.Show();
                mainform.BuildDataTableCommit();
                this.Close();
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                PID.Text = row.Cells[0].Value.ToString();
            }
        }
    }
}
