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
    public partial class grn_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public grn_list()
        {
            InitializeComponent();
        }

        private void grn_list_Load(object sender, EventArgs e)
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
            MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_grn_header order by id desc", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells["vendor"].Value = dr["vendor"].ToString();
                dataGridView1.Rows[i].Cells["grn_number"].Value = dr["grn_number"].ToString();
                dataGridView1.Rows[i].Cells["grn_date"].Value = System.Convert.ToDateTime(dr["grn_date"].ToString());
                dataGridView1.Rows[i].Cells["bill_number"].Value = dr["bill_number"].ToString();
                dataGridView1.Rows[i].Cells["bill_date"].Value = System.Convert.ToDateTime(dr["bill_date"].ToString());
                dataGridView1.Rows[i].Cells["freight"].Value = dr["freight"].ToString();
                dataGridView1.Rows[i].Cells["total_amount"].Value = dr["total"].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            fill_data();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.Text == "VENDOR")
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_grn where vendor like '%"+textBox1.Text+"%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["grn_number"].Value = dr["grn_number"].ToString();
                    dataGridView1.Rows[i].Cells["grn_date"].Value = dr["grn_date"].ToString();
                    dataGridView1.Rows[i].Cells["po_number"].Value = dr["po_number"].ToString();
                    dataGridView1.Rows[i].Cells["po_date"].Value = dr["po_date"].ToString();
                    dataGridView1.Rows[i].Cells["vendor"].Value = dr["vendor"].ToString();
                    dataGridView1.Rows[i].Cells["bill_number"].Value = dr["bill_number"].ToString();
                    dataGridView1.Rows[i].Cells["bill_date"].Value = dr["bill_date"].ToString();
                    dataGridView1.Rows[i].Cells["fabric_code"].Value = dr["fabric_code"].ToString();
                    dataGridView1.Rows[i].Cells["fabric_name"].Value = dr["fabric_name"].ToString();
                    dataGridView1.Rows[i].Cells["color"].Value = dr["color"].ToString();
                    dataGridView1.Rows[i].Cells["rate"].Value = dr["rate"].ToString();
                    dataGridView1.Rows[i].Cells["qty"].Value = dr["qty"].ToString();
                    dataGridView1.Rows[i].Cells["uom"].Value = dr["uom"].ToString();
                    dataGridView1.Rows[i].Cells["amount"].Value = dr["amount"].ToString();
                    dataGridView1.Rows[i].Cells["gst"].Value = dr["gst"].ToString();
                    dataGridView1.Rows[i].Cells["hsn"].Value = dr["hsn"].ToString();
                    dataGridView1.Rows[i].Cells["total_amount"].Value = dr["total_amount"].ToString();
                    dataGridView1.Rows[i].Cells["remarks"].Value = dr["remarks"].ToString();
                }
            }

            else if (comboBox1.Text == "FABRIC CODE")
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_grn where fabric_code like '%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["grn_number"].Value = dr["grn_number"].ToString();
                    dataGridView1.Rows[i].Cells["grn_date"].Value = dr["grn_date"].ToString();
                    dataGridView1.Rows[i].Cells["po_number"].Value = dr["po_number"].ToString();
                    dataGridView1.Rows[i].Cells["po_date"].Value = dr["po_date"].ToString();
                    dataGridView1.Rows[i].Cells["vendor"].Value = dr["vendor"].ToString();
                    dataGridView1.Rows[i].Cells["bill_number"].Value = dr["bill_number"].ToString();
                    dataGridView1.Rows[i].Cells["bill_date"].Value = dr["bill_date"].ToString();
                    dataGridView1.Rows[i].Cells["fabric_code"].Value = dr["fabric_code"].ToString();
                    dataGridView1.Rows[i].Cells["fabric_name"].Value = dr["fabric_name"].ToString();
                    dataGridView1.Rows[i].Cells["color"].Value = dr["color"].ToString();
                    dataGridView1.Rows[i].Cells["rate"].Value = dr["rate"].ToString();
                    dataGridView1.Rows[i].Cells["qty"].Value = dr["qty"].ToString();
                    dataGridView1.Rows[i].Cells["uom"].Value = dr["uom"].ToString();
                    dataGridView1.Rows[i].Cells["amount"].Value = dr["amount"].ToString();
                    dataGridView1.Rows[i].Cells["gst"].Value = dr["gst"].ToString();
                    dataGridView1.Rows[i].Cells["hsn"].Value = dr["hsn"].ToString();
                    dataGridView1.Rows[i].Cells["total_amount"].Value = dr["total_amount"].ToString();
                    dataGridView1.Rows[i].Cells["remarks"].Value = dr["remarks"].ToString();
                }
            }

            else if (comboBox1.Text == "GRN NUMBER")
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_grn where grn_number like '%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["grn_number"].Value = dr["grn_number"].ToString();
                    dataGridView1.Rows[i].Cells["grn_date"].Value = dr["grn_date"].ToString();
                    dataGridView1.Rows[i].Cells["po_number"].Value = dr["po_number"].ToString();
                    dataGridView1.Rows[i].Cells["po_date"].Value = dr["po_date"].ToString();
                    dataGridView1.Rows[i].Cells["vendor"].Value = dr["vendor"].ToString();
                    dataGridView1.Rows[i].Cells["bill_number"].Value = dr["bill_number"].ToString();
                    dataGridView1.Rows[i].Cells["bill_date"].Value = dr["bill_date"].ToString();
                    dataGridView1.Rows[i].Cells["fabric_code"].Value = dr["fabric_code"].ToString();
                    dataGridView1.Rows[i].Cells["fabric_name"].Value = dr["fabric_name"].ToString();
                    dataGridView1.Rows[i].Cells["color"].Value = dr["color"].ToString();
                    dataGridView1.Rows[i].Cells["rate"].Value = dr["rate"].ToString();
                    dataGridView1.Rows[i].Cells["qty"].Value = dr["qty"].ToString();
                    dataGridView1.Rows[i].Cells["uom"].Value = dr["uom"].ToString();
                    dataGridView1.Rows[i].Cells["amount"].Value = dr["amount"].ToString();
                    dataGridView1.Rows[i].Cells["gst"].Value = dr["gst"].ToString();
                    dataGridView1.Rows[i].Cells["hsn"].Value = dr["hsn"].ToString();
                    dataGridView1.Rows[i].Cells["total_amount"].Value = dr["total_amount"].ToString();
                    dataGridView1.Rows[i].Cells["remarks"].Value = dr["remarks"].ToString();
                }
            }

            else if (comboBox1.Text == "BILL NUMBER")
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_grn where bill_number like '%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["grn_number"].Value = dr["grn_number"].ToString();
                    dataGridView1.Rows[i].Cells["grn_date"].Value = dr["grn_date"].ToString();
                    dataGridView1.Rows[i].Cells["po_number"].Value = dr["po_number"].ToString();
                    dataGridView1.Rows[i].Cells["po_date"].Value = dr["po_date"].ToString();
                    dataGridView1.Rows[i].Cells["vendor"].Value = dr["vendor"].ToString();
                    dataGridView1.Rows[i].Cells["bill_number"].Value = dr["bill_number"].ToString();
                    dataGridView1.Rows[i].Cells["bill_date"].Value = dr["bill_date"].ToString();
                    dataGridView1.Rows[i].Cells["fabric_code"].Value = dr["fabric_code"].ToString();
                    dataGridView1.Rows[i].Cells["fabric_name"].Value = dr["fabric_name"].ToString();
                    dataGridView1.Rows[i].Cells["color"].Value = dr["color"].ToString();
                    dataGridView1.Rows[i].Cells["rate"].Value = dr["rate"].ToString();
                    dataGridView1.Rows[i].Cells["qty"].Value = dr["qty"].ToString();
                    dataGridView1.Rows[i].Cells["uom"].Value = dr["uom"].ToString();
                    dataGridView1.Rows[i].Cells["amount"].Value = dr["amount"].ToString();
                    dataGridView1.Rows[i].Cells["gst"].Value = dr["gst"].ToString();
                    dataGridView1.Rows[i].Cells["hsn"].Value = dr["hsn"].ToString();
                    dataGridView1.Rows[i].Cells["total_amount"].Value = dr["total_amount"].ToString();
                    dataGridView1.Rows[i].Cells["remarks"].Value = dr["remarks"].ToString();
                }
            }

            else if (comboBox1.Text == "PO NUMBER")
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_grn where po_number like '%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["grn_number"].Value = dr["grn_number"].ToString();
                    dataGridView1.Rows[i].Cells["grn_date"].Value = dr["grn_date"].ToString();
                    dataGridView1.Rows[i].Cells["po_number"].Value = dr["po_number"].ToString();
                    dataGridView1.Rows[i].Cells["po_date"].Value = dr["po_date"].ToString();
                    dataGridView1.Rows[i].Cells["vendor"].Value = dr["vendor"].ToString();
                    dataGridView1.Rows[i].Cells["bill_number"].Value = dr["bill_number"].ToString();
                    dataGridView1.Rows[i].Cells["bill_date"].Value = dr["bill_date"].ToString();
                    dataGridView1.Rows[i].Cells["fabric_code"].Value = dr["fabric_code"].ToString();
                    dataGridView1.Rows[i].Cells["fabric_name"].Value = dr["fabric_name"].ToString();
                    dataGridView1.Rows[i].Cells["color"].Value = dr["color"].ToString();
                    dataGridView1.Rows[i].Cells["rate"].Value = dr["rate"].ToString();
                    dataGridView1.Rows[i].Cells["qty"].Value = dr["qty"].ToString();
                    dataGridView1.Rows[i].Cells["uom"].Value = dr["uom"].ToString();
                    dataGridView1.Rows[i].Cells["amount"].Value = dr["amount"].ToString();
                    dataGridView1.Rows[i].Cells["gst"].Value = dr["gst"].ToString();
                    dataGridView1.Rows[i].Cells["hsn"].Value = dr["hsn"].ToString();
                    dataGridView1.Rows[i].Cells["total_amount"].Value = dr["total_amount"].ToString();
                    dataGridView1.Rows[i].Cells["remarks"].Value = dr["remarks"].ToString();
                }
            }

            else
            {
                dataGridView1.Rows.Clear();
                fill_data();
            }
        }

        

        string id_number = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id_number = row.Cells["id"].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            grn_cart cart = new grn_cart();
            cart.button3.Visible = false;
            cart.Show();
        }

        string edit_status;
        private void button1_Click(object sender, EventArgs e)
        {
            if(id_number=="")
            {
                MessageBox.Show("Please select the cell to Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select edit_status,grn_number from fabric_grn_header where id='" + id_number.ToString() + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    edit_status = dr["edit_status"].ToString();
                }
                if(edit_status=="YES")
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE fabric_grn_header SET reverse ='REVERSE' where id='" + id_number.ToString() + "'";
                    cmd.ExecuteNonQuery();

                    grn_cart cart = new grn_cart();
                    cart.reverse_transaction();

                }
                else
                {
                    MessageBox.Show("Than Already Generated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
