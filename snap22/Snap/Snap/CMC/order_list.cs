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
using System.Globalization;

namespace Snap.CMC
{
    public partial class order_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public order_list()
        {
            InitializeComponent();
        }

        private void order_list_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Close();
            fill_data();
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_order_view order by id DESC", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells["order_number"].Value = dr["order_number"].ToString();
                dataGridView1.Rows[i].Cells["order_date"].Value = System.Convert.ToDateTime(dr["date"].ToString());              
                dataGridView1.Rows[i].Cells["batchcode"].Value = dr["batchcode"].ToString();
                //dataGridView1.Rows[i].Cells["issue_date"].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                dataGridView1.Rows[i].Cells["designer"].Value = dr["designer"].ToString();
                dataGridView1.Rows[i].Cells["design_code"].Value = dr["design_code"].ToString();
                dataGridView1.Rows[i].Cells["design_type"].Value = dr["design_type"].ToString();
                dataGridView1.Rows[i].Cells["design_description"].Value = dr["design_description"].ToString();
                dataGridView1.Rows[i].Cells["fabric"].Value = dr["fabric"].ToString();
                dataGridView1.Rows[i].Cells["color"].Value = dr["color"].ToString();
                dataGridView1.Rows[i].Cells["component"].Value = dr["component"].ToString();
                dataGridView1.Rows[i].Cells["status"].Value = dr["status"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            order_cart cart = new order_cart();
            cart.button2.Visible = false;
            cart.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            fill_data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(id_value=="")
            {
                MessageBox.Show("Please select the cell to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                order_cart cart = new order_cart();
                cart.button1.Visible = false;
                cart.textBox10.Text = id_value.ToString();
                cart.textBox1.ReadOnly = true;
                id_value = "";
                cart.fill_data();
                cart.textBox1.ReadOnly = true;
                cart.Show();
            }
        }

        string id_value = "";
        DateTime dtime;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {   
            if (e.RowIndex >= 0)
            {
                dtime = DateTime.Parse(this.dataGridView1.Rows[e.RowIndex].Cells["order_date"].Value.ToString());
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id_value = row.Cells["id"].Value.ToString();                
            }            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(id_value=="")
            {
                MessageBox.Show("Please select the cell to update status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                update_order_status status = new update_order_status();
                status.textBox3.Text = id_value.ToString();
                status.fill_data();
                id_value = "";
                status.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text=="ORDER NUMBER")
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_order_view where order_number like '%"+textBox1.Text+"%' order by id DESC", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["order_number"].Value = dr["order_number"].ToString();
                    dataGridView1.Rows[i].Cells["order_date"].Value = System.Convert.ToDateTime(dr["date"].ToString());
                    dataGridView1.Rows[i].Cells["batchcode"].Value = dr["batchcode"].ToString();
                    //dataGridView1.Rows[i].Cells["issue_date"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                    dataGridView1.Rows[i].Cells["designer"].Value = dr["designer"].ToString();
                    dataGridView1.Rows[i].Cells["design_code"].Value = dr["design_code"].ToString();
                    dataGridView1.Rows[i].Cells["design_type"].Value = dr["design_type"].ToString();
                    dataGridView1.Rows[i].Cells["design_description"].Value = dr["design_description"].ToString();
                    dataGridView1.Rows[i].Cells["fabric"].Value = dr["fabric"].ToString();
                    dataGridView1.Rows[i].Cells["color"].Value = dr["color"].ToString();
                    dataGridView1.Rows[i].Cells["component"].Value = dr["component"].ToString();
                    dataGridView1.Rows[i].Cells["status"].Value = dr["status"].ToString();
                }
            }
            else if(comboBox1.Text=="STATUS")
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_order_view where status = '" + textBox1.Text + "' order by id DESC", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["order_number"].Value = dr["order_number"].ToString();
                    dataGridView1.Rows[i].Cells["order_date"].Value = System.Convert.ToDateTime(dr["date"].ToString());
                    dataGridView1.Rows[i].Cells["batchcode"].Value = dr["batchcode"].ToString();
                    //dataGridView1.Rows[i].Cells["issue_date"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                    dataGridView1.Rows[i].Cells["designer"].Value = dr["designer"].ToString();
                    dataGridView1.Rows[i].Cells["design_code"].Value = dr["design_code"].ToString();
                    dataGridView1.Rows[i].Cells["design_type"].Value = dr["design_type"].ToString();
                    dataGridView1.Rows[i].Cells["design_description"].Value = dr["design_description"].ToString();
                    dataGridView1.Rows[i].Cells["fabric"].Value = dr["fabric"].ToString();
                    dataGridView1.Rows[i].Cells["color"].Value = dr["color"].ToString();
                    dataGridView1.Rows[i].Cells["component"].Value = dr["component"].ToString();
                    dataGridView1.Rows[i].Cells["status"].Value = dr["status"].ToString();
                }
            }

            else if (comboBox1.Text == "DEPARTMENT")
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_order_view where department like '%" + textBox1.Text + "%' order by id DESC", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["order_number"].Value = dr["order_number"].ToString();
                    dataGridView1.Rows[i].Cells["order_date"].Value = System.Convert.ToDateTime(dr["date"].ToString());
                    dataGridView1.Rows[i].Cells["batchcode"].Value = dr["batchcode"].ToString();
                    //dataGridView1.Rows[i].Cells["issue_date"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                    dataGridView1.Rows[i].Cells["designer"].Value = dr["designer"].ToString();
                    dataGridView1.Rows[i].Cells["design_code"].Value = dr["design_code"].ToString();
                    dataGridView1.Rows[i].Cells["design_type"].Value = dr["design_type"].ToString();
                    dataGridView1.Rows[i].Cells["design_description"].Value = dr["design_description"].ToString();
                    dataGridView1.Rows[i].Cells["fabric"].Value = dr["fabric"].ToString();
                    dataGridView1.Rows[i].Cells["color"].Value = dr["color"].ToString();
                    dataGridView1.Rows[i].Cells["component"].Value = dr["component"].ToString();
                    dataGridView1.Rows[i].Cells["status"].Value = dr["status"].ToString();
                }
            }

            else if (comboBox1.Text == "DESIGN CODE")
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_order_view where design_code = '" + textBox1.Text + "' order by id DESC", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["order_number"].Value = dr["order_number"].ToString();
                    dataGridView1.Rows[i].Cells["order_date"].Value = System.Convert.ToDateTime(dr["date"].ToString());
                    dataGridView1.Rows[i].Cells["batchcode"].Value = dr["batchcode"].ToString();
                    //dataGridView1.Rows[i].Cells["issue_date"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                    dataGridView1.Rows[i].Cells["designer"].Value = dr["designer"].ToString();
                    dataGridView1.Rows[i].Cells["design_code"].Value = dr["design_code"].ToString();
                    dataGridView1.Rows[i].Cells["design_type"].Value = dr["design_type"].ToString();
                    dataGridView1.Rows[i].Cells["design_description"].Value = dr["design_description"].ToString();
                    dataGridView1.Rows[i].Cells["fabric"].Value = dr["fabric"].ToString();
                    dataGridView1.Rows[i].Cells["color"].Value = dr["color"].ToString();
                    dataGridView1.Rows[i].Cells["component"].Value = dr["component"].ToString();
                    dataGridView1.Rows[i].Cells["status"].Value = dr["status"].ToString();
                }
            }

            else
            {
                dataGridView1.Rows.Clear();
                fill_data();
            }
        }
    }
}
