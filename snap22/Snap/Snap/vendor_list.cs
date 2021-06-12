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

namespace Snap
{
    public partial class vendor_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        int vendor_id = 0;
        public vendor_list()
        {
            InitializeComponent();
        }

        private void vendor_list_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            data_gride_lode();
        }

        public void datagrid_reload()
        {
            dataGridView1.Rows.Clear();
            data_gride_lode();
        }

        public void data_gride_lode()
        {
            MySqlCommand cmd3 = con.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "select * from vendor WHERE vendor_type='NON-FABRIC'";
            cmd3.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da3 = new MySqlDataAdapter(cmd3);
            da3.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr["id"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr["vendor_name"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr["address"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = dr["city"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = dr["state"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = dr["state_code"].ToString();
                dataGridView1.Rows[n].Cells[6].Value = dr["phone_number"].ToString();
                dataGridView1.Rows[n].Cells[7].Value = dr["pan_number"].ToString();
                dataGridView1.Rows[n].Cells[8].Value = dr["gst_number"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vendor_cart ven = new vendor_cart();
            ven.button2.Enabled = false;
            ven.Show();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            data_gride_lode();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                datagrid_reload();
            }
            else
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from vendor where vendor_name like '%" + textBox1.Text + "%' and vendor_type='NON-FABRIC'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = dr["id"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = dr["vendor_name"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = dr["address"].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = dr["city"].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = dr["state"].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = dr["state_code"].ToString();
                    dataGridView1.Rows[n].Cells[6].Value = dr["phone_number"].ToString();
                    dataGridView1.Rows[n].Cells[7].Value = dr["pan_number"].ToString();
                    dataGridView1.Rows[n].Cells[8].Value = dr["gst_number"].ToString();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                vendor_id = System.Convert.ToInt32(row.Cells["id"].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (vendor_id==0)
            {
                MessageBox.Show("Select Vendor First");
            }
            else
            {
                vendor_cart ven_cart = new vendor_cart();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType= CommandType.Text;
                cmd.CommandText = "select * from vendor where id='"+vendor_id.ToString()+"'";
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    ven_cart.textBox2.Text = dr["vendor_name"].ToString();
                    ven_cart.richTextBox1.Text = dr["address"].ToString();
                    ven_cart.textBox3.Text = dr["city"].ToString();
                    ven_cart.comboBox2.Text = dr["state"].ToString();
                    ven_cart.comboBox1.Text = dr["state_code"].ToString();
                    ven_cart.textBox4.Text = dr["phone_number"].ToString();
                    ven_cart.textBox5.Text = dr["pan_number"].ToString();
                    ven_cart.textBox6.Text = dr["gst_number"].ToString();
                }
                ven_cart.button1.Enabled = false;
                ven_cart.Show();                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (vendor_id==0)
            {
                MessageBox.Show("Select Vendor to Delete");
            }
            else
            {
                DialogResult dilog = MessageBox.Show("Are You Want to delete this Vendor", "Confirm", MessageBoxButtons.YesNo);
                if (dilog == DialogResult.Yes)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete from vendor where id='"+vendor_id.ToString()+"'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Vendor Deleted");
                    datagrid_reload();
                }
                else
                {

                }
            }
        }
    }
}
