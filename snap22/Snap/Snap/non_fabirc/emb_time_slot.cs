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
    public partial class emb_time_slot : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public emb_time_slot()
        {
            InitializeComponent();
        }

        private void emb_time_slot_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            textBox3.Text= DateTime.Now.ToString("dd-MM-yyyy");
            fill_datagride();
        }

        public void fill_datagride()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from unit_time_slot", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr["unit_name"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["start_1"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr["end_1"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dr["start_2"].ToString();
                dataGridView1.Rows[i].Cells[5].Value = dr["end_2"].ToString();
                dataGridView1.Rows[i].Cells[6].Value = dr["start_3"].ToString();
                dataGridView1.Rows[i].Cells[7].Value = dr["end_3"].ToString();
                dataGridView1.Rows[i].Cells[8].Value = dr["start_4"].ToString();
                dataGridView1.Rows[i].Cells[9].Value = dr["end_4"].ToString();
                dataGridView1.Rows[i].Cells[10].Value = dr["last_update"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(id==0)
            {
                MessageBox.Show("Error!!! Please select and try again");
            }
            else
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE unit_time_slot SET start_1='"+maskedTextBox1.Text+ "', end_1='"+maskedTextBox8.Text+ "', start_2='"+maskedTextBox2.Text+ "',end_2='"+maskedTextBox7.Text+ "',start_3='"+maskedTextBox3.Text+ "',end_3='"+maskedTextBox6.Text+ "',start_4='"+maskedTextBox4.Text+ "',end_4='"+maskedTextBox5.Text+ "',last_update='"+textBox3.Text+"' where id='"+id+"'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("DATA UPDATED");
                dataGridView1.Rows.Clear();
                fill_datagride();
                textBox1.Clear();
                textBox2.Clear();
                maskedTextBox1.Clear();
                maskedTextBox2.Clear();
                maskedTextBox3.Clear();
                maskedTextBox4.Clear();
                maskedTextBox5.Clear();
                maskedTextBox6.Clear();
                maskedTextBox7.Clear();
                maskedTextBox8.Clear();
            }

        }

        int id = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id = System.Convert.ToInt32(row.Cells["id"].Value.ToString());
                textBox1.Text = row.Cells["unit_name"].Value.ToString();
                maskedTextBox1.Text = row.Cells["start1"].Value.ToString();
                maskedTextBox8.Text = row.Cells["end1"].Value.ToString();
                maskedTextBox2.Text = row.Cells["start2"].Value.ToString();
                maskedTextBox7.Text = row.Cells["end2"].Value.ToString();
                maskedTextBox3.Text = row.Cells["start3"].Value.ToString();
                maskedTextBox6.Text = row.Cells["end3"].Value.ToString();
                maskedTextBox4.Text = row.Cells["start4"].Value.ToString();
                maskedTextBox5.Text = row.Cells["end4"].Value.ToString();
                textBox2.Text = row.Cells["last_update"].Value.ToString();
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // emb_time_slot
            // 
            this.ClientSize = new System.Drawing.Size(515, 253);
            this.Name = "emb_time_slot";
            this.ResumeLayout(false);

        }
    }
}
