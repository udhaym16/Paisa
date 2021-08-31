using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paisa
{
    public partial class Report : Form
    {
        String userName;
        Bitmap bitmap;
        String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Paisa.Properties.Settings.PracticeSQLConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection();
        public Report(String username)
        {
            InitializeComponent();
            con.ConnectionString = connectionString;
            userName = username;
        }

        public void populateList()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select product_name from product";
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                listProducts.Items.Add(dr["product_name"].ToString());
                
            }
       
            con.Close();
            
            Console.WriteLine(listProducts.Items.Count);
        }
        
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            populateList();
        }

        private void btnSalesReport_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String ordersBetweenDate = "select a.order_id as [Order Id], u.firstname as [Employee], a.emp_id as [Employee ID], a.total_amount as [Total Amount], a.order_date as [Order Date], a.order_status as [Fullfiled] " +
                    "from order_table a join users u on a.emp_id = u.emp_id " +
                    "where a.order_date between DATEFROMPARTS(" + dtpFromDate.Value.Year + "," + dtpFromDate.Value.Month + "," + dtpFromDate.Value.Day + ") and DATEFROMPARTS(" + dtpToDate.Value.Year + "," + dtpToDate.Value.Month + "," + dtpToDate.Value.Day + ")";
                SqlDataAdapter adp = new SqlDataAdapter(ordersBetweenDate, con);
                SqlCommandBuilder builder = new SqlCommandBuilder(adp);
                var ds = new DataSet();
                adp.Fill(ds);
                dataGridViewSales.DataSource = ds.Tables[0];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSalesOfSelectedProduct_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String sql = "select op.order_id as [Order ID], p.product_name [Product], op.product_quantity as [Quantity],p.product_price as [Price per Unit], (op.product_quantity*p.product_price) as [Amount], a.order_date as [Order Date]" +
                    "from order_product op join order_table a on op.order_id = a.order_id join product p on op.product_id = p.product_id " +
                    "where p.product_name='"+listProducts.Text+"' and a.order_date between DATEFROMPARTS(" + dtpFromDate.Value.Year + "," + dtpFromDate.Value.Month + "," + dtpFromDate.Value.Day + ") and DATEFROMPARTS(" + dtpToDate.Value.Year + "," + dtpToDate.Value.Month + "," + dtpToDate.Value.Day + ")";
                SqlDataAdapter adp = new SqlDataAdapter(sql, con);
                SqlCommandBuilder builder = new SqlCommandBuilder(adp);
                var ds = new DataSet();
                adp.Fill(ds);
                dataGridViewSales.DataSource = ds.Tables[0];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalesPerProduct_Click(object sender, EventArgs e)
        {
            con.Open();
            String sql = "select p.product_name as [Product Name],p.product_price as [Price per Unit], sum(op.product_quantity) as [Quantity Sold],p.product_quantity as [In Stock], sum(op.product_quantity*p.product_price) as [Total Amount] " +
                "from order_product op join product p on op.product_id = p.product_id join order_table a on op.order_id = a.order_id " +
                "where a.order_date between DATEFROMPARTS(" + dtpFromDate.Value.Year + "," + dtpFromDate.Value.Month + "," + dtpFromDate.Value.Day + ") and DATEFROMPARTS(" + dtpToDate.Value.Year + "," + dtpToDate.Value.Month + "," + dtpToDate.Value.Day + ")" +
                "group by p.product_name,p.product_price,p.product_quantity " +
                "order by[Quantity Sold] desc; ";
            SqlDataAdapter adp = new SqlDataAdapter(sql, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adp);
            var ds = new DataSet();
            adp.Fill(ds);
            dataGridViewSales.DataSource = ds.Tables[0];
            con.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Utilities ui = new Utilities(userName);
            ui.Show();
            this.Hide();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            bitmap = new Bitmap(this.dataGridViewSales.Width, this.dataGridViewSales.RowCount * dataGridViewSales.RowTemplate.Height);
            dataGridViewSales.DrawToBitmap(bitmap, new Rectangle(0, 0, this.dataGridViewSales.Width, this.dataGridViewSales.RowCount * dataGridViewSales.RowTemplate.Height));
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
}
