
namespace PurchaseSaleOrderWinForm
{
    partial class PurchaseOrderList
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
            this.LogOut = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AddOrder = new System.Windows.Forms.Button();
            this.DeleteOrder = new System.Windows.Forms.Button();
            this.UpdateOrder = new System.Windows.Forms.Button();
            this.CReportOut = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.PID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(593, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "進貨單管理";
            // 
            // LogOut
            // 
            this.LogOut.Location = new System.Drawing.Point(1261, 37);
            this.LogOut.Name = "LogOut";
            this.LogOut.Size = new System.Drawing.Size(75, 23);
            this.LogOut.TabIndex = 1;
            this.LogOut.Text = "登出";
            this.LogOut.UseVisualStyleBackColor = true;
            this.LogOut.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1408, 426);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // AddOrder
            // 
            this.AddOrder.BackColor = System.Drawing.Color.Green;
            this.AddOrder.ForeColor = System.Drawing.Color.White;
            this.AddOrder.Location = new System.Drawing.Point(90, 529);
            this.AddOrder.Name = "AddOrder";
            this.AddOrder.Size = new System.Drawing.Size(104, 38);
            this.AddOrder.TabIndex = 3;
            this.AddOrder.Text = "新增";
            this.AddOrder.UseVisualStyleBackColor = false;
            this.AddOrder.Click += new System.EventHandler(this.AddOrder_Click);
            // 
            // DeleteOrder
            // 
            this.DeleteOrder.BackColor = System.Drawing.Color.Red;
            this.DeleteOrder.ForeColor = System.Drawing.Color.White;
            this.DeleteOrder.Location = new System.Drawing.Point(380, 529);
            this.DeleteOrder.Name = "DeleteOrder";
            this.DeleteOrder.Size = new System.Drawing.Size(104, 38);
            this.DeleteOrder.TabIndex = 4;
            this.DeleteOrder.Text = "刪除";
            this.DeleteOrder.UseVisualStyleBackColor = false;
            this.DeleteOrder.Click += new System.EventHandler(this.DeleteOrder_Click);
            // 
            // UpdateOrder
            // 
            this.UpdateOrder.BackColor = System.Drawing.Color.Orange;
            this.UpdateOrder.ForeColor = System.Drawing.Color.White;
            this.UpdateOrder.Location = new System.Drawing.Point(235, 529);
            this.UpdateOrder.Name = "UpdateOrder";
            this.UpdateOrder.Size = new System.Drawing.Size(104, 38);
            this.UpdateOrder.TabIndex = 5;
            this.UpdateOrder.Text = "修改";
            this.UpdateOrder.UseVisualStyleBackColor = false;
            this.UpdateOrder.Click += new System.EventHandler(this.UpdateOrder_Click);
            // 
            // CReportOut
            // 
            this.CReportOut.BackColor = System.Drawing.Color.BlueViolet;
            this.CReportOut.ForeColor = System.Drawing.Color.White;
            this.CReportOut.Location = new System.Drawing.Point(1250, 529);
            this.CReportOut.Name = "CReportOut";
            this.CReportOut.Size = new System.Drawing.Size(104, 38);
            this.CReportOut.TabIndex = 6;
            this.CReportOut.Text = "水晶報表";
            this.CReportOut.UseVisualStyleBackColor = false;
            this.CReportOut.Click += new System.EventHandler(this.CReportOut_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // PID
            // 
            this.PID.AutoSize = true;
            this.PID.Location = new System.Drawing.Point(860, 37);
            this.PID.Name = "PID";
            this.PID.Size = new System.Drawing.Size(30, 15);
            this.PID.TabIndex = 8;
            this.PID.Text = "PID";
            // 
            // PurchaseOrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1432, 609);
            this.Controls.Add(this.PID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CReportOut);
            this.Controls.Add(this.UpdateOrder);
            this.Controls.Add(this.DeleteOrder);
            this.Controls.Add(this.AddOrder);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.LogOut);
            this.Controls.Add(this.label1);
            this.Name = "PurchaseOrderList";
            this.Text = "PurchaseOrderList";
            this.Load += new System.EventHandler(this.PurchaseOrderList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LogOut;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button AddOrder;
        private System.Windows.Forms.Button DeleteOrder;
        private System.Windows.Forms.Button UpdateOrder;
        private System.Windows.Forms.Button CReportOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label PID;
    }
}