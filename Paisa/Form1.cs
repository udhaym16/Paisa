using System;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Paisa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        SqlConnection con = new SqlConnection(@"server=LP-PF1S5THC\SQLEXPRESS;Initial Catalog=PaisaDB;Integrated Security=True;");

        private void Form1_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void ErrorMessage(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
            System.Threading.Tasks.Task.Delay(3000).ContinueWith(_ =>
            {
                Invoke(new MethodInvoker(() => { lblError.Visible = false; }));
            });
        }
        private String EncodePassword(String password)
        {
            byte[] tmpSource;
            byte[] tmpHash;
            tmpSource = ASCIIEncoding.ASCII.GetBytes(password);
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            return Convert.ToBase64String(tmpHash);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                ErrorMessage("Missing Username or Password");
            }
            else
            {
                try
                {
                    string username = txtUsername.Text.Trim();
                    string password = txtPassword.Text.Trim();
                    username = username.ToLower();
                    password = EncodePassword(password);

                    con.Open();
                    String sql = "select username,password from users where username ='"+username+"' and password ='"+password+"'";
                    SqlCommand command = new SqlCommand(sql,con);
                    SqlDataReader reader = command.ExecuteReader();
                    bool login = false;
                    while (reader.Read())
                    {
                        if (reader[0].ToString().ToLower() == username && reader[1].ToString() == password)
                        {
                            login = true;
                        }
                        else login = false;
                    }
                    if (login == true)
                    {
                        Utilities ui = new Utilities(username);
                        ui.Show();
                        this.Hide();
                    }
                    else
                    {
                        ErrorMessage("Wrong Username or Password.\nContact Support to change Password.");
                    }
                    con.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
