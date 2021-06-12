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
    public partial class d_qc_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public d_qc_list()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void d_qc_list_Load(object sender, EventArgs e)
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
            MySqlDataAdapter da = new MySqlDataAdapter("select * from acc_qc_transaction_list where d_status='OPEN' group by id_number ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
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

        public void reload()
        {
            dataGridView1.Rows.Clear();
            fill_data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            qc_check check = new qc_check();
            check.button3.Enabled = false;
            check.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(id_value=="")
            {
                MessageBox.Show("Select the Row first","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                qc_check check = new qc_check();
                check.button2.Enabled = false;
                check.textBox1.ReadOnly = true;
                check.textBox8.Text = id_value.ToString();
                check.fill_data();                
                check.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(id_value=="")
            {
                MessageBox.Show("Select the Row first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from acc_qc_transaction_list where id_number='"+id_value.ToString()+"'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Deleted Sucessfully");
                reload();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(id_value=="")
            {
                MessageBox.Show("Select the Row first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Are You Sure Want to send this to final QC", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update acc_qc_transaction_list set d_status = 'SENT TO QC' WHERE id_number='" + id_value.ToString() + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Sent for Final QC");
                    reload();
                }
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                fill_data();
            }
            else
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from acc_qc_transaction_list where d_status='OPEN' and product_code like '%" + textBox1.Text + "%' group by id_number", con);
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
                }
            }
        }
    }
}
