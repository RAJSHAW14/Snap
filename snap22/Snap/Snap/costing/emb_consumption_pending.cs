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
    public partial class emb_consumption_pending : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public emb_consumption_pending()
        {
            InitializeComponent();
        }

        private void emb_consumption_pending_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_data();
            auto_complete();
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from emb_master where mat_rate='0.00'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value=dr["id"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr["emb_code"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["emb_name"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr["uom"].ToString();
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

        private void textBox1_Leave(object sender, EventArgs e)
        {
                       
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(id_value==0)
            {
                MessageBox.Show("Select cell to proceed");
            }
            else
            {
                emb_mat_consumption consumption = new emb_mat_consumption();
                consumption.textBox9.Text = id_value.ToString();
                consumption.fill_emb_master();
                consumption.button2.Visible = false;
                consumption.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            fill_data();
        }

        public void auto_complete()
        {
            MySqlCommand cmd = new MySqlCommand("select emb_name from emb_master WHERE mat_rate='0.00'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection autocomplete = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                autocomplete.Add(dr.GetString(0));

            }
            textBox1.AutoCompleteCustomSource = autocomplete;
            dr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                dataGridView1.Rows.Clear();
                fill_data();
            }
            else
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from emb_master where mat_rate='0.00' and emb_name like '%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["emb_code"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["emb_name"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr["uom"].ToString();
                }
            } 
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
