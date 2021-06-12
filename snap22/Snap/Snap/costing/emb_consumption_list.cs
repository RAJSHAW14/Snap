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
    public partial class emb_consumption_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public emb_consumption_list()
        {
            InitializeComponent();
        }

        private void emb_consumption_list_Load(object sender, EventArgs e)
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
            MySqlDataAdapter da = new MySqlDataAdapter("select * from emb_consumption", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["emb_id"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr["emb_code"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["emb_name"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr["uom"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dr["emb_type"].ToString();
                //dataGridView1.Rows[i].Cells[5].Value = dr["time"].ToString();
                dataGridView1.Rows[i].Cells[6].Value = dr["mat_cost"].ToString();
                dataGridView1.Rows[i].Cells[7].Value = dr["remarks"].ToString();
            }
        }

        int id_value = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id_value = System.Convert.ToInt32(row.Cells["emb_id"].Value.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from emb_consumption WHERE emb_name like '%"+textBox1.Text+"%'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["emb_id"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr["emb_code"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["emb_name"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr["uom"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dr["emb_type"].ToString();
                //dataGridView1.Rows[i].Cells[5].Value = dr["time"].ToString();
                dataGridView1.Rows[i].Cells[6].Value = dr["mat_cost"].ToString();
                dataGridView1.Rows[i].Cells[7].Value = dr["remarks"].ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            textBox1.Clear();
            fill_data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(id_value==0)
            {
                MessageBox.Show("Select the cell to edit");
            }
            else
            {
                emb_mat_consumption consumption=new emb_mat_consumption();
                consumption.textBox9.Text = id_value.ToString();
                consumption.fill_data();
                consumption.button1.Visible = false;
                consumption.Show();
            }
        }
    }
}
