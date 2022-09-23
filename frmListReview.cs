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
    public partial class frmListReview : Form
    {
        SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BookingDB.mdf;Integrated Security=True");
        public frmListReview()
        {
            InitializeComponent();
        }

        private void frmListReview_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData() // viewing data from database
        {
            SqlCommand cmd;

            if (clsUserTools.userType != "Admin")
            {
                cmd = new SqlCommand("Select * from tblReview Where Uid='" + clsUserTools.Uid + "'", cnn);
            }
            else
            {
                cmd = new SqlCommand("Select * from tblReview", cnn);
            }

            
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            gv.AutoGenerateColumns = false;

            gv.Columns[0].DataPropertyName = "Id";
            gv.Columns[1].DataPropertyName = "Uid";
            gv.Columns[2].DataPropertyName = "Remarks";
            gv.Columns[3].DataPropertyName = "isPublic";
            gv.Columns[4].DataPropertyName = "reviewDate";
            gv.DataSource = dt;
            gv.AllowUserToAddRows = false;

            

        }
    }
}
