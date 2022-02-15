using PurchaseSaleOrderSystem.Models;
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
    public partial class PurchaseOrderList : Form
    {
        public PurchaseOrderList()
        {
            InitializeComponent();
        }
        public Login main = null;
        private void PurchaseOrderList_Load(object sender, EventArgs e)
        {
            PStaticModel.NowProduct = new List<OrderView>();
            PStaticModel.ProductTotal = 0;
            PStaticModel.FakePID = 0;

            BuildDataTableCommit();
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            Program.LoginInfo.User_ID = 0;
            Program.LoginInfo.User_Account = null;
            Program.LoginInfo.User_Password = null;

            main.Show();
            this.Close();
        }

        public void BuildDataTableCommit()
        {
            using (var context = new PSOrderSystemContext())
            {
                var query =
                     from purchaseorders in context.PurchaseOrders
                     where purchaseorders.purchaseorder_remover == null
                     orderby purchaseorders.purchaseorder_date descending
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
                var result = query.ToList();
                List<PurchaseOrderListModel> lastresult = new List<PurchaseOrderListModel>();
                foreach (var item in result)
                {
                    PurchaseOrderListModel Temp = new PurchaseOrderListModel()
                    {
                        PurchaseOrderID = item.Purchaseorder_orderid.ToString(),
                        PurchaseOrder_PID = item.Purchaseorder_pid.ToString(),
                        ProductNum = item.Purchaseorder_productnum,
                        PurchaseDate = item.Purchaseorder_date,
                        PurchaseOrderCost = item.Purchaseorder_totalcost
                    };
                    lastresult.Add(Temp);
                }
                dataGridView1.DataSource = lastresult.ToList();
            }
        }

        private void AddOrder_Click(object sender, EventArgs e)
        {
            PurchaseCRUD purchaseCRUD = new PurchaseCRUD();
            purchaseCRUD.mainform = this;
            purchaseCRUD.Show();
            this.Hide();
        }

        private void UpdateOrder_Click(object sender, EventArgs e)
        {
            PurchaseCRUD purchaseCRUD = new PurchaseCRUD();
            purchaseCRUD.mainform = this;
            purchaseCRUD.ID = PID.Text;
            purchaseCRUD.Show();
            this.Hide();
        }

        private void DeleteOrder_Click(object sender, EventArgs e)
        {
            if (Del() == true)
            {
                using (var context = new PSOrderSystemContext())
                {                       
                        var deitem = context.PurchaseOrders.Where(obj => obj.purchaseorder_orderid == PID.Text).ToArray();
                        foreach (var item2 in deitem)
                        {
                            context.PurchaseOrders.Remove(item2); //一次移除一筆
                        }
                    context.SaveChanges();
                }
                BuildDataTableCommit();
                PID.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
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

        private void CReportOut_Click(object sender, EventArgs e)
        {
            CReportWinForm cReport = new CReportWinForm();
            cReport.Show();
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
