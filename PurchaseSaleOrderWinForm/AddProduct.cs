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
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }
        public PurchaseCRUD mainform = null;
        int price;
        string pid;
        private void AddProduct_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'pSOrderSystemDataSet.Products' 資料表。您可以視需要進行移動或移除。
            this.productsTableAdapter.Fill(this.pSOrderSystemDataSet.Products);
            comboBox1.SelectedIndex = 0;
            BuildProductTable();
        }

        private void BuildProductTable()
        {
            using (var context = new PSOrderSystemContext())
            {
                int ProductID;
                if (comboBox1.SelectedValue != null)
                {
                    ProductID = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                    var prouductlist =
                    from product in context.Products
                    where product.product_id == ProductID
                    select product;

                    ProductNumber.Text = "商品編號：" + ProductID.ToString();

                    var productprice =
                    from product in context.Products
                    where product.product_id == ProductID
                    select product.product_price;

                    foreach (var item in productprice)
                    {
                        price = item;
                    }
                    //price = Convert.ToInt32(productprice.ToArray());
                    int num;
                    if (int.TryParse(NumTB.Text, out num))
                    {
                        TotalPrice.Text = (price * num).ToString();
                    }
                    else
                    {
                        TotalPrice.Text = (price * 0).ToString();
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void NumTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildProductTable();
        }

        private void NumTB_TextChanged(object sender, EventArgs e)
        {
            int num;
            if (int.TryParse(NumTB.Text, out num))
            {
                TotalPrice.Text = "NT" + (price * num).ToString();
            }
            else
            {
                TotalPrice.Text = "NT" + (price * 0).ToString();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            mainform.Show();
            this.Close();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            int ProductID = Convert.ToInt32(comboBox1.SelectedValue.ToString());

            using (var context = new PSOrderSystemContext())
            {
                var productprice =
                from product in context.Products
                where product.product_id == ProductID
                select product.product_price;

                foreach (var item in productprice)
                {
                    price = item;
                }
            }

            PStaticModel.FakePID--;
            OrderView order = new OrderView()
            {
                PO_OrderID = PStaticModel.FakePID,
                Product_Pid = ProductID,
                Product_Name = comboBox1.SelectedItem.ToString(),
                Product_Num = Convert.ToInt32(NumTB.Text),
                Product_Price = Convert.ToInt32(price),
            };
            PStaticModel.ProductTotal += (order.Product_Price * order.Product_Num);
            PStaticModel.NowProduct.Add(order);

            mainform.Show();
            mainform.BuildProductTableTemp();
            this.Close();
        }
    }
}
