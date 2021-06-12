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

namespace Snap.IT
{
    public partial class stock_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public stock_list()
        {
            InitializeComponent();
        }

        private void stock_list_Load(object sender, EventArgs e)
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
            MySqlDataAdapter da = new MySqlDataAdapter("select * from it_item_catagory", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells["category"].Value = dr["Catagory"].ToString();
                dataGridView1.Rows[i].Cells["it_stock"].Value = dr["it_stock"].ToString();
                dataGridView1.Rows[i].Cells["user_stock"].Value = dr["user_stock"].ToString();
                dataGridView1.Rows[i].Cells["total_stock"].Value = dr["total_stock"].ToString();
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
                MySqlDataAdapter da = new MySqlDataAdapter("select * from it_item_catagoryn where Catagory like '%"+textBox1.Text+"%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["category"].Value = dr["Catagory"].ToString();
                    dataGridView1.Rows[i].Cells["it_stock"].Value = dr["it_stock"].ToString();
                    dataGridView1.Rows[i].Cells["user_stock"].Value = dr["user_stock"].ToString();
                    dataGridView1.Rows[i].Cells["total_stock"].Value = dr["total_stock"].ToString();
                }
            }
        }
    }
}
