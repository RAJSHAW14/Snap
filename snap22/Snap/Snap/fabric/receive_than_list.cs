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

namespace Snap.fabric
{
    public partial class receive_than_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public receive_than_list()
        {
            InitializeComponent();
        }

        private void receive_than_list_Load(object sender, EventArgs e)
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
            MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_than_details_view where status='RECEIVE'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["than_id"].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells["grn_number"].Value = dr["grn_number"].ToString();
                dataGridView1.Rows[i].Cells["than_number"].Value = dr["than_number"].ToString();
                dataGridView1.Rows[i].Cells["item_code"].Value = dr["fabric_code"].ToString();
                dataGridView1.Rows[i].Cells["qty"].Value = dr["than_qty"].ToString();
                dataGridView1.Rows[i].Cells["vendor"].Value = dr["vendor"].ToString();
                dataGridView1.Rows[i].Cells["grn_line_number"].Value = dr["grn_line_number"].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            fill_data();
        }

        int id_value = 0, grn_line_numbers = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id_value = System.Convert.ToInt32(row.Cells["than_id"].Value.ToString());
                grn_line_numbers = System.Convert.ToInt32(row.Cells["grn_line_number"].Value.ToString());

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
                MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_than_details_view where status='RECEIVE' AND than_number='"+textBox1.Text+"'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["than_id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["grn_number"].Value = dr["grn_number"].ToString();
                    dataGridView1.Rows[i].Cells["than_number"].Value = dr["than_number"].ToString();
                    dataGridView1.Rows[i].Cells["item_code"].Value = dr["fabric_code"].ToString();
                    dataGridView1.Rows[i].Cells["qty"].Value = dr["than_qty"].ToString();
                    dataGridView1.Rows[i].Cells["vendor"].Value = dr["vendor"].ToString();
                    dataGridView1.Rows[i].Cells["grn_line_number"].Value = dr["grn_line_number"].ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(id_value==0)
            {
                MessageBox.Show("Please select the Than Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update fabric_than_details set status='SENT TO QC' WHERE id='"+id_value.ToString()+"'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Fabric Sent QC", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Rows.Clear();
                fill_data();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (grn_line_numbers == 0)
            {
                MessageBox.Show("Please select the Than Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from fabric_than_details where grn_line_number='" + grn_line_numbers.ToString() + "'";
                cmd.ExecuteNonQuery();

                MySqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update fabric_grn_line set than_status='PENDING' where id='"+grn_line_numbers.ToString()+"'";
                cmd1.ExecuteNonQuery();

                MessageBox.Show("All the Than deleted Against This GRN fabric code", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Rows.Clear();
                fill_data();
            }
        }
    }
}
