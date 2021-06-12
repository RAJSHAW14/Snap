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
    public partial class style_master_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public style_master_list()
        {
            InitializeComponent();
        }

        private void style_master_list_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_gride();
        }

        public void fill_gride()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from style_master WHERE style_type='APP'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells["style_cost"].Value = dr["style_code"].ToString();
                dataGridView1.Rows[i].Cells["style_color"].Value = dr["style_colour"].ToString();
                dataGridView1.Rows[i].Cells["category"].Value = dr["catagory"].ToString();
                dataGridView1.Rows[i].Cells["description"].Value = dr["description"].ToString();
                dataGridView1.Rows[i].Cells["mrp"].Value = dr["mrp"].ToString();
                dataGridView1.Rows[i].Cells["final_cost"].Value = dr["total_cost"].ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            fill_gride();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            style_master_cart cart = new style_master_cart();
            cart.Show();
        }
    }
}
