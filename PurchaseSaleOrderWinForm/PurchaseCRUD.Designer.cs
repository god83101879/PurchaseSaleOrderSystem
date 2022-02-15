
namespace PurchaseSaleOrderWinForm
{
    partial class PurchaseCRUD
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AddProduct = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.Complete = new System.Windows.Forms.Button();
            this.TotalPrice = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PID = new System.Windows.Forms.Label();
            this.PurchaseOrderTB = new System.Windows.Forms.TextBox();
            this.PurchaseDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(589, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "進貨單管理";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(34, 156);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1316, 363);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // AddProduct
            // 
            this.AddProduct.BackColor = System.Drawing.Color.Green;
            this.AddProduct.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.AddProduct.ForeColor = System.Drawing.Color.White;
            this.AddProduct.Location = new System.Drawing.Point(95, 58);
            this.AddProduct.Name = "AddProduct";
            this.AddProduct.Size = new System.Drawing.Size(77, 31);
            this.AddProduct.TabIndex = 2;
            this.AddProduct.Text = "新增";
            this.AddProduct.UseVisualStyleBackColor = false;
            this.AddProduct.Click += new System.EventHandler(this.AddProduct_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.Red;
            this.Delete.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Delete.ForeColor = System.Drawing.Color.White;
            this.Delete.Location = new System.Drawing.Point(231, 58);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(77, 31);
            this.Delete.TabIndex = 3;
            this.Delete.Text = "刪除";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Cancel
            // 
            this.Cancel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Cancel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Cancel.ForeColor = System.Drawing.Color.White;
            this.Cancel.Location = new System.Drawing.Point(231, 537);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(77, 31);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = false;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Complete
            // 
            this.Complete.BackColor = System.Drawing.Color.Green;
            this.Complete.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Complete.ForeColor = System.Drawing.Color.White;
            this.Complete.Location = new System.Drawing.Point(95, 537);
            this.Complete.Name = "Complete";
            this.Complete.Size = new System.Drawing.Size(77, 31);
            this.Complete.TabIndex = 5;
            this.Complete.Text = "完成";
            this.Complete.UseVisualStyleBackColor = false;
            this.Complete.Click += new System.EventHandler(this.Complete_Click);
            // 
            // TotalPrice
            // 
            this.TotalPrice.AutoSize = true;
            this.TotalPrice.Font = new System.Drawing.Font("新細明體", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TotalPrice.Location = new System.Drawing.Point(973, 537);
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.Size = new System.Drawing.Size(114, 33);
            this.TotalPrice.TabIndex = 6;
            this.TotalPrice.Text = "總計：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(264, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 28);
            this.label3.TabIndex = 7;
            this.label3.Text = "單號：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(760, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 28);
            this.label4.TabIndex = 8;
            this.label4.Text = "進貨日期：";
            // 
            // PID
            // 
            this.PID.AutoSize = true;
            this.PID.Location = new System.Drawing.Point(231, 22);
            this.PID.Name = "PID";
            this.PID.Size = new System.Drawing.Size(30, 15);
            this.PID.TabIndex = 9;
            this.PID.Text = "PID";
            // 
            // PurchaseOrderTB
            // 
            this.PurchaseOrderTB.Location = new System.Drawing.Point(367, 104);
            this.PurchaseOrderTB.Name = "PurchaseOrderTB";
            this.PurchaseOrderTB.Size = new System.Drawing.Size(183, 25);
            this.PurchaseOrderTB.TabIndex = 10;
            // 
            // PurchaseDate
            // 
            this.PurchaseDate.Location = new System.Drawing.Point(910, 104);
            this.PurchaseDate.Name = "PurchaseDate";
            this.PurchaseDate.Size = new System.Drawing.Size(214, 25);
            this.PurchaseDate.TabIndex = 11;
            // 
            // PurchaseCRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1379, 600);
            this.Controls.Add(this.PurchaseDate);
            this.Controls.Add(this.PurchaseOrderTB);
            this.Controls.Add(this.PID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TotalPrice);
            this.Controls.Add(this.Complete);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.AddProduct);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "PurchaseCRUD";
            this.Text = "PurchaseCRUD";
            this.Load += new System.EventHandler(this.PurchaseCRUD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button AddProduct;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Complete;
        private System.Windows.Forms.Label TotalPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label PID;
        private System.Windows.Forms.TextBox PurchaseOrderTB;
        private System.Windows.Forms.DateTimePicker PurchaseDate;
    }
}