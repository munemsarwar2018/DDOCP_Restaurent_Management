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

namespace P00196750_Mohammad_Munem_Sarwar_DDOOCP_Winter
{
    public partial class frmLogin : Form
    {

        SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BookingDB.mdf;Integrated Security=True");
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
        }

        private void linkLabelRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmRegister register = new frmRegister();
            register.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPass.Text != String.Empty || txtUser.Text != String.Empty) // validation for empty input
            {
                cnn.Open(); // database connection open
                SqlCommand cmd = new SqlCommand("select * from tblUser where username='" + txtUser.Text + "' and password= '" + txtPass.Text + "'", cnn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read()) // login fuction for existing user data
                {
                    clsUserTools.Uid = Int32.Parse( dr.GetValue(0).ToString());
                    clsUserTools.userName = dr.GetValue(1).ToString();
                    clsUserTools.userType = dr.GetValue(6).ToString();

                    dr.Close();
                    this.Hide();
                    frmMenu menu = new frmMenu();
                    menu.ShowDialog();
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("No Account available with this username and password", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                cnn.Close();
            }
            else
            {
                MessageBox.Show("Please enter value in all field.",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPass.Checked == true)
            { txtPass.UseSystemPasswordChar = false; }
            else
            { txtPass.UseSystemPasswordChar = true; }

        }
    }
}
