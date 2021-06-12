using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Snap.fabric
{
    public partial class vendor_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public vendor_list()
        {
            InitializeComponent();
        }

        private void vendor_list_Load(object sender, EventArgs e)
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
            MySqlDataAdapter da = new MySqlDataAdapter("select * from vendor where vendor_type='FABRIC'",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells["vendor_name"].Value = dr["vendor_name"].ToString();
                dataGridView1.Rows[i].Cells["address_1"].Value = dr["address"].ToString();
                dataGridView1.Rows[i].Cells["address_2"].Value = dr["address_1"].ToString();
                dataGridView1.Rows[i].Cells["state"].Value = dr["state"].ToString();
                dataGridView1.Rows[i].Cells["pincode"].Value = dr["pincode"].ToString();
                dataGridView1.Rows[i].Cells["pan_number"].Value = dr["pan_number"].ToString();
                dataGridView1.Rows[i].Cells["gst_number"].Value = dr["gst_number"].ToString();
                dataGridView1.Rows[i].Cells["contact"].Value = dr["phone_number"].ToString();                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vendor_cart cart = new vendor_cart();
            cart.button2.Enabled = false;
            cart.Show();
        }

        int vendor_id = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                vendor_id = System.Convert.ToInt32(row.Cells["id"].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(vendor_id==0)
            {
                MessageBox.Show("Please select the Vendor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                vendor_cart cart = new vendor_cart();
                cart.button1.Enabled = false;
                cart.textBox1.ReadOnly = true;
                cart.textBox9.Text = vendor_id.ToString();
                cart.fill_data();
                cart.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            fill_data();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Enter the vendor name");
            }
            else
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from vendor where vendor_type='FABRIC' AND vendor_name LIKE '%"+textBox1.Text+"%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["vendor_name"].Value = dr["vendor_name"].ToString();
                    dataGridView1.Rows[i].Cells["address_1"].Value = dr["address"].ToString();
                    dataGridView1.Rows[i].Cells["address_2"].Value = dr["address_1"].ToString();
                    dataGridView1.Rows[i].Cells["state"].Value = dr["state"].ToString();
                    dataGridView1.Rows[i].Cells["pincode"].Value = dr["pincode"].ToString();
                    dataGridView1.Rows[i].Cells["pan_number"].Value = dr["pan_number"].ToString();
                    dataGridView1.Rows[i].Cells["gst_number"].Value = dr["gst_number"].ToString();
                    dataGridView1.Rows[i].Cells["contact"].Value = dr["phone_number"].ToString();
                }
            }
        }
    }
}
