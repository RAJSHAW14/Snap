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

namespace Snap.IT
{
    public partial class issue_item : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public issue_item()
        {
            InitializeComponent();
        }

        private void issue_item_Load(object sender, EventArgs e)
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
            MySqlDataAdapter da = new MySqlDataAdapter("select * from it_user", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["user_id"].Value = dr["user_id"].ToString();
                dataGridView1.Rows[i].Cells["name"].Value = dr["user_name"].ToString();
                dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text== "USER ID")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from it_user where user_id like '%"+textBox1.Text+"%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["user_id"].Value = dr["user_id"].ToString();
                    dataGridView1.Rows[i].Cells["name"].Value = dr["user_name"].ToString();
                    dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                }
            }
            else if (comboBox1.Text == "NAME")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from it_user where user_name like '%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["user_id"].Value = dr["user_id"].ToString();
                    dataGridView1.Rows[i].Cells["name"].Value = dr["user_name"].ToString();
                    dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                }
            }
            else if (comboBox1.Text == "DEPARTMENT")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from it_user where department like '%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["user_id"].Value = dr["user_id"].ToString();
                    dataGridView1.Rows[i].Cells["name"].Value = dr["user_name"].ToString();
                    dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
                fill_data();
            }
        }

        string cat;
        private void button2_Click(object sender, EventArgs e)
        {
            if(user_id1=="")
            {
                MessageBox.Show("Please select the user first","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if(textBox2.Text=="")
                {
                    MessageBox.Show("Some Error! Please try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MySqlDataAdapter da = new MySqlDataAdapter("select * from it_item where id = '" + textBox2.Text + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach(DataRow dr in dt.Rows)
                    {
                        cat = dr["catagory"].ToString();
                    }

                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update it_item set assign_user = '"+user_id1.ToString()+ "' where id = '"+textBox2.Text+"'";
                    cmd.ExecuteNonQuery();

                    MySqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "update it_item_catagory set it_stock = it_stock-1, user_stock=user_stock+1 where Catagory = '" + cat.ToString() + "'";
                    cmd1.ExecuteNonQuery();

                    MessageBox.Show("Item Issued Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        string user_id1 = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                user_id1 = System.Convert.ToString(row.Cells["user_id"].Value.ToString());
            }
        }
    }
}
