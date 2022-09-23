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
    public partial class frmResort : Form
    {
        SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BookingDB.mdf;Integrated Security=True");
        public frmResort()
        {
            InitializeComponent();
        }

        private void frmResort_Load(object sender, EventArgs e)
        {
            pnlContent.Visible = false;
            loadData();
        }

        private void loadData() // viewing data in gridview from database
        {
            SqlCommand cmd = new SqlCommand("Select * from tblResort", cnn);
            cnn.Open();     // opening sql connection
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            cnn.Close();      // closing sql connection

            dataGVresort.AutoGenerateColumns = false;

            dataGVresort.Columns[0].DataPropertyName = "Id";
            dataGVresort.Columns[1].DataPropertyName = "type";
            dataGVresort.Columns[2].DataPropertyName = "description";
            dataGVresort.Columns[3].DataPropertyName = "charge";

            dataGVresort.DataSource = dt;
            dataGVresort.AllowUserToAddRows = false;

            //Set Buttons Show/Hide
            if (clsUserTools.userType != "Admin")
            {
                Edit.Visible = false;
                Delete.Visible = false;
                btnAdd.Visible = false;
            }
            else
            {
                Edit.Visible = true;
                Delete.Visible = true;
                btnAdd.Visible = true;
            }

        }

        private void clearFields() // clearing data from data entry panel
        {
            txt_ID.Text = "";
            txtType.Text = "";
            txtDescription.Text = "";
            txtCharge.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clearFields();
            pnlContent.Visible = false;

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            clearFields();
            pnlContent.Visible = false;
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            if (btn_Insert.Text == "Insert")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Insert into tblResort VALUES(@type,@description,@charge)", cnn);
                    cmd.Parameters.AddWithValue("type", txtType.Text);
                    cmd.Parameters.AddWithValue("description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("charge", txtCharge.Text);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();

                    clearFields();

                    MessageBox.Show("Data Inserted Successfully", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();

                    pnlContent.Visible = false;

                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.Message);
                    cnn.Close();
                }
            }

            else
            {

                int idedit = Int32.Parse(txt_ID.Text);

                SqlCommand cmd = new SqlCommand("Update tblResort SET type=@type,description=@description,charge=@charge where id=" + idedit, cnn);
                cmd.Parameters.AddWithValue("type", txtType.Text);
                cmd.Parameters.AddWithValue("description", txtDescription.Text);
                cmd.Parameters.AddWithValue("charge", txtCharge.Text);

                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();

                clearFields();

                MessageBox.Show("Data Updated Successfully", "update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();

                pnlContent.Visible = false;

            }
        }

        private void dataGVresort_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try  // try catch validation for exception handeling
            {
                switch (e.ColumnIndex)
                {
                    case 4: // for editing gridview data
                        pnlContent.Visible = true;
                        btn_Insert.Text = "Update";

                        txt_ID.Text = dataGVresort.Rows[e.RowIndex].Cells[0].Value.ToString();
                        int idn = Int32.Parse(txt_ID.Text);

                        SqlCommand cmd1 = new SqlCommand("Select * from tblResort where id=" + idn, cnn);
                        cnn.Open();
                        SqlDataReader rd = cmd1.ExecuteReader();
                        if (rd.Read())
                        {
                            txtType.Text = rd.GetString(1);
                            txtDescription.Text = rd.GetString(2);
                            txtCharge.Text = rd.GetValue(3).ToString();

                        }
                        cnn.Close();


                        break;

                    case 5: // for deleting gridview data
                        txt_ID.Text = dataGVresort.Rows[e.RowIndex].Cells[0].Value.ToString();
                        int iddel = Int32.Parse(txt_ID.Text);
                        DialogResult dialog = MessageBox.Show("Are you sure you want to delete this record ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                        {
                            SqlCommand cmd2 = new SqlCommand("Delete from tblResort where id=" + iddel, cnn);
                            cnn.Open();
                            cmd2.ExecuteNonQuery();
                            cnn.Close();

                            loadData();

                            MessageBox.Show("Data deleted succecfully");
                        }



                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex1)
            {

                MessageBox.Show("Error" + ex1); // message for error handeling
            }
        }
    }
}
