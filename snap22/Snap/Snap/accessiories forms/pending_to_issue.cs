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
    public partial class pending_to_issue : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public pending_to_issue()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pending_to_issue_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_gride();
        }

        public void fill_gride()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from acc_pending_request", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["req_number"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr["batchcode"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["department"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr["designer"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dr["for_vendor"].ToString();
                dataGridView1.Rows[i].Cells[5].Value = dr["req_date"].ToString();
                dataGridView1.Rows[i].Cells[5].Value = dr["p_code"].ToString();
            }
        }

        int id_value = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (id_value == 0)
            {
                MessageBox.Show("Select the Cell First");
            }
            else
            {
                item_issue issue = new item_issue();
                issue.textBox1.Text = id_value.ToString();
                issue.fill_data();
                issue.Show();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id_value = System.Convert.ToInt32(row.Cells["req_number"].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            fill_gride();
        }
    }
}
