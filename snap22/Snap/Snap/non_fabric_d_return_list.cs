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
    public partial class non_fabric_d_return_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public non_fabric_d_return_list()
        {
            InitializeComponent();
        }

        private void non_fabric_d_return_list_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();                
            }
            con.Open();
        }

        public void fill_data_gride()
        {
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from non_fabric_d_return where date between '"+dateTimePicker1.Value.ToString("yyyy-MM-dd")+ "' and '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["ID"].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells["batchcode"].Value = dr["batchcode"].ToString();
                dataGridView1.Rows[i].Cells["p_code"].Value = dr["p_code"].ToString();
                dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                dataGridView1.Rows[i].Cells["designer"].Value = dr["designer"].ToString();
                dataGridView1.Rows[i].Cells["non_fabric_code"].Value = dr["non_fabric_code"].ToString();
                dataGridView1.Rows[i].Cells["categories"].Value = dr["categories"].ToString();
                dataGridView1.Rows[i].Cells["sub_categories"].Value = dr["sub_categories"].ToString();
                dataGridView1.Rows[i].Cells["unit"].Value = dr["uom"].ToString();
                dataGridView1.Rows[i].Cells["rate"].Value = dr["rate"].ToString();
                dataGridView1.Rows[i].Cells["qty"].Value = dr["qty"].ToString();
                dataGridView1.Rows[i].Cells["cost"].Value = dr["amount"].ToString();
                dataGridView1.Rows[i].Cells["return_type"].Value = dr["return_from"].ToString();
                dataGridView1.Rows[i].Cells["date"].Value = System.Convert.ToDateTime(dr["date"].ToString());

            }

        }
        
        int return_id = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                return_id = System.Convert.ToInt32(row.Cells["id"].Value.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text=="")
            {
                dataGridView1.Rows.Clear();
                fill_data_gride();
            }
            else if(comboBox1.Text== "BATCHCODE")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from non_fabric_d_return where date between '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and batchcode like '%"+textBox1.Text+"%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["ID"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["batchcode"].Value = dr["batchcode"].ToString();
                    dataGridView1.Rows[i].Cells["p_code"].Value = dr["p_code"].ToString();
                    dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                    dataGridView1.Rows[i].Cells["designer"].Value = dr["designer"].ToString();
                    dataGridView1.Rows[i].Cells["non_fabric_code"].Value = dr["non_fabric_code"].ToString();
                    dataGridView1.Rows[i].Cells["categories"].Value = dr["categories"].ToString();
                    dataGridView1.Rows[i].Cells["sub_categories"].Value = dr["sub_categories"].ToString();
                    dataGridView1.Rows[i].Cells["unit"].Value = dr["uom"].ToString();
                    dataGridView1.Rows[i].Cells["rate"].Value = dr["rate"].ToString();
                    dataGridView1.Rows[i].Cells["qty"].Value = dr["qty"].ToString();
                    dataGridView1.Rows[i].Cells["cost"].Value = dr["amount"].ToString();
                    dataGridView1.Rows[i].Cells["return_type"].Value = dr["return_from"].ToString();
                    dataGridView1.Rows[i].Cells["date"].Value = System.Convert.ToDateTime(dr["date"].ToString());
                }

            }
            else if (comboBox1.Text == "DEPARTMENT")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from non_fabric_d_return where date between '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and department like '%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["ID"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["batchcode"].Value = dr["batchcode"].ToString();
                    dataGridView1.Rows[i].Cells["p_code"].Value = dr["p_code"].ToString();
                    dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                    dataGridView1.Rows[i].Cells["designer"].Value = dr["designer"].ToString();
                    dataGridView1.Rows[i].Cells["non_fabric_code"].Value = dr["non_fabric_code"].ToString();
                    dataGridView1.Rows[i].Cells["categories"].Value = dr["categories"].ToString();
                    dataGridView1.Rows[i].Cells["sub_categories"].Value = dr["sub_categories"].ToString();
                    dataGridView1.Rows[i].Cells["unit"].Value = dr["uom"].ToString();
                    dataGridView1.Rows[i].Cells["rate"].Value = dr["rate"].ToString();
                    dataGridView1.Rows[i].Cells["qty"].Value = dr["qty"].ToString();
                    dataGridView1.Rows[i].Cells["cost"].Value = dr["amount"].ToString();
                    dataGridView1.Rows[i].Cells["return_type"].Value = dr["return_from"].ToString();
                    dataGridView1.Rows[i].Cells["date"].Value = System.Convert.ToDateTime(dr["date"].ToString());
                }

            }
            else if (comboBox1.Text == "NON-FABRIC CODE")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from non_fabric_d_return where date between '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and non_fabric_code like '%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["ID"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["batchcode"].Value = dr["batchcode"].ToString();
                    dataGridView1.Rows[i].Cells["p_code"].Value = dr["p_code"].ToString();
                    dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                    dataGridView1.Rows[i].Cells["designer"].Value = dr["designer"].ToString();
                    dataGridView1.Rows[i].Cells["non_fabric_code"].Value = dr["non_fabric_code"].ToString();
                    dataGridView1.Rows[i].Cells["categories"].Value = dr["categories"].ToString();
                    dataGridView1.Rows[i].Cells["sub_categories"].Value = dr["sub_categories"].ToString();
                    dataGridView1.Rows[i].Cells["unit"].Value = dr["uom"].ToString();
                    dataGridView1.Rows[i].Cells["rate"].Value = dr["rate"].ToString();
                    dataGridView1.Rows[i].Cells["qty"].Value = dr["qty"].ToString();
                    dataGridView1.Rows[i].Cells["cost"].Value = dr["amount"].ToString();
                    dataGridView1.Rows[i].Cells["return_type"].Value = dr["return_from"].ToString();
                    dataGridView1.Rows[i].Cells["date"].Value = System.Convert.ToDateTime(dr["date"].ToString());
                }

            }
            else if (comboBox1.Text == "RETURN FROM")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from non_fabric_d_return where date between '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and return_from like '%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["ID"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["batchcode"].Value = dr["batchcode"].ToString();
                    dataGridView1.Rows[i].Cells["p_code"].Value = dr["p_code"].ToString();
                    dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                    dataGridView1.Rows[i].Cells["designer"].Value = dr["designer"].ToString();
                    dataGridView1.Rows[i].Cells["non_fabric_code"].Value = dr["non_fabric_code"].ToString();
                    dataGridView1.Rows[i].Cells["categories"].Value = dr["categories"].ToString();
                    dataGridView1.Rows[i].Cells["sub_categories"].Value = dr["sub_categories"].ToString();
                    dataGridView1.Rows[i].Cells["unit"].Value = dr["uom"].ToString();
                    dataGridView1.Rows[i].Cells["rate"].Value = dr["rate"].ToString();
                    dataGridView1.Rows[i].Cells["qty"].Value = dr["qty"].ToString();
                    dataGridView1.Rows[i].Cells["cost"].Value = dr["amount"].ToString();
                    dataGridView1.Rows[i].Cells["return_type"].Value = dr["return_from"].ToString();
                    dataGridView1.Rows[i].Cells["date"].Value = System.Convert.ToDateTime(dr["date"].ToString());
                }

            }
            else
            {
                dataGridView1.Rows.Clear();
                fill_data_gride();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            fill_data_gride();
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            non_fabric_department_return @return = new non_fabric_department_return();
            @return.button1.Enabled = true;
            @return.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(return_id==0)
            {
                MessageBox.Show("Please select the cell to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                non_fabric_department_return @return = new non_fabric_department_return();
                @return.button2.Enabled = true;
                @return.textBox11.Text = return_id.ToString();
                @return.fill_Data();
                @return.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (return_id == 0)
            {
                MessageBox.Show("Please select the cell to Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                non_fabric_department_return @return = new non_fabric_department_return();
                
                @return.textBox11.Text = return_id.ToString();
                @return.fill_Data_delete();
                MessageBox.Show("Deleted Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Rows.Clear();
                fill_data_gride();
            }
        }
    }
}
