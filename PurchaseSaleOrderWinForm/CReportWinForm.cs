using CrystalDecisions.Windows.Forms;
using PurchaseSaleOrderSystem;
using PurchaseSaleOrderSystem.Models;
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
    public partial class CReportWinForm : Form
    {
        public CReportWinForm()
        {
            InitializeComponent();
        }

        private void CReportWinForm_Load(object sender, EventArgs e)
        {
            using (var context = new PSOrderSystemContext())
            {
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
                PurchaseOrderListReport cr = new PurchaseOrderListReport();
                cr.SetDataSource(rep);

                crystalReportViewer1.ReportSource = cr;
            }
        }
    }
}
