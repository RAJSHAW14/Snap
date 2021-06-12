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
    public partial class p_code_wise_issue_view : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public p_code_wise_issue_view()
        {
            InitializeComponent();
        }

        private void p_code_wise_issue_view_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        public void fill_data()
        {
            if (comboBox1.Text == "DEPARTMENT")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_p_code_wise_issue where issue_date between '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and department like '%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["issue_date"].Value = System.Convert.ToDateTime(dr["issue_date"].ToString());
                    dataGridView1.Rows[i].Cells["batchcode"].Value = dr["batchcode"].ToString();
                    dataGridView1.Rows[i].Cells["product_code"].Value = dr["p_code"].ToString();
                    dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                    dataGridView1.Rows[i].Cells["designer"].Value = dr["designer"].ToString();
                    dataGridView1.Rows[i].Cells["fab_qty_details"].Value = dr["fab_qty_details"].ToString();
                    dataGridView1.Rows[i].Cells["fabric_code"].Value = dr["fabric_code"].ToString();
                    dataGridView1.Rows[i].Cells["fabric_name"].Value = dr["fabric_name"].ToString();
                    dataGridView1.Rows[i].Cells["rate"].Value = dr["rate"].ToString();
                    dataGridView1.Rows[i].Cells["qty"].Value = dr["qty"].ToString();
                    dataGridView1.Rows[i].Cells["uom"].Value = dr["uom"].ToString();
                    dataGridView1.Rows[i].Cells["amount"].Value = dr["amount"].ToString();
                    dataGridView1.Rows[i].Cells["req_number"].Value = dr["req_number"].ToString();
                }
            }
            else if (comboBox1.Text == "FABRIC CODE")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_p_code_wise_issue where issue_date between '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and fabric_code like '%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["issue_date"].Value = System.Convert.ToDateTime(dr["issue_date"].ToString());
                    dataGridView1.Rows[i].Cells["batchcode"].Value = dr["batchcode"].ToString();
                    dataGridView1.Rows[i].Cells["product_code"].Value = dr["p_code"].ToString();
                    dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                    dataGridView1.Rows[i].Cells["designer"].Value = dr["designer"].ToString();
                    dataGridView1.Rows[i].Cells["fab_qty_details"].Value = dr["fab_qty_details"].ToString();
                    dataGridView1.Rows[i].Cells["fabric_code"].Value = dr["fabric_code"].ToString();
                    dataGridView1.Rows[i].Cells["fabric_name"].Value = dr["fabric_name"].ToString();
                    dataGridView1.Rows[i].Cells["rate"].Value = dr["rate"].ToString();
                    dataGridView1.Rows[i].Cells["qty"].Value = dr["qty"].ToString();
                    dataGridView1.Rows[i].Cells["uom"].Value = dr["uom"].ToString();
                    dataGridView1.Rows[i].Cells["amount"].Value = dr["amount"].ToString();
                    dataGridView1.Rows[i].Cells["req_number"].Value = dr["req_number"].ToString();
                }
            }
            else if (comboBox1.Text == "BATCHCODE")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_p_code_wise_issue where issue_date between '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and batchcode like '%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["issue_date"].Value = System.Convert.ToDateTime(dr["issue_date"].ToString());
                    dataGridView1.Rows[i].Cells["batchcode"].Value = dr["batchcode"].ToString();
                    dataGridView1.Rows[i].Cells["product_code"].Value = dr["p_code"].ToString();
                    dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                    dataGridView1.Rows[i].Cells["designer"].Value = dr["designer"].ToString();
                    dataGridView1.Rows[i].Cells["fab_qty_details"].Value = dr["fab_qty_details"].ToString();
                    dataGridView1.Rows[i].Cells["fabric_code"].Value = dr["fabric_code"].ToString();
                    dataGridView1.Rows[i].Cells["fabric_name"].Value = dr["fabric_name"].ToString();
                    dataGridView1.Rows[i].Cells["rate"].Value = dr["rate"].ToString();
                    dataGridView1.Rows[i].Cells["qty"].Value = dr["qty"].ToString();
                    dataGridView1.Rows[i].Cells["uom"].Value = dr["uom"].ToString();
                    dataGridView1.Rows[i].Cells["amount"].Value = dr["amount"].ToString();
                    dataGridView1.Rows[i].Cells["req_number"].Value = dr["req_number"].ToString();
                }
            }            
            else if (comboBox1.Text == "REQ NUMBER")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_p_code_wise_issue where issue_date between '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and req_number like '%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["issue_date"].Value = System.Convert.ToDateTime(dr["issue_date"].ToString());
                    dataGridView1.Rows[i].Cells["batchcode"].Value = dr["batchcode"].ToString();
                    dataGridView1.Rows[i].Cells["product_code"].Value = dr["p_code"].ToString();
                    dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                    dataGridView1.Rows[i].Cells["designer"].Value = dr["designer"].ToString();
                    dataGridView1.Rows[i].Cells["fab_qty_details"].Value = dr["fab_qty_details"].ToString();
                    dataGridView1.Rows[i].Cells["fabric_code"].Value = dr["fabric_code"].ToString();
                    dataGridView1.Rows[i].Cells["fabric_name"].Value = dr["fabric_name"].ToString();
                    dataGridView1.Rows[i].Cells["rate"].Value = dr["rate"].ToString();
                    dataGridView1.Rows[i].Cells["qty"].Value = dr["qty"].ToString();
                    dataGridView1.Rows[i].Cells["uom"].Value = dr["uom"].ToString();
                    dataGridView1.Rows[i].Cells["amount"].Value = dr["amount"].ToString();
                    dataGridView1.Rows[i].Cells["req_number"].Value = dr["req_number"].ToString();
                }
            }
            else if (comboBox1.Text == "PRODUCT CODE")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_p_code_wise_issue where issue_date between '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and p_code like '%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    
                    dataGridView1.Rows[i].Cells["issue_date"].Value = System.Convert.ToDateTime(dr["issue_date"].ToString());
                    dataGridView1.Rows[i].Cells["batchcode"].Value = dr["batchcode"].ToString();
                    dataGridView1.Rows[i].Cells["product_code"].Value = dr["p_code"].ToString();
                    dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                    dataGridView1.Rows[i].Cells["designer"].Value = dr["designer"].ToString();
                    dataGridView1.Rows[i].Cells["fab_qty_details"].Value = dr["fab_qty_details"].ToString();
                    dataGridView1.Rows[i].Cells["fabric_code"].Value = dr["fabric_code"].ToString();
                    dataGridView1.Rows[i].Cells["fabric_name"].Value = dr["fabric_name"].ToString();
                    dataGridView1.Rows[i].Cells["rate"].Value = dr["rate"].ToString();
                    dataGridView1.Rows[i].Cells["qty"].Value = dr["qty"].ToString();
                    dataGridView1.Rows[i].Cells["uom"].Value = dr["uom"].ToString();
                    dataGridView1.Rows[i].Cells["amount"].Value = dr["amount"].ToString();
                    dataGridView1.Rows[i].Cells["req_number"].Value = dr["req_number"].ToString();
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_p_code_wise_issue where issue_date between '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["issue_date"].Value = System.Convert.ToDateTime(dr["issue_date"].ToString());
                    dataGridView1.Rows[i].Cells["batchcode"].Value = dr["batchcode"].ToString();
                    dataGridView1.Rows[i].Cells["product_code"].Value = dr["p_code"].ToString();
                    dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                    dataGridView1.Rows[i].Cells["designer"].Value = dr["designer"].ToString();
                    dataGridView1.Rows[i].Cells["fab_qty_details"].Value = dr["fab_qty_details"].ToString();
                    dataGridView1.Rows[i].Cells["fabric_code"].Value = dr["fabric_code"].ToString();
                    dataGridView1.Rows[i].Cells["fabric_name"].Value = dr["fabric_name"].ToString();
                    dataGridView1.Rows[i].Cells["rate"].Value = dr["rate"].ToString();
                    dataGridView1.Rows[i].Cells["qty"].Value = dr["qty"].ToString();
                    dataGridView1.Rows[i].Cells["uom"].Value = dr["uom"].ToString();
                    dataGridView1.Rows[i].Cells["amount"].Value = dr["amount"].ToString();
                    dataGridView1.Rows[i].Cells["req_number"].Value = dr["req_number"].ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fill_data();
        }
    }
}
