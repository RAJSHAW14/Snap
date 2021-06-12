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
    public partial class batchcode_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public batchcode_list()
        {
            InitializeComponent();
        }

        public void datagrid_reload()
        {
            dataGridView1.Rows.Clear();
            datagrid_load();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "Date Search")
            {
                datagrid_reload();

            }
            else
            {
                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "select * from batch_code_master where generation_date like '%" + textBox4.Text + "%'";
                cmd3.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da3 = new MySqlDataAdapter(cmd3);
                da3.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = dr["id"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = dr["batchcode"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = dr["batchsize"].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = dr["department"].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = dr["generation_date"].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = dr["style_code"].ToString();
                    dataGridView1.Rows[n].Cells[6].Value = dr["style_colour"].ToString();
                }
            }
        }

        private void batchcode_list_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            datagrid_load();
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "Batchcode Search")
            {
                datagrid_reload();
            }
            else
            {
                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "select * from batch_code_master where batchcode like '%" + textBox1.Text + "%'";
                cmd3.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da3 = new MySqlDataAdapter(cmd3);
                da3.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = dr["id"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = dr["batchcode"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = dr["batchsize"].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = dr["department"].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = dr["generation_date"].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = dr["style_code"].ToString();
                    dataGridView1.Rows[n].Cells[6].Value = dr["style_colour"].ToString();
                }
            }
        }

        public void datagrid_load()
        {
            MySqlCommand cmd3 = con.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "select * from batch_code_master";
            cmd3.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da3 = new MySqlDataAdapter(cmd3);
            da3.Fill(dt);
            //dataGridView1.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr["id"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr["batchcode"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr["batchsize"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = dr["department"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = dr["generation_date"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = dr["style_code"].ToString();
                dataGridView1.Rows[n].Cells[6].Value = dr["style_colour"].ToString();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "Department Search")
            {
                datagrid_reload();
            }
            else
            {
                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "select * from batch_code_master where department like '%" + textBox2.Text + "%'";
                cmd3.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da3 = new MySqlDataAdapter(cmd3);
                da3.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = dr["id"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = dr["batchcode"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = dr["batchsize"].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = dr["department"].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = dr["generation_date"].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = dr["style_code"].ToString();
                    dataGridView1.Rows[n].Cells[6].Value = dr["style_colour"].ToString();
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "Style Code Search")
            {
                datagrid_reload();
            }
            else
            {
                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "select * from batch_code_master where style_code like '%" + textBox3.Text + "%'";
                cmd3.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da3 = new MySqlDataAdapter(cmd3);
                da3.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = dr["id"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = dr["batchcode"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = dr["batchsize"].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = dr["department"].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = dr["generation_date"].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = dr["style_code"].ToString();
                    dataGridView1.Rows[n].Cells[6].Value = dr["style_colour"].ToString();
                }
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Batchcode Search";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Batchcode Search")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Department Search")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Department Search";
                textBox2.ForeColor = Color.Silver;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Style Code Search")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Style Code Search";
                textBox3.ForeColor = Color.Silver;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Date Search";
                textBox4.ForeColor = Color.Silver;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Date Search")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            datagrid_reload();
        }
        public int batch_id=0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox5.Text= row.Cells["id"].Value.ToString();
                batch_id = System.Convert.ToInt32(row.Cells["id"].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (batch_id == 0)
            {
                MessageBox.Show("Select the Batchcode First");
            }
            else
            {
                
                product_code_viewcs product = new product_code_viewcs();
                product.textBox1.Text = textBox5.Text;
                product.Show();

            }
        }        
    }
}
