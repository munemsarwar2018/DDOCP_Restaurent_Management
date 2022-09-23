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
    public partial class frmBooking : Form
    {
        SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BookingDB.mdf;Integrated Security=True");
        public frmBooking()
        {
            InitializeComponent();
        }

        private void frmBooking_Load(object sender, EventArgs e)
        {
            //fillComboBoxBooking();
            fillCombo2();

        }


        public void fillCombo2()
        {
            
            
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblBookingType", cnn))
                {
                    //Fill the DataTable with records from Table.
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    //Insert the Default Item to DataTable.
                    DataRow row = dt.NewRow();
                    row[0] = 0;
                    row[1] = "-- Please select --";
                    row[2] = 0;

                dt.Rows.InsertAt(row, 0);

                //Assign DataTable as DataSource.
                cboBookingType.DataSource = dt;
                cboBookingType.DisplayMember = "BookingType";
                cboBookingType.ValueMember = "Price";
                }
            
        }
        private void fillComboBoxBooking()
        {
            //SqlCommand cmd = new SqlCommand("Select * from tblBookingType", cnn);
            
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);


            //dt.Rows.Add(new Author() { Id = 0, Name = "[Please Select an Item]" });
            //dt.Rows.Add(new object[] {0, "-- Select --",0 });

            //cboBookingType.DataSource = dt;
            //cboBookingType.DisplayMember = "BookingType";
            //cboBookingType.ValueMember = "BookingType";

            cnn.Open();
            SqlCommand cmd = new SqlCommand("Select * from tblBookingType", cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DataRow drow = dt.NewRow();

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].ColumnName == "BookingType")
                {
                    drow[i] = "-- Select --";
                }
                else if (dt.Columns[i].ColumnName == "Price")
                {
                    drow[i] = 0;
                }
                else
                {
                    //drow[i] = null;
                }
            }

            dt.Rows.InsertAt(drow, 0);

            cboBookingType.DataSource = dt;
            cboBookingType.DisplayMember = "BookingType";
            cboBookingType.ValueMember = "Price";
            cboBookingType.SelectedIndex = 0;
            cnn.Close();

        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (btnInsert.Text == "Insert")
            {
                if (txtAmount.Text =="")
                {
                    MessageBox.Show("Pls Select Booking Type !!!");
                    return;
                }

                try
                {
                    string tdays = ((dtEnd.Value - dtStart.Value).Days + 1).ToString();
                    txtTotalDays.Text = tdays;

                    SqlCommand cmd = new SqlCommand("Insert into tblBooking VALUES(@Uid,@BookingType,@bookingStartDate,@bookingEndDate,@Totaldays,@Amount)", cnn);
                    cmd.Parameters.AddWithValue("@Uid", clsUserTools.Uid);
                    cmd.Parameters.AddWithValue("@BookingType", cboBookingType.SelectedValue);
                    cmd.Parameters.AddWithValue("@bookingStartDate", dtStart.Value);
                    cmd.Parameters.AddWithValue("@bookingEndDate", dtEnd.Value);
                    cmd.Parameters.AddWithValue("@Totaldays", txtTotalDays.Text);
                    cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();

                    //clearFields();

                    MessageBox.Show("Data Inserted Successfully", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //loadData();

                    pnlContent.Visible = false;
                    //clearFields();

                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.Message);
                    cnn.Close();
                }

            }
            else
            {
                int idedit = Int32.Parse(txtID.Text);

                //SqlCommand cmd = new SqlCommand("Update tblReview SET remarks=@remarks,isPublic=@isPublic,reviewDate=@reviewDate where id=" + idedit, cnn);
                ////cmd.Parameters.AddWithValue("Uid", txtUid.Text);
                //cmd.Parameters.AddWithValue("remarks", txtRemarks.Text);
                //cmd.Parameters.AddWithValue("isPublic", checkBox1.Checked);
                //cmd.Parameters.AddWithValue("reviewDate", dtStart.Value);

                //cnn.Open();
                //cmd.ExecuteNonQuery();
                //cnn.Close();

                //clearFields();

                //MessageBox.Show("Data Updated Successfully", "update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //loadData();

                //pnlContent.Visible = false;
                //clearFields();
            }
        }

        private void cboBookingType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from tblBookingType Where BookingType='" + cboBookingType.SelectedValue + "'", cnn);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            txtAmount.Text = cboBookingType.SelectedValue.ToString();
        }

        private void dtEnd_ValueChanged(object sender, EventArgs e)
        {
            string tdays = ((dtEnd.Value - dtStart.Value).Days +1).ToString();
            txtTotalDays.Text = tdays;
        }
    }
}
