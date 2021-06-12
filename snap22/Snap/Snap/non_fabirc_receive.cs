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
    public partial class non_fabirc_receive : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public non_fabirc_receive()
        {
            InitializeComponent();
        }

        private void non_fabirc_receive_Load(object sender, EventArgs e)
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
            MySqlDataAdapter da = new MySqlDataAdapter("select * from grn_view order by grn_number DESC", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["grn_number"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr["grn_date"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["vendor"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr["bill_number"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dr["bill_date"].ToString();
                dataGridView1.Rows[i].Cells[5].Value = dr["po_reff"].ToString();
                dataGridView1.Rows[i].Cells[6].Value = dr["item_code"].ToString();
                dataGridView1.Rows[i].Cells[7].Value = dr["name"].ToString();
                dataGridView1.Rows[i].Cells[8].Value = dr["qty"].ToString();
                dataGridView1.Rows[i].Cells[9].Value = dr["unit"].ToString();
                dataGridView1.Rows[i].Cells[10].Value = dr["rate"].ToString();
                dataGridView1.Rows[i].Cells[10].Value = dr["total"].ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            fill_data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grn_cart grn = new grn_cart();
            grn.button2.Enabled = false;
            grn.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (grn_number== 0)
            {
                MessageBox.Show("Select the GRN to UPDATE");
            }
            else
            {
                grn_cart grn = new grn_cart();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from non_fabric_grn_header where grn_number='" + grn_number + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    grn.textBox2.Text = dr["grn_number"].ToString();
                    grn.dateTimePicker1.Value = System.Convert.ToDateTime(dr["grn_date"].ToString());
                    grn.textBox8.Text = dr["po_reff"].ToString();
                    grn.textBox1.Text = dr["vendor"].ToString();
                    grn.maskedTextBox3.Text = dr["bill_date"].ToString();
                    grn.textBox7.Text = dr["bill_number"].ToString();
                    grn.textBox6.Text = dr["grn_number"].ToString();
                    grn.textBox5.Text = dr["total_amount"].ToString();
                }
                grn.datagride_fill_line();
                grn.button1.Enabled = false;
                grn.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (grn_number == 0)
            {
                MessageBox.Show("Select the GRN to Delete");
            }
            else
            {
                DialogResult result = MessageBox.Show("Do You want to delete this GRN Number "+grn_number, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result==DialogResult.Yes)
                {
                    grn_cart grn = new grn_cart();
                    grn.datagride_fill_line();
                    grn.delete_grn();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete from non_fabric_grn_header where grn_number='" + grn_number + "'";
                    cmd.ExecuteNonQuery();

                    MySqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "delete from non_fabric_grn_line where grn_number='" + grn_number + "'";
                    cmd1.ExecuteNonQuery();

                    MessageBox.Show("GRN Number " + grn_number + " Deleted Sucessfully");
                }
                else
                {

                }
            }
        }

        int grn_number = 0;
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                grn_number = System.Convert.ToInt32(row.Cells["grn"].Value.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text=="GRN NUMBER")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from grn_view where grn_number like '%"+textBox2.Text+"%' order by grn_number DESC", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["grn_number"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["grn_date"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["vendor"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr["bill_number"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr["bill_date"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr["po_reff"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dr["item_code"].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = dr["name"].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = dr["qty"].ToString();
                    dataGridView1.Rows[i].Cells[9].Value = dr["unit"].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = dr["rate"].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = dr["total"].ToString();
                }
            }
            else if(comboBox1.Text=="VENDOR")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from grn_view where vendor like '%" + textBox2.Text + "%' order by grn_number DESC", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["grn_number"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["grn_date"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["vendor"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr["bill_number"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr["bill_date"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr["po_reff"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dr["item_code"].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = dr["name"].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = dr["qty"].ToString();
                    dataGridView1.Rows[i].Cells[9].Value = dr["unit"].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = dr["rate"].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = dr["total"].ToString();
                }
            }
            else if (comboBox1.Text == "ITEM CODE")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from grn_view where item_code like '%" + textBox2.Text + "%' order by grn_number DESC", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["grn_number"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["grn_date"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["vendor"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr["bill_number"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr["bill_date"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr["po_reff"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dr["item_code"].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = dr["name"].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = dr["qty"].ToString();
                    dataGridView1.Rows[i].Cells[9].Value = dr["unit"].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = dr["rate"].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = dr["total"].ToString();
                }
            }
            else if (comboBox1.Text == "BILL NUMBER")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from grn_view where bill_number like '%" + textBox2.Text + "%' order by grn_number DESC", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["grn_number"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["grn_date"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["vendor"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr["bill_number"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr["bill_date"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr["po_reff"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dr["item_code"].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = dr["name"].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = dr["qty"].ToString();
                    dataGridView1.Rows[i].Cells[9].Value = dr["unit"].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = dr["rate"].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = dr["total"].ToString();
                }
            }
            else if (comboBox1.Text =="RECEIVE DATE")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from grn_view where grn_date like '%" + textBox2.Text + "%' order by grn_number DESC", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["grn_number"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["grn_date"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["vendor"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr["bill_number"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr["bill_date"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr["po_reff"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dr["item_code"].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = dr["name"].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = dr["qty"].ToString();
                    dataGridView1.Rows[i].Cells[9].Value = dr["unit"].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = dr["rate"].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = dr["total"].ToString();
                }
            }
            else
            {
                fill_data();
            }
        }
    }
}