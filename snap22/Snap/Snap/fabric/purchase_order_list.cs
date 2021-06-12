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
    public partial class purchase_order_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public purchase_order_list()
        {
            InitializeComponent();
        }

        private void purchase_order_list_Load(object sender, EventArgs e)
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
            MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_po",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["id"].Value=dr["id"].ToString();
                dataGridView1.Rows[i].Cells["po_number"].Value = dr["po_number"].ToString();
                dataGridView1.Rows[i].Cells["po_date"].Value = System.Convert.ToDateTime(dr["po_date"].ToString());
                dataGridView1.Rows[i].Cells["fabric_name"].Value = dr["fabric_name"].ToString();
                dataGridView1.Rows[i].Cells["fabric_code"].Value = dr["fabric_code"].ToString();
                dataGridView1.Rows[i].Cells["color"].Value = dr["color"].ToString();
                dataGridView1.Rows[i].Cells["vendor"].Value = dr["vendor"].ToString();
                dataGridView1.Rows[i].Cells["rate"].Value = dr["rate"].ToString();
                dataGridView1.Rows[i].Cells["order_qty"].Value = dr["order_qty"].ToString();
                dataGridView1.Rows[i].Cells["dod"].Value = dr["dod"].ToString();
                dataGridView1.Rows[i].Cells["amount"].Value = dr["amount"].ToString();
                dataGridView1.Rows[i].Cells["lap_dip"].Value = dr["lap_dip"].ToString();
                dataGridView1.Rows[i].Cells["remarks"].Value = dr["remarks"].ToString();
                dataGridView1.Rows[i].Cells["pending_qty"].Value = dr["pending_qty"].ToString();                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            po_cart cart = new po_cart();
            cart.button1.Enabled = false;
            cart.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(po_id=="")
            {
                MessageBox.Show("Please select the PO to Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                po_cart cart = new po_cart();
                cart.textBox3.Text = po_id.ToString();
                cart.button2.Enabled = false;
                cart.fill_data();
                cart.Show();
            }
        }

        string po_id = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                po_id = row.Cells["po_number"].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            fill_data();
        }
    }
}
