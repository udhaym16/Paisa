using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Paisa
{
    public partial class Utilities : Form
    {
        String userName;
        SqlConnection con = new SqlConnection(@"server=LP-PF1S5THC\SQLEXPRESS;Initial Catalog=PaisaDB;Integrated Security=True;");
        public void getName(string username)
        {
            
        }
        public Utilities(String username)
        {
            InitializeComponent();
            userName = username;
            lblWelcome.Text = "Welcome Back, ";
            
            String sql = "select username,firstname,access_level from users where username ='" + userName + "'";
            con.Open();
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lblWelcome.Text = "Welcome, " + reader[1].ToString();
                if (Convert.ToBoolean(reader[2]) == true)
                {
                    lblAccess.Text = "Your access level is Managment";
                }
                else
                {
                    lblAccess.Text = "Your access level is Cashier";
                    btnAddProducts.Visible = false;
                    btnReport.Visible = false;
                }
            }
            con.Close();

        }
        private void Utilities_Load(object sender, EventArgs e)
        {


        }
        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOrderList_Click(object sender, EventArgs e)
        {
            DailyOrders dailyOrder = new DailyOrders(userName);
            dailyOrder.Show();
            this.Close();
        }

        private void btnAddProducts_Click(object sender, EventArgs e)
        {
            AddProducts ad = new AddProducts(userName);
            ad.Show();
            this.Close();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Report r = new Report(userName);
            r.Show();
            this.Close();
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            NewOrder no = new NewOrder(userName);
            no.Show();
            this.Close();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }
    }
}
