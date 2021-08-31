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
    public partial class DailyOrders : Form
    {
        String userName;
        int orderId = 0;
        String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Paisa.Properties.Settings.PracticeSQLConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection();
        public DailyOrders(String username)
        {
            InitializeComponent();
            con.ConnectionString = connectionString;
            userName = username;
        }
        private void DailyOrders_Load(object sender, EventArgs e)
        {
            populate();
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            Utilities ui = new Utilities(userName);
            ui.Show();
            this.Close();
        }


        private void populate()
        {
            String sql = "select a.order_id as [Order Id], u.firstname as [Employee], a.total_amount as [Total Amount], a.order_date as [Order Date], a.order_status as [Fullfiled] " +
                    "from order_table a join users u on a.emp_id = u.emp_id " +
                    "where a.emp_id = '"+ getEmpID(userName) +"' and a.order_status = "+ 0 +"";
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sql, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adp);
            var ds = new DataSet();
            adp.Fill(ds);
            dataGridViewOrders.DataSource = ds.Tables[0];
            con.Close();
        }
        public int getEmpID(string username)
        {
            int emp_id = 0;
            String sql = "select emp_id from users where username ='" + username + "'";
            con.Open();
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                emp_id = Convert.ToInt32(reader[0].ToString());
            }
            con.Close();
            return emp_id;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                if (chkbxStatus.Checked == true)
                {
                    i = 1;
                } else i = 0;
                String updateStatus = "update order_table set order_status = " + i + " where order_id = " + orderId + "";
                con.Open();
                SqlCommand commandUpdate = new SqlCommand(updateStatus, con);
                commandUpdate.ExecuteNonQuery();
                con.Close();
                populate();
                clearFields();
                MessageBox.Show("Order Status Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void clearFields()
        {
            txtOrderId.Text = "";
            chkbxStatus.Checked = false;
        }

        private void dataGridViewOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewOrders.Rows[e.RowIndex];
                orderId = int.Parse(row.Cells["Order Id"].Value.ToString());
                txtOrderId.Text = orderId.ToString();
            }
        }
    }
}
