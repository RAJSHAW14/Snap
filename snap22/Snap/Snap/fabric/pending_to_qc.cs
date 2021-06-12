using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;


namespace Snap.fabric
{
    public partial class pending_to_qc : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public pending_to_qc()
        {
            InitializeComponent();
        }

        private void pending_to_qc_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_data();
        }

        string id_value = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id_value = row.Cells["id"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(id_value=="")
            {
                MessageBox.Show("Please select the cell to proceed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                qc_checking_cart cart = new qc_checking_cart();
                cart.fill_gride();
                cart.textBox7.Text = id_value.ToString();
                cart.fill_data();
                cart.Show();
            }
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_than_details_view where status='SENT TO QC'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells["fabric_code"].Value = dr["fabric_code"].ToString();
                dataGridView1.Rows[i].Cells["than_number"].Value = dr["than_number"].ToString();
                dataGridView1.Rows[i].Cells["than_qty"].Value = dr["than_qty"].ToString();
                dataGridView1.Rows[i].Cells["vendor"].Value = dr["vendor"].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            fill_data();
        }
    }
}
