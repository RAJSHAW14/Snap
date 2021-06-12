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
    public partial class pending_to_issue : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public pending_to_issue()
        {
            InitializeComponent();
        }

        private void pending_to_issue_Load(object sender, EventArgs e)
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
            MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_requisition where pending_qty>0", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells["req_number"].Value = dr["req_number"].ToString();
                dataGridView1.Rows[i].Cells["batchcode"].Value = dr["batch_code"].ToString();
                dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                dataGridView1.Rows[i].Cells["date"].Value = System.Convert.ToDateTime(dr["date"].ToString());
                dataGridView1.Rows[i].Cells["fabric_code"].Value = dr["fabric_code"].ToString();
                dataGridView1.Rows[i].Cells["qty"].Value = dr["pending_qty"].ToString();
                dataGridView1.Rows[i].Cells["uom"].Value = dr["uom"].ToString();
                dataGridView1.Rows[i].Cells["remarks"].Value = dr["remarks"].ToString();                
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Please enter the REQ Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_requisition where pending_qty>0 AND req_number like '%"+textBox1.Text+"%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["req_number"].Value = dr["req_number"].ToString();
                    dataGridView1.Rows[i].Cells["batchcode"].Value = dr["batch_code"].ToString();
                    dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                    dataGridView1.Rows[i].Cells["date"].Value = System.Convert.ToDateTime(dr["date"].ToString());
                    dataGridView1.Rows[i].Cells["fabric_code"].Value = dr["fabric_code"].ToString();
                    dataGridView1.Rows[i].Cells["qty"].Value = dr["pending_qty"].ToString();
                    dataGridView1.Rows[i].Cells["uom"].Value = dr["uom"].ToString();
                    dataGridView1.Rows[i].Cells["remarks"].Value = dr["remarks"].ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(id_value=="")
            {
                MessageBox.Show("Please select the cell to proceed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int i=0;
                MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_issue where req_number='" + req_number.ToString() + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                i = System.Convert.ToInt32(dt.Rows.Count.ToString());
                if(i==0)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete from fabric_requisition where req_number='"+id_value.ToString()+"'";
                    cmd.ExecuteNonQuery();

                    MySqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "delete from fabric_requisition_product where request_id='"+id_value.ToString()+"'";
                    cmd1.ExecuteNonQuery();

                    MessageBox.Show("Request Number " + id_value.ToString() + "Deleted Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.Clear();
                    fill_data();
                }
                else
                {
                    MessageBox.Show("Already Issue Against this Req Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(id_value=="")
            {
                MessageBox.Show("Please select the cell to proceed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                issue iss = new issue();
                iss.textBox1.Text = id_value.ToString();
                iss.fill_req_data();
                iss.Show();
            }
        }

        string id_value = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id_value = row.Cells["req_number"].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            fill_data();
        }
    }
}
