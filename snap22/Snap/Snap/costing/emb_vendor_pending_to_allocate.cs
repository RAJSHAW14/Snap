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

namespace Snap.costing
{
    public partial class emb_vendor_pending_to_allocate : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public emb_vendor_pending_to_allocate()
        {
            InitializeComponent();
        }

        private void emb_vendor_pending_to_allocate_Load(object sender, EventArgs e)
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
            MySqlDataAdapter da = new MySqlDataAdapter("select * from emb_master where vendor_allocate='NO'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)            
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr["emb_code"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["emb_name"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr["uom"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dr["emb_type"].ToString();
            }
        }

        int id_value = 0;  
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id_value = System.Convert.ToInt32(row.Cells["id"].Value.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(id_value==0)
            {
                MessageBox.Show("Select the cell first");
            }
            else
            {
                emb_vendor_cart cart = new emb_vendor_cart();
                cart.textBox9.Text = id_value.ToString();
                cart.fill_data();
                cart.button2.Enabled = false;
                cart.Show();    
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reload();
        }

        public void reload()
        {
            dataGridView1.Rows.Clear();
            fill_data();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                reload();
            }
            else
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from emb_master where vendor_allocate='NO' and emb_name like '%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["emb_code"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["emb_name"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr["uom"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr["emb_type"].ToString();
                }
            }
        }
    }
}
