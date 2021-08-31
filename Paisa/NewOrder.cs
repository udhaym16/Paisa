using System;
using System.Configuration;
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
    public partial class NewOrder : Form
    {
        String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Paisa.Properties.Settings.PracticeSQLConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection();
        
        String userName;
        double price = 0;
        int pId = 0;
        int inStock = 0;
        public NewOrder(String username)
        {
            InitializeComponent();
            con.ConnectionString = connectionString;
            populateList();
            userName = username;
        }
        public void populateList()
        {
            con.Open();
            String sql = "select p.product_id as [Product ID], p.product_name as [Product Name],c.category_name as [Category Name],p.product_quantity as [Quantity],p.product_price as [Price per Unit] " +
                "from product p join category c on p.category_id = c.category_id order by c.category_name";
            SqlDataAdapter adp = new SqlDataAdapter(sql, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adp);
            var ds = new DataSet();
            adp.Fill(ds);
            dataGridViewProducts.DataSource = ds.Tables[0];
            con.Close();
        }
        public int getEmpID(string username)
        {
            int emp_id = 0;
            con.Open();
            String sql = "select emp_id from users where username ='" + userName + "'";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                emp_id = Convert.ToInt32(reader[0].ToString());
            }
            con.Close();
            return emp_id;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            previousPage();
        }
        public void previousPage()
        {
            Utilities ui = new Utilities(userName);
            ui.Show();
            this.Close();
        }
        //Get the content of row that was clicked.
        private void dataGridViewProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewProducts.Rows[e.RowIndex];
                if (int.Parse(row.Cells["Quantity"].Value.ToString()) == 0)
                {
                    MessageBox.Show("Product out of Stock");
                }
                else
                {
                    pId = int.Parse(row.Cells["Product ID"].Value.ToString());
                    price = float.Parse(row.Cells["Price per Unit"].Value.ToString());
                    txtSelectedProduct.Text = row.Cells["Product Name"].Value.ToString();
                    inStock = int.Parse(row.Cells["Quantity"].Value.ToString());
                }
            }
        }
        public double productAmount()
        {
            double amount = (Convert.ToDouble(nudQuantity.Value) * price);
            return amount;
        }
        public double totalBill()
        {
            double total = 0;
            for (int row = 0; row < dataGridViewOrder.Rows.Count; row++)
            {
                total = total + double.Parse(dataGridViewOrder.Rows[row].Cells[4].Value.ToString());
            }
            return total;
        }
        
        //Add products to dataGridViewOrders
        private void button1_Click(object sender, EventArgs e)
        {
            bool exist = false;
            int quan = 0;
            if (txtSelectedProduct.Text == ""||pId == 0||nudQuantity.Value < 0)
            {
                MessageBox.Show("Please Select right Product and right quantity");
                nudQuantity.Value = 0;
                txtSelectedProduct.Text = "";
            }
            else
            {
                if (nudQuantity.Value > inStock)
                {
                    MessageBox.Show("Desired Quantity not available");
                }
                else
                {
                    if (dataGridViewOrder.Rows.Count == 0)
                    {
                        int na = dataGridViewOrder.Rows.Add();
                        dataGridViewOrder.Rows[na].Cells[0].Value = pId;
                        dataGridViewOrder.Rows[na].Cells[1].Value = txtSelectedProduct.Text;
                        dataGridViewOrder.Rows[na].Cells[2].Value = Convert.ToInt32(nudQuantity.Value);
                        dataGridViewOrder.Rows[na].Cells[3].Value = price;
                        dataGridViewOrder.Rows[na].Cells[4].Value = productAmount();
                    }
                    else
                    {
                        for (int row = 0; row < dataGridViewOrder.Rows.Count; row++)
                        {
                            if (int.Parse(dataGridViewOrder.Rows[row].Cells[0].Value.ToString()) == pId)
                            {
                                quan = Convert.ToInt32(nudQuantity.Value);
                                dataGridViewOrder.Rows[row].Cells[2].Value = quan;
                                dataGridViewOrder.Rows[row].Cells[4].Value = productAmount();
                                exist = true;
                                break;
                            }
                            else
                            {
                                exist = false;
                            }
                        }
                        if (exist == false)
                        {
                            int n = dataGridViewOrder.Rows.Add();
                            dataGridViewOrder.Rows[n].Cells[0].Value = pId;
                            dataGridViewOrder.Rows[n].Cells[1].Value = txtSelectedProduct.Text;
                            dataGridViewOrder.Rows[n].Cells[2].Value = Convert.ToInt32(nudQuantity.Value);
                            dataGridViewOrder.Rows[n].Cells[3].Value = price;
                            dataGridViewOrder.Rows[n].Cells[4].Value = productAmount();
                        }

                    }
                }
                txtSelectedProduct.Text = "";
                nudQuantity.Value = 0;
                txtTotalAmount.Text = totalBill().ToString();
            }
        }

        //Submit order and Enter Values to order_table and order_product table.
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = DateTime.Now; //Get Current date
                //String insertIntoOrders = "insert into order_table values(" + getEmpID(userName) + "," + double.Parse(txtTotalAmount.Text) + ",DATEFROMPARTS(" + dt.Year + "," + dt.Month + "," + dt.Day + "),"+ 0 +")";
                String insertIntoOrders = "insert into order_table values(" + getEmpID(userName) + "," + double.Parse(txtTotalAmount.Text) + ",DATEFROMPARTS(2020,01,01)," + 1 + ")";
                con.Open();
                SqlCommand cmdOrders = new SqlCommand(insertIntoOrders, con);
                cmdOrders.ExecuteNonQuery();
                String selectLastRow = "SELECT IDENT_CURRENT('order_table')";
                cmdOrders.CommandText = selectLastRow;
                var test = cmdOrders.ExecuteScalar();
                con.Close();
                
                for (int row = 0; row < dataGridViewOrder.Rows.Count; row++)
                {
                    String proID = dataGridViewOrder.Rows[row].Cells[0].Value.ToString();
                    int proOrdQuan = int.Parse(dataGridViewOrder.Rows[row].Cells[2].Value.ToString());

                    
                    String insertOrderProduct = "insert into order_product values("+test+","+ proID + ","+ proOrdQuan + ")";
                    con.Open();
                    cmdOrders.CommandText = insertOrderProduct;
                    cmdOrders.ExecuteNonQuery();
                    con.Close();

                    
                    int newStock = getInStock(proID) - proOrdQuan;
                    String updateStock = "UPDATE product SET product_quantity = " + newStock + " WHERE product_id = "+ proID +"";
                    con.Open();
                    cmdOrders.CommandText = updateStock;
                    cmdOrders.ExecuteNonQuery();
                    con.Close();
                }
                MessageBox.Show("Order Submitted Successfully");
                previousPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public int getInStock(String productId)
        {
            
            String selectQuantity = "select product_quantity from product where product_id = "+productId+"";
            con.Open();
            SqlCommand command = new SqlCommand(selectQuantity,con);
            int stock = int.Parse(command.ExecuteScalar().ToString());
            con.Close();
            return stock;
        }

        private void dataGridViewOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewOrder.Rows[e.RowIndex];
                pId = int.Parse(row.Cells[0].Value.ToString());
                txtSelectedProduct.Text = row.Cells[1].Value.ToString();
                nudQuantity.Value = int.Parse(row.Cells[2].Value.ToString());
                price = float.Parse(row.Cells[3].Value.ToString());
            }
        }
    }
}
