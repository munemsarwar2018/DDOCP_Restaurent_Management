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
    public partial class frmRide : Form
    {
        SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BookingDB.mdf;Integrated Security=True");
        public frmRide()
        {
            InitializeComponent();
        }

        private void frmRide_Load(object sender, EventArgs e)
        {
            pnlContent.Visible = false;
            loadData();
        }

        private void loadData() // viewing data from database
        {
            SqlCommand cmd = new SqlCommand("Select * from tblRide", cnn);
            cnn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            cnn.Close();

            gv.AutoGenerateColumns = false;

            gv.Columns[0].DataPropertyName = "Id";
            gv.Columns[1].DataPropertyName = "name";
            gv.Columns[2].DataPropertyName = "description";
            gv.Columns[3].DataPropertyName = "time";
            gv.Columns[4].DataPropertyName = "charge";

            gv.DataSource = dt;
            gv.AllowUserToAddRows = false;

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
            txtID.Text = "";
            txtName.Text = "";
            txtDes.Text = "";
            txtTime.Text = "";
            txtChar.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clearFields();
            pnlContent.Visible = true;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            clearFields();
            pnlContent.Visible = false;
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            if (btnInsert.Text == "Insert")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Insert into tblRide VALUES(@name,@description,@time,@charge)", cnn);
                    cmd.Parameters.AddWithValue("name", txtName.Text);
                    cmd.Parameters.AddWithValue("description", txtDes.Text);
                    cmd.Parameters.AddWithValue("time", txtTime.Text);
                    cmd.Parameters.AddWithValue("charge", txtChar.Text);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();



                    MessageBox.Show("Data Inserted Successfully", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();

                    pnlContent.Visible = false;
                    clearFields();
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

                SqlCommand cmd = new SqlCommand("Update tblRide SET name=@name,description=@description,time=@time,charge=@charge where id=" + idedit, cnn);
                cmd.Parameters.AddWithValue("name", txtName.Text);
                cmd.Parameters.AddWithValue("description", txtDes.Text);
                cmd.Parameters.AddWithValue("time", txtTime.Text);
                cmd.Parameters.AddWithValue("charge", txtChar.Text);

                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();



                MessageBox.Show("Data Updated Successfully", "update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();

                pnlContent.Visible = false;
                clearFields();
            }
        }

        private void dataGvRide_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (e.ColumnIndex)
                {
                    case 5: // for editing data from data grid view
                        pnlContent.Visible = true;
                        btnInsert.Text = "Update";

                        txtID.Text = gv.Rows[e.RowIndex].Cells[0].Value.ToString();
                        int idn = Int32.Parse(txtID.Text);

                        SqlCommand cmd1 = new SqlCommand("Select * from tblRide where id=" + idn, cnn);
                        cnn.Open(); // sql conncection opening
                        SqlDataReader rd = cmd1.ExecuteReader();
                        if (rd.Read())
                        {
                            txtName.Text = rd.GetString(1);
                            txtDes.Text = rd.GetString(2);
                            txtTime.Text = rd.GetValue(3).ToString();
                            txtChar.Text = rd.GetValue(4).ToString();

                        }
                        cnn.Close(); //sql conncection closing
                        break;

                    case 6: // for deleting data from data grid view
                        txtID.Text = gv.Rows[e.RowIndex].Cells[0].Value.ToString();
                        int iddel = Int32.Parse(txtID.Text);
                        DialogResult dialog = MessageBox.Show("Are you sure you want to delete this record ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                        {
                            SqlCommand cmd2 = new SqlCommand("Delete from tblRide where id=" + iddel, cnn);
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
                cnn.Close();

            }

        }
    }
}
