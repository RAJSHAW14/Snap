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
    public partial class style_costing_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public style_costing_list()
        {
            InitializeComponent();
        }

        private void style_costing_list_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            load_datagride();
        }

        public void load_datagride()
        {
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from style_master WHERE consumption_status='DONE' AND style_type='APP'";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells["id"].Value = dr["id"].ToString();
                dataGridView1.Rows[n].Cells["style_code"].Value = dr["style_code"].ToString();
                dataGridView1.Rows[n].Cells["style_colour"].Value = dr["style_colour"].ToString();
                dataGridView1.Rows[n].Cells["description"].Value = dr["description"].ToString();
                dataGridView1.Rows[n].Cells["Catagory"].Value = dr["catagory"].ToString();
                dataGridView1.Rows[n].Cells["mrp"].Value = dr["mrp"].ToString();
                dataGridView1.Rows[n].Cells["fabric_cost"].Value = dr["fabric_cost"].ToString();
                dataGridView1.Rows[n].Cells["dye_cost"].Value = dr["dye_cost"].ToString();
                dataGridView1.Rows[n].Cells["print_cost"].Value = dr["print_cost"].ToString();
                dataGridView1.Rows[n].Cells["emb_cost"].Value = dr["emb_cost"].ToString();
                dataGridView1.Rows[n].Cells["mat_cost"].Value = dr["mat_cost"].ToString();
                dataGridView1.Rows[n].Cells["stitiching_cost"].Value = dr["stiching_cost"].ToString();
                dataGridView1.Rows[n].Cells["total_cost"].Value = dr["total_cost"].ToString();                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(id_value==0)
            {
                MessageBox.Show("Please select the Cell to Update");
            }
            else
            {
                garment_costing_cart cart = new garment_costing_cart();
                cart.button4.Visible = false;
                cart.textBox27.Text = id_value.ToString();
                cart.fill_first_data();
                cart.Show();
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

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            load_datagride();
        }
    }
}
