using P00196750_Mohammad_Munem_Sarwar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P00196750_Mohammad_Munem_Sarwar_DDOOCP_Winter
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

            lblUser.Text = "Welcome " + clsUserTools.userName + "[" + clsUserTools.userType + "]";
            openChildForm(new frmHome());
        }


        private Form activeForm = null;
        private void openChildForm(Form childForm) // Function for opening other forms inside a from
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(childForm);
            pnlContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            clsUserTools.Uid = 0;
            clsUserTools.userName = "";
            clsUserTools.userType = "";

            this.Hide();
            frmLogin lg = new frmLogin();
            lg.ShowDialog();
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            openChildForm(new frmFood());
        }

        private void btnRestaurant_Click(object sender, EventArgs e)
        {
            openChildForm(new frmRestaurant());
        }

        private void btnResort_Click(object sender, EventArgs e)
        {
            openChildForm(new frmResort());
        }

        private void btnRide_Click(object sender, EventArgs e)
        {
            openChildForm(new frmRide());
        }

        private void btnGuide_Click(object sender, EventArgs e)
        {
            openChildForm(new frmGuide());
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            openChildForm(new frmReview());

        }

        private void btnIntro_Click(object sender, EventArgs e)
        {
            openChildForm(new frmHome());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new frmBooking());
        }

        private void btnBookingList_Click(object sender, EventArgs e)
        {
            openChildForm(new frmListBooking());
        }

        private void btnListReview_Click(object sender, EventArgs e)
        {
            openChildForm(new frmListReview());
        }
    }
}
