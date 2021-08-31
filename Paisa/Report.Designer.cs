
namespace Paisa
{
    partial class Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.dataGridViewSales = new System.Windows.Forms.DataGridView();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSalesReport = new System.Windows.Forms.Button();
            this.btnSalesPerProduct = new System.Windows.Forms.Button();
            this.btnSalesOfSelectedProduct = new System.Windows.Forms.Button();
            this.listProducts = new System.Windows.Forms.ListBox();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(205)))), ((int)(((byte)(99)))));
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 100);
            this.panel1.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(205)))), ((int)(((byte)(99)))));
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(0, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(85, 40);
            this.btnBack.TabIndex = 22;
            this.btnBack.Text = "< Utilities";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 20F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 41);
            this.label1.TabIndex = 21;
            this.label1.Text = "Reports";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(205)))), ((int)(((byte)(99)))));
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(152)))), ((int)(((byte)(227)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(852, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(48, 42);
            this.button6.TabIndex = 20;
            this.button6.Text = "x";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(205)))), ((int)(((byte)(99)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(736, 0);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(110, 40);
            this.btnLogout.TabIndex = 19;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // dataGridViewSales
            // 
            this.dataGridViewSales.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSales.Location = new System.Drawing.Point(0, 220);
            this.dataGridViewSales.Name = "dataGridViewSales";
            this.dataGridViewSales.RowHeadersVisible = false;
            this.dataGridViewSales.RowHeadersWidth = 51;
            this.dataGridViewSales.RowTemplate.Height = 24;
            this.dataGridViewSales.Size = new System.Drawing.Size(900, 285);
            this.dataGridViewSales.TabIndex = 1;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.AllowDrop = true;
            this.dtpFromDate.CalendarFont = new System.Drawing.Font("Calibri", 10F);
            this.dtpFromDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.dtpFromDate.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpFromDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(205)))), ((int)(((byte)(99)))));
            this.dtpFromDate.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFromDate.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.dtpFromDate.Font = new System.Drawing.Font("Calibri", 10F);
            this.dtpFromDate.Location = new System.Drawing.Point(628, 106);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(260, 28);
            this.dtpFromDate.TabIndex = 3;
            this.dtpFromDate.Value = new System.DateTime(2021, 8, 22, 0, 0, 0, 0);
            // 
            // dtpToDate
            // 
            this.dtpToDate.AllowDrop = true;
            this.dtpToDate.CalendarFont = new System.Drawing.Font("Calibri", 10F);
            this.dtpToDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.dtpToDate.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpToDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(205)))), ((int)(((byte)(99)))));
            this.dtpToDate.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpToDate.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.dtpToDate.Font = new System.Drawing.Font("Calibri", 10F);
            this.dtpToDate.Location = new System.Drawing.Point(628, 140);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(260, 28);
            this.dtpToDate.TabIndex = 4;
            this.dtpToDate.Value = new System.DateTime(2021, 8, 22, 0, 0, 0, 0);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(205)))), ((int)(((byte)(99)))));
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(152)))), ((int)(((byte)(227)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 15F);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(12, 174);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(170, 40);
            this.btnPrint.TabIndex = 21;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSalesReport
            // 
            this.btnSalesReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(205)))), ((int)(((byte)(99)))));
            this.btnSalesReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalesReport.FlatAppearance.BorderSize = 0;
            this.btnSalesReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(152)))), ((int)(((byte)(227)))));
            this.btnSalesReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesReport.Font = new System.Drawing.Font("Calibri", 15F);
            this.btnSalesReport.ForeColor = System.Drawing.Color.White;
            this.btnSalesReport.Location = new System.Drawing.Point(628, 174);
            this.btnSalesReport.Name = "btnSalesReport";
            this.btnSalesReport.Size = new System.Drawing.Size(260, 40);
            this.btnSalesReport.TabIndex = 22;
            this.btnSalesReport.Text = "Sales Report";
            this.btnSalesReport.UseVisualStyleBackColor = false;
            this.btnSalesReport.Click += new System.EventHandler(this.btnSalesReport_Click);
            // 
            // btnSalesPerProduct
            // 
            this.btnSalesPerProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(205)))), ((int)(((byte)(99)))));
            this.btnSalesPerProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalesPerProduct.FlatAppearance.BorderSize = 0;
            this.btnSalesPerProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(152)))), ((int)(((byte)(227)))));
            this.btnSalesPerProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesPerProduct.Font = new System.Drawing.Font("Calibri", 15F);
            this.btnSalesPerProduct.ForeColor = System.Drawing.Color.White;
            this.btnSalesPerProduct.Location = new System.Drawing.Point(12, 106);
            this.btnSalesPerProduct.Name = "btnSalesPerProduct";
            this.btnSalesPerProduct.Size = new System.Drawing.Size(170, 40);
            this.btnSalesPerProduct.TabIndex = 24;
            this.btnSalesPerProduct.Text = "Product Sales";
            this.btnSalesPerProduct.UseVisualStyleBackColor = false;
            this.btnSalesPerProduct.Click += new System.EventHandler(this.btnSalesPerProduct_Click);
            // 
            // btnSalesOfSelectedProduct
            // 
            this.btnSalesOfSelectedProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(205)))), ((int)(((byte)(99)))));
            this.btnSalesOfSelectedProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalesOfSelectedProduct.FlatAppearance.BorderSize = 0;
            this.btnSalesOfSelectedProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(152)))), ((int)(((byte)(227)))));
            this.btnSalesOfSelectedProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesOfSelectedProduct.Font = new System.Drawing.Font("Calibri", 15F);
            this.btnSalesOfSelectedProduct.ForeColor = System.Drawing.Color.White;
            this.btnSalesOfSelectedProduct.Location = new System.Drawing.Point(320, 174);
            this.btnSalesOfSelectedProduct.Name = "btnSalesOfSelectedProduct";
            this.btnSalesOfSelectedProduct.Size = new System.Drawing.Size(190, 40);
            this.btnSalesOfSelectedProduct.TabIndex = 25;
            this.btnSalesOfSelectedProduct.Text = "Sales Of Product";
            this.btnSalesOfSelectedProduct.UseVisualStyleBackColor = false;
            this.btnSalesOfSelectedProduct.Click += new System.EventHandler(this.btnSalesOfSelectedProduct_Click);
            // 
            // listProducts
            // 
            this.listProducts.Font = new System.Drawing.Font("Calibri", 13F);
            this.listProducts.FormattingEnabled = true;
            this.listProducts.ItemHeight = 27;
            this.listProducts.Location = new System.Drawing.Point(320, 119);
            this.listProducts.Name = "listProducts";
            this.listProducts.Size = new System.Drawing.Size(190, 31);
            this.listProducts.TabIndex = 26;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.DocumentName = "";
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 506);
            this.Controls.Add(this.listProducts);
            this.Controls.Add(this.btnSalesOfSelectedProduct);
            this.Controls.Add(this.btnSalesPerProduct);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.btnSalesReport);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dataGridViewSales);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView dataGridViewSales;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSalesReport;
        private System.Windows.Forms.Button btnSalesPerProduct;
        private System.Windows.Forms.Button btnSalesOfSelectedProduct;
        private System.Windows.Forms.ListBox listProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}