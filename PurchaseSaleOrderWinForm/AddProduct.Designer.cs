
namespace PurchaseSaleOrderWinForm
{
    partial class AddProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.productsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pSOrderSystemDataSet = new PurchaseSaleOrderWinForm.PSOrderSystemDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.ProductNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TotalPrice = new System.Windows.Forms.Label();
            this.NumTB = new System.Windows.Forms.TextBox();
            this.Add = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.pSOrderSystemDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productsTableAdapter = new PurchaseSaleOrderWinForm.PSOrderSystemDataSetTableAdapters.ProductsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pSOrderSystemDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pSOrderSystemDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.productsBindingSource, "product_id", true));
            this.comboBox1.DataSource = this.productsBindingSource;
            this.comboBox1.DisplayMember = "product_name";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(123, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "product_id";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // productsBindingSource
            // 
            this.productsBindingSource.DataMember = "Products";
            this.productsBindingSource.DataSource = this.pSOrderSystemDataSet;
            // 
            // pSOrderSystemDataSet
            // 
            this.pSOrderSystemDataSet.DataSetName = "PSOrderSystemDataSet";
            this.pSOrderSystemDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 26);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "選擇商品";
            // 
            // ProductNumber
            // 
            this.ProductNumber.AutoSize = true;
            this.ProductNumber.Location = new System.Drawing.Point(39, 69);
            this.ProductNumber.Name = "ProductNumber";
            this.ProductNumber.Size = new System.Drawing.Size(82, 15);
            this.ProductNumber.TabIndex = 2;
            this.ProductNumber.Text = "商品編號：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "數量：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "小計：";
            // 
            // TotalPrice
            // 
            this.TotalPrice.AutoSize = true;
            this.TotalPrice.Location = new System.Drawing.Point(97, 151);
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.Size = new System.Drawing.Size(26, 15);
            this.TotalPrice.TabIndex = 5;
            this.TotalPrice.Text = "NT";
            // 
            // NumTB
            // 
            this.NumTB.Location = new System.Drawing.Point(100, 110);
            this.NumTB.Name = "NumTB";
            this.NumTB.Size = new System.Drawing.Size(100, 25);
            this.NumTB.TabIndex = 6;
            this.NumTB.TextChanged += new System.EventHandler(this.NumTB_TextChanged);
            this.NumTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumTB_KeyPress);
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.Color.Green;
            this.Add.ForeColor = System.Drawing.Color.White;
            this.Add.Location = new System.Drawing.Point(48, 197);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 7;
            this.Add.Text = "加入";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Cancel
            // 
            this.Cancel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Cancel.Location = new System.Drawing.Point(169, 197);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 8;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = false;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // pSOrderSystemDataSetBindingSource
            // 
            this.pSOrderSystemDataSetBindingSource.DataSource = this.pSOrderSystemDataSet;
            this.pSOrderSystemDataSetBindingSource.Position = 0;
            // 
            // productsTableAdapter
            // 
            this.productsTableAdapter.ClearBeforeFill = true;
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 271);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.NumTB);
            this.Controls.Add(this.TotalPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ProductNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "AddProduct";
            this.Text = "AddProduct";
            this.Load += new System.EventHandler(this.AddProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pSOrderSystemDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pSOrderSystemDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ProductNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label TotalPrice;
        private System.Windows.Forms.TextBox NumTB;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.BindingSource pSOrderSystemDataSetBindingSource;
        private PSOrderSystemDataSet pSOrderSystemDataSet;
        private System.Windows.Forms.BindingSource productsBindingSource;
        private PSOrderSystemDataSetTableAdapters.ProductsTableAdapter productsTableAdapter;
    }
}