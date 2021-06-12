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

namespace Snap
{
    public partial class kurta_all_product : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public kurta_all_product()
        {
            InitializeComponent();
        }

        private void kurta_all_product_Load(object sender, EventArgs e)
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
            MySqlDataAdapter da = new MySqlDataAdapter("select * from product_code_routing_date order by id DESC", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr["product_code"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["desinger"].ToString();
            }
        }

        int id_value = 0;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id_value = System.Convert.ToInt32(row.Cells["id"].Value.ToString());
            }
            update_product_status status1 = new update_product_status();
            status1.textBox11.Text = id_value.ToString();
            status1.fill_data();
            status1.Show();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                fill_data();
            }
            else
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from product_code_routing_date where product_code like '%"+textBox1.Text+"%' order by id DESC", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["product_code"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["desinger"].ToString();
                }
            }
        }
    }
}
