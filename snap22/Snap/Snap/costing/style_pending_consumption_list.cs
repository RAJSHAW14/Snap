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
    public partial class style_pending_consumption_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public style_pending_consumption_list()
        {
            InitializeComponent();
        }

        private void style_pending_consumption_list_Load(object sender, EventArgs e)
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
            MySqlDataAdapter da = new MySqlDataAdapter("select * from style_master where consumption_status='PENDING' AND style_type='APP'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["id"].Value=dr["id"].ToString();
                dataGridView1.Rows[i].Cells["style_cost"].Value = dr["style_code"].ToString();
                dataGridView1.Rows[i].Cells["style_color"].Value = dr["style_colour"].ToString();
                dataGridView1.Rows[i].Cells["category"].Value = dr["catagory"].ToString();
                dataGridView1.Rows[i].Cells["description"].Value = dr["description"].ToString();                
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

        private void button2_Click(object sender, EventArgs e)
        {
            garment_costing_cart cart = new garment_costing_cart();
            cart.textBox27.Text = id_value.ToString();
            cart.fill_first_data();
            cart.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            fill_data();
        }
    }
}
