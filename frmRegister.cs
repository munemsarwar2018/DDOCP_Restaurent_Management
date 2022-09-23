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
    public partial class frmRegister : Form
    {

        SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BookingDB.mdf;Integrated Security=True"); 
        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }

        private void clearFields() // clearing data from data entry panel
        {
            txtUser.Text = "";
            txtPass.Text = "";
            txtConPassword.Text = "";
            txtAddress.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
            
        }
        private void btnSignUp_Click(object sender, EventArgs e)
        {
           


            if (txtUser.Text != "" && txtPass.Text != "" && txtConPassword.Text != "") // checking blank input fields
            {

                if (txtPass.Text == txtConPassword.Text)
                {
                    SqlCommand cmd = new SqlCommand("Select * from tblUser where username='" + txtUser.Text + "'", cnn);

                    cnn.Open(); 
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read()) 
                    {
                        dr.Close();
                        MessageBox.Show("Username Already exist please try another", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // error message for existing information
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand("Insert into tblUser values(@username,@password,@address,@mobile,@email,@utype)", cnn); 
                        cmd.Parameters.AddWithValue("@username", txtUser.Text);
                        cmd.Parameters.AddWithValue("@password", txtPass.Text);
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@mobile", txtMobile.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("utype", "Customer");

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Your account is created. Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearFields();
                    }

                }

                else
                {
                    MessageBox.Show("Please enter both password same ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Error message for different password input

                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cnn.Close(); // data base connection closed

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPass.Checked == true)
            {
                txtPass.UseSystemPasswordChar = false;
                txtConPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
                txtConPassword.UseSystemPasswordChar = true;
            }
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmLogin Login = new frmLogin();
            Login.ShowDialog();
        }
    }
}
