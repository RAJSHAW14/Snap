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
    public partial class pending_than_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public pending_than_list()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pending_than_list_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_data();
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_than where than_status='PENDING'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["grn_line_id"].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells["grn_number"].Value = dr["grn_number"].ToString();
                dataGridView1.Rows[i].Cells["item_code"].Value = dr["item_code"].ToString();
                dataGridView1.Rows[i].Cells["qty"].Value = dr["qty"].ToString();
                dataGridView1.Rows[i].Cells["vendor"].Value = dr["vendor"].ToString();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                dataGridView1.Rows.Clear();
                fill_data();
            }
            else
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_than where than_status='PENDING' and grn_number like '%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["grn_line_id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["grn_number"].Value = dr["grn_number"].ToString();
                    dataGridView1.Rows[i].Cells["item_code"].Value = dr["item_code"].ToString();
                    dataGridView1.Rows[i].Cells["qty"].Value = dr["qty"].ToString();
                    dataGridView1.Rows[i].Cells["vendor"].Value = dr["vendor"].ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id_value == "") 
            {
                MessageBox.Show("Please select the cell to Enter Than details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                than_generation_cart cart = new than_generation_cart();
                cart.textBox6.Text = id_value.ToString();
                cart.fill_data();
                cart.Show();
            }
        }
 
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }

        string id_value = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id_value = row.Cells["grn_line_id"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            fill_data();
        }
    }
}
