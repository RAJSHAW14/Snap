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
    public partial class add_karigar : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public add_karigar()
        {
            InitializeComponent();
        }

        private void add_karigar_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_combo();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void fill_combo()
        {
            comboBox1.Items.Clear();
            MySqlDataAdapter da = new MySqlDataAdapter("select unit_name from emb_unit where type='IN-HOUSE' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["unit_name"].ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into karigar_master (gate_number,name,unit) Values ('"+textBox1.Text+"','"+textBox2.Text+"','"+comboBox1.Text+"')";
            cmd.ExecuteNonQuery();
        }

        public void fill_datagrid()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from karigar_master",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr["gate_number"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["name"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr["unit"].ToString();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text=="")
            {
                MessageBox.Show("Select Unit");
                dataGridView1.Rows.Clear();
                fill_datagrid();
            }
            else
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from karigar_master where unit='"+comboBox1.Text+"'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["gate_number"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["name"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr["unit"].ToString();

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox4.Text = row.Cells["id"].Value.ToString();
                textBox1.Text = row.Cells["unit_name"].Value.ToString();
                
            }
        }
    }
}
