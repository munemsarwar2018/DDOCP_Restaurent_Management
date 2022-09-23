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
    public partial class frmRestaurant : Form
    {
        SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BookingDB.mdf;Integrated Security=True");
        public frmRestaurant()
        {
            InitializeComponent();
        }

        private void frmRestaurant_Load(object sender, EventArgs e)
        {
            pnlRestaurant.Visible = false;
            loadData();
        }

        private void loadData() // viewing data in gridview from database
        {
            SqlCommand cmd = new SqlCommand("Select * from tblRestaurant", cnn);
            cnn.Open(); // opening sql connection
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            cnn.Close(); // closing sql connection

            gv.AutoGenerateColumns = false;

            gv.Columns[0].DataPropertyName = "Id";
            gv.Columns[1].DataPropertyName = "Table_Size";
            gv.Columns[2].DataPropertyName = "charge";


            gv.DataSource = dt;
            gv.AllowUserToAddRows = false;

            //gv.Columns[3].Visible = false;
            //gv.Columns[4].Visible = false;

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
            txtTblsize.Text = "";
            txtCharge.Text = "";
        }

        private void SearchData()
        {
            try
            {
                string ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =|DataDirectory|Booking.mdf; Integrated Security = True";
                SqlConnection cnn = new SqlConnection(ConnectionString);

                string SearchData = "";
                string Query = "Select * from tblRestaurant where Table_size like '%" + SearchData + "%'"; // To search Table size value from database 
                SqlCommand cmd1 = new SqlCommand(Query, cnn);
                cnn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cnn.Close();

                gv.DataSource = dt;
                cnn.Close();

            }
            catch (Exception ex1)
            {
                MessageBox.Show("Error" + ex1);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            clearFields();
            pnlRestaurant.Visible = true;
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            if (btn_Insert.Text == "Insert")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Insert into tblRestaurant VALUES(@Table_Size,@charge)", cnn);
                    cmd.Parameters.AddWithValue("Table_Size", txtTblsize.Text);
                    cmd.Parameters.AddWithValue("charge", txtCharge.Text);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();

                    clearFields();

                    MessageBox.Show("Data Inserted Successfully", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();

                    pnlRestaurant.Visible = false;

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

                SqlCommand cmd = new SqlCommand("Update tblRestaurant SET Table_size=@Table_Size,charge=@charge where id=" + idedit, cnn);
                cmd.Parameters.AddWithValue("Table_Size", txtTblsize.Text);
                cmd.Parameters.AddWithValue("charge", txtCharge.Text);

                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();


                loadData();
                MessageBox.Show("Data Updated Successfully", "update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearFields();

                pnlRestaurant.Visible = false;
                clearFields();
            }

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            clearFields();
            pnlRestaurant.Visible = false;
        }

        private void dataGVrestaurant_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try // try catch validation for exception handeling
            {
                switch (e.ColumnIndex)
                {
                    case 3: // for editing gridview data
                        pnlRestaurant.Visible = true;
                        btn_Insert.Text = "Update";

                        txt_ID.Text = gv.Rows[e.RowIndex].Cells[0].Value.ToString();
                        int idn = Int32.Parse(txt_ID.Text);

                        SqlCommand cmd1 = new SqlCommand("Select * from tblRestaurant where id=" + idn, cnn);
                        cnn.Open();
                        SqlDataReader rd = cmd1.ExecuteReader();
                        if (rd.Read())
                        {
                            txtTblsize.Text = rd.GetString(1);
                            txtCharge.Text = rd.GetValue(2).ToString();
                        }
                        cnn.Close();


                        break;

                    case 4: // for deleting gridview data
                        txt_ID.Text = gv.Rows[e.RowIndex].Cells[0].Value.ToString();
                        int iddel = Int32.Parse(txt_ID.Text);
                        DialogResult dialog = MessageBox.Show("Are you sure you want to delete this record ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                        {
                            SqlCommand cmd2 = new SqlCommand("Delete from tblRestaurant where id=" + iddel, cnn);
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
