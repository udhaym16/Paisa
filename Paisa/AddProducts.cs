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
    public partial class AddProducts : Form
    {
        String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Paisa.Properties.Settings.PracticeSQLConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection();
        String userName;
        int productID = 0;
        public AddProducts(String username)
        {
            InitializeComponent();
            con.ConnectionString = connectionString;
            userName = username;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(txtProductName.Text == "" || txtProductPrice.Text=="" || txtQuantity.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    bool exists = false;
                    for (int i = 0; i < dataGridViewProducts.Rows.Count-1; i++)
                    {
                        if (dataGridViewProducts.Rows[i].Cells[1].Value.ToString() == txtProductName.Text)
                        {
                            MessageBox.Show("Similar product exists");
                            exists = true;
                            break;
                        }
                        else
                        {
                            exists = false;
                        }
                    }
                    if (exists == false)
                    {
                        String insertProduct = "insert into product values('" + txtProductName.Text.ToLower() + "'," + getCategoryID(listCategory.Text) + "," + txtQuantity.Text + "," + txtProductPrice.Text + ")";
                        con.Open();
                        SqlCommand cmd = new SqlCommand(insertProduct, con);
                        cmd.ExecuteNonQuery();
                        clearText();
                        populate();
                        MessageBox.Show("Product Added Successfully");
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (productID != 0)
                {
                    String update = "UPDATE product SET product_name = '" + txtProductName.Text + "', category_id = " + getCategoryID(listCategory.Text) + ", product_quantity = " + txtQuantity.Text + ",product_price = " + txtProductPrice.Text + " WHERE product_id = " + productID + "";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(update, con);
                    cmd.ExecuteNonQuery();
                    clearText();
                    MessageBox.Show("Product Updated Successfully");
                    con.Close();
                    populate();
                    productID = 0;
                }
                else
                {
                    MessageBox.Show("Select Correct Option");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"at update");
            }
        }

        public int getCategoryID(string categoryName)
        {
            
            int cat_id = 0;
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = "select category_id from category where category_name = '" +categoryName+ "'";
            con.Open();
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                cat_id = int.Parse(dr[0].ToString());
            }
            con.Close();
            return cat_id;
        }

        private void AddProducts_Load(object sender, EventArgs e)
        {
            populate();
            populateList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void populateList()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select category_name from category";
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                listCategory.Items.Add(dr["category_name"]);
            }
            con.Close();
        }
        private void populate()
        {
            
            String sql = "select p.product_id as [Product ID], p.product_name as [Product Name], c.category_name as [Category Name], p.product_quantity as [Quantity], p.product_price as [Unit Price] " +
                "from product p join category c on p.category_id = c.category_id";
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sql,con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adp);
            var ds = new DataSet();
            adp.Fill(ds);
            dataGridViewProducts.DataSource = ds.Tables[0];
            con.Close();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearText();   
        }
        private void clearText()
        {
            
            txtProductName.Text = "";
            txtProductPrice.Text = "";
            txtQuantity.Text = "";
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void dataGridViewProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewProducts.Rows[e.RowIndex];
                productID = int.Parse(row.Cells["Product ID"].Value.ToString());
                txtProductName.Text = row.Cells["Product Name"].Value.ToString();
                txtProductPrice.Text = row.Cells["Unit Price"].Value.ToString();
                txtQuantity.Text = row.Cells["Quantity"].Value.ToString();
                listCategory.SelectedItem = row.Cells["Category Name"].Value;
            }
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Utilities ui = new Utilities(userName);
            ui.Show();
            this.Close();
        }
    }
}
