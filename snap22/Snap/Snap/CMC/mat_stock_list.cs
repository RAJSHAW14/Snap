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

namespace Snap.CMC
{
    public partial class mat_stock_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public mat_stock_list()
        {
            InitializeComponent();
        }

        private void mat_stock_list_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_data();
            auto_complete_mat_code();
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_mat", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells["mat_code"].Value = dr["mat_code"].ToString();
                dataGridView1.Rows[i].Cells["type"].Value = dr["mat_type"].ToString();
                dataGridView1.Rows[i].Cells["uom"].Value = dr["uom"].ToString();
                dataGridView1.Rows[i].Cells["stock"].Value = dr["stock"].ToString();
                dataGridView1.Rows[i].Cells["min_stock"].Value = dr["min_stock"].ToString();
            }
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if(System.Convert.ToDouble(row.Cells["min_stock"].Value)>System.Convert.ToDouble(row.Cells["stock"].Value))
                {
                    row.DefaultCellStyle.BackColor = Color.Red; 
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            fill_data();
        }

        public void auto_complete_mat_code()
        {
            MySqlCommand cmd = new MySqlCommand("select emb_name from emb_master", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection autocomplete = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                autocomplete.Add(dr.GetString(0));

            }
            textBox1.AutoCompleteCustomSource = autocomplete;
            dr.Close();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {            
            int i = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_mat where mat_code='"+textBox1.Text+"'",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            i = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if(i==0)
            {
                MessageBox.Show("Item Code Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataGridView1.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    int j = dataGridView1.Rows.Add();
                    dataGridView1.Rows[j].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[j].Cells["mat_code"].Value = dr["mat_code"].ToString();
                    dataGridView1.Rows[j].Cells["type"].Value = dr["mat_type"].ToString();
                    dataGridView1.Rows[j].Cells["uom"].Value = dr["uom"].ToString();
                    dataGridView1.Rows[j].Cells["stock"].Value = dr["stock"].ToString();
                    dataGridView1.Rows[j].Cells["min_stock"].Value = dr["min_stock"].ToString();
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (System.Convert.ToDouble(row.Cells["min_stock"].Value) > System.Convert.ToDouble(row.Cells["stock"].Value))
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           if(mat_code1=="")
           {
               MessageBox.Show("Please select the cell to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           else
           {
               int i=0;
               MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_mat_stock_in where mat_code='" + mat_code1.ToString() + "'", con);
               DataTable dt = new DataTable();
               da.Fill(dt);
               i = System.Convert.ToInt32(dt.Rows.Count.ToString());
               if(i==0)
               {
                   MySqlCommand cmd = con.CreateCommand();
                   cmd.CommandType = CommandType.Text;
                   cmd.CommandText = "delete from cmc_mat where mat_code='"+mat_code1.ToString()+"'";
                   cmd.ExecuteNonQuery();
                   MessageBox.Show("Item deleted sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   mat_code1 = "";
                   dataGridView1.Rows.Clear();
                   fill_data();
               }
               else
               {
                   MessageBox.Show("Transaction Already done on this item cannot able to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   mat_code1 = "";
               }
           }
        }

        string mat_code1 ="";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                mat_code1 = row.Cells["mat_code"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add_mat_stock stock = new add_mat_stock();
            stock.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_mat mat = new add_mat();
            mat.Show();
        }
    }
}
