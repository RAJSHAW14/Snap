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

namespace Snap.CMC
{
    public partial class design_master_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public design_master_list()
        {
            InitializeComponent();
        }

        private void design_master_list_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_data();
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_design", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells["design_code"].Value = dr["design_code"].ToString();
                dataGridView1.Rows[i].Cells["design_type"].Value = dr["design_type"].ToString();
                dataGridView1.Rows[i].Cells["machine_type"].Value = dr["machine_type"].ToString();
                dataGridView1.Rows[i].Cells["design_description"].Value = dr["design_description"].ToString();
                dataGridView1.Rows[i].Cells["stitiches"].Value = dr["stitiches"].ToString();
                dataGridView1.Rows[i].Cells["colors"].Value = dr["color"].ToString();
                dataGridView1.Rows[i].Cells["appx_mc_time"].Value = dr["appx_mc_time"].ToString();
                dataGridView1.Rows[i].Cells["uom"].Value = dr["uom"].ToString();
                dataGridView1.Rows[i].Cells["emb_cost"].Value = dr["emb_code"].ToString();
                dataGridView1.Rows[i].Cells["digital"].Value = dr["digital"].ToString();
                dataGridView1.Rows[i].Cells["remarks"].Value = dr["remarks"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            design_master_cart cart = new design_master_cart();
            cart.button2.Visible = false;
            cart.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            design_master_cart cart = new design_master_cart();
            cart.button1.Visible = false;
            cart.textBox9.Text = id_value.ToString();
            cart.fill_data();
            cart.Show();
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

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            fill_data();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "DESIGN CODE")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_design where design_code like '%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["design_code"].Value = dr["design_code"].ToString();
                    dataGridView1.Rows[i].Cells["design_type"].Value = dr["design_type"].ToString();
                    dataGridView1.Rows[i].Cells["machine_type"].Value = dr["machine_type"].ToString();
                    dataGridView1.Rows[i].Cells["design_description"].Value = dr["design_description"].ToString();
                    dataGridView1.Rows[i].Cells["stitiches"].Value = dr["stitiches"].ToString();
                    dataGridView1.Rows[i].Cells["colors"].Value = dr["color"].ToString();
                    dataGridView1.Rows[i].Cells["appx_mc_time"].Value = dr["appx_mc_time"].ToString();
                    dataGridView1.Rows[i].Cells["uom"].Value = dr["uom"].ToString();
                    dataGridView1.Rows[i].Cells["emb_cost"].Value = dr["emb_code"].ToString();
                    dataGridView1.Rows[i].Cells["digital"].Value = dr["digital"].ToString();
                    dataGridView1.Rows[i].Cells["remarks"].Value = dr["remarks"].ToString();
                }
            }
            else if (comboBox1.Text == "DESIGN TYPE")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_design where design_type like '%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["design_code"].Value = dr["design_code"].ToString();
                    dataGridView1.Rows[i].Cells["design_type"].Value = dr["design_type"].ToString();
                    dataGridView1.Rows[i].Cells["machine_type"].Value = dr["machine_type"].ToString();
                    dataGridView1.Rows[i].Cells["design_description"].Value = dr["design_description"].ToString();
                    dataGridView1.Rows[i].Cells["stitiches"].Value = dr["stitiches"].ToString();
                    dataGridView1.Rows[i].Cells["colors"].Value = dr["color"].ToString();
                    dataGridView1.Rows[i].Cells["appx_mc_time"].Value = dr["appx_mc_time"].ToString();
                    dataGridView1.Rows[i].Cells["uom"].Value = dr["uom"].ToString();
                    dataGridView1.Rows[i].Cells["emb_cost"].Value = dr["emb_code"].ToString();
                    dataGridView1.Rows[i].Cells["digital"].Value = dr["digital"].ToString();
                    dataGridView1.Rows[i].Cells["remarks"].Value = dr["remarks"].ToString();
                }
            }
            else if (comboBox1.Text == "MACHINE TYPE")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_design where machine_type like '%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["design_code"].Value = dr["design_code"].ToString();
                    dataGridView1.Rows[i].Cells["design_type"].Value = dr["design_type"].ToString();
                    dataGridView1.Rows[i].Cells["machine_type"].Value = dr["machine_type"].ToString();
                    dataGridView1.Rows[i].Cells["design_description"].Value = dr["design_description"].ToString();
                    dataGridView1.Rows[i].Cells["stitiches"].Value = dr["stitiches"].ToString();
                    dataGridView1.Rows[i].Cells["colors"].Value = dr["color"].ToString();
                    dataGridView1.Rows[i].Cells["appx_mc_time"].Value = dr["appx_mc_time"].ToString();
                    dataGridView1.Rows[i].Cells["uom"].Value = dr["uom"].ToString();
                    dataGridView1.Rows[i].Cells["emb_cost"].Value = dr["emb_code"].ToString();
                    dataGridView1.Rows[i].Cells["digital"].Value = dr["digital"].ToString();
                    dataGridView1.Rows[i].Cells["remarks"].Value = dr["remarks"].ToString();
                }
            }
            else if (comboBox1.Text == "DESIGN DESCRIPTION")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_design where design_description like '%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["design_code"].Value = dr["design_code"].ToString();
                    dataGridView1.Rows[i].Cells["design_type"].Value = dr["design_type"].ToString();
                    dataGridView1.Rows[i].Cells["machine_type"].Value = dr["machine_type"].ToString();
                    dataGridView1.Rows[i].Cells["design_description"].Value = dr["design_description"].ToString();
                    dataGridView1.Rows[i].Cells["stitiches"].Value = dr["stitiches"].ToString();
                    dataGridView1.Rows[i].Cells["colors"].Value = dr["color"].ToString();
                    dataGridView1.Rows[i].Cells["appx_mc_time"].Value = dr["appx_mc_time"].ToString();
                    dataGridView1.Rows[i].Cells["uom"].Value = dr["uom"].ToString();
                    dataGridView1.Rows[i].Cells["emb_cost"].Value = dr["emb_code"].ToString();
                    dataGridView1.Rows[i].Cells["digital"].Value = dr["digital"].ToString();
                    dataGridView1.Rows[i].Cells["remarks"].Value = dr["remarks"].ToString();
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
                fill_data();
            }
        }
    }
}
