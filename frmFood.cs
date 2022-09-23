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
    public partial class frmFood : Form
    {

        SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BookingDB.mdf;Integrated Security=True");
        public frmFood()
        {
            InitializeComponent();
        }

        private void frmFood_Load(object sender, EventArgs e)
        {
            pnlContent.Visible = false;
            loadData();

            
        }

        private void loadData() // viewing data in gridview from database
        {
            SqlCommand cmd = new SqlCommand("Select * from tblFood", cnn);
            //cnn.Open(); // opening sql connection
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            //cnn.Close(); // closing sql connection

            gv.AutoGenerateColumns = false;

            gv.Columns[0].DataPropertyName = "Id";
            gv.Columns[1].DataPropertyName = "name";
            gv.Columns[2].DataPropertyName = "description";
            gv.Columns[3].DataPropertyName = "price";

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

        private void gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try // try catch validation for exception handeling
            {
                switch (e.ColumnIndex)
                {
                    case 4: // for editing gridview data
                        pnlContent.Visible = true;
                        btnInsert.Text = "Update";

                        txtID.Text = gv.Rows[e.RowIndex].Cells[0].Value.ToString();
                        int idn = Int32.Parse(txtID.Text);

                        SqlCommand cmd1 = new SqlCommand("Select * from tblFood where id=" + idn, cnn);
                        cnn.Open();
                        SqlDataReader rd = cmd1.ExecuteReader();
                        if (rd.Read())
                        {
                            txtFoodname.Text = rd.GetString(1);
                            txtDescription.Text = rd.GetString(2);
                            txtPrice.Text = rd.GetValue(3).ToString();

                        }
                        cnn.Close();


                        break;

                    case 5: // for deleting gridview data
                        txtID.Text = gv.Rows[e.RowIndex].Cells[0].Value.ToString();
                        int iddel = Int32.Parse(txtID.Text);
                        DialogResult dialog = MessageBox.Show("Are you sure you want to delete this record ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                        {
                            SqlCommand cmd2 = new SqlCommand("Delete from tblFood where id=" + iddel, cnn);
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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (btnInsert.Text == "Insert")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Insert into tblFood VALUES(@name,@desc,@price)", cnn);
                    cmd.Parameters.AddWithValue("name", txtFoodname.Text);
                    cmd.Parameters.AddWithValue("desc", txtDescription.Text);
                    cmd.Parameters.AddWithValue("price", txtPrice.Text);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();

                    loadData();
                    clearFields();

                    MessageBox.Show("Data Inserted Successfully", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                SqlCommand cmd = new SqlCommand("Update tblFood SET name=@name,description=@desc,price=@price where id=" + idedit, cnn);
                cmd.Parameters.AddWithValue("name", txtFoodname.Text);
                cmd.Parameters.AddWithValue("desc", txtDescription.Text);
                cmd.Parameters.AddWithValue("price", txtPrice.Text);

                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();

                clearFields();
                loadData();
                MessageBox.Show("Data Updated Successfully", "update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            pnlContent.Visible = false;
        }

        private void clearFields() // clearing data from data entry panel
        {
            txtID.Text = "";
            txtFoodname.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            clearFields();
            pnlContent.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            clearFields();
            pnlContent.Visible = false;
        }
    }
}
