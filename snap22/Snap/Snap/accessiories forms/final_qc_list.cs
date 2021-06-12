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

namespace Snap.accessiories_forms
{
    public partial class final_qc_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public final_qc_list()
        {
            InitializeComponent();
        }

        private void final_qc_list_Load(object sender, EventArgs e)
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
            MySqlDataAdapter da = new MySqlDataAdapter("select * from acc_qc_transaction_list where d_status='SENT TO QC' group by id_number", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["id_number"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr["product_code"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["date"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr["style_code"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dr["product"].ToString();
                dataGridView1.Rows[i].Cells[5].Value = dr["size"].ToString();
                dataGridView1.Rows[i].Cells[6].Value = dr["type"].ToString();
                dataGridView1.Rows[i].Cells[7].Value = dr["client_store"].ToString();
                dataGridView1.Rows[i].Cells[8].Value = dr["client"].ToString();
                dataGridView1.Rows[i].Cells[9].Value = dr["color"].ToString();

            }
        }

        public void reload()
        {
            dataGridView1.Rows.Clear();
            fill_data();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(id_value=="")
            {
                MessageBox.Show("Select the cell first to proceed");
            }
            else
            {
                final_qc qc = new final_qc();
                qc.textBox8.Text = id_value.ToString();
                qc.fill_data();
                qc.Show();
            }
        }

        string id_value = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id_value = row.Cells["id_number"].Value.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                fill_data();
            }
            else
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from acc_qc_transaction_list where d_status='SENT TO QC' AND product_code LIKE '%" + textBox1.Text + "%' group by id_number", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["id_number"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["product_code"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["date"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr["style_code"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr["product"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr["size"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dr["type"].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = dr["client_store"].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = dr["client"].ToString();
                    dataGridView1.Rows[i].Cells[9].Value = dr["color"].ToString();
                }
            }            
        }
    }
}
