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

namespace Snap.costing
{
    public partial class emb_master_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public emb_master_list()
        {
            InitializeComponent();
        }

        private void emb_master_list_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            auto_complete();
            fill_data();
        }

        public void auto_complete()
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

        private void button5_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Enter emb name to search");
            }
            else
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from emb_master where emb_name like '%"+textBox1.Text+"%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["emb_code"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["emb_name"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr["uom"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr["na_rate"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr["fixed_rate"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dr["costing_rate"].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = dr["emb_type"].ToString();
                }
            }
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from emb_master", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr["emb_code"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["emb_name"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr["uom"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dr["na_rate"].ToString();
                dataGridView1.Rows[i].Cells[5].Value = dr["fixed_rate"].ToString();
                dataGridView1.Rows[i].Cells[6].Value = dr["costing_rate"].ToString();
                dataGridView1.Rows[i].Cells[7].Value = dr["emb_type"].ToString();
            }
        }

        public void reload()
        {
            dataGridView1.Rows.Clear();
            fill_data();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            emb_master_cart cart = new emb_master_cart();
            cart.button2.Enabled = false;
            cart.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(id_value==0)
            {
                MessageBox.Show("Please select the cell to edit");
            }
            else
            {
                emb_master_cart cart = new emb_master_cart();
                cart.textBox5.Text = id_value.ToString();
                cart.fill_data();
                cart.richTextBox1.ReadOnly = true;
                cart.button1.Enabled = false;
                cart.Show();
            }
        }

        int id_value = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id_value = System.Convert.ToInt32(row.Cells["id"].Value.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(id_value==0)
            {
                MessageBox.Show("Please select the cell to edit");
            }
            else
            {
                DialogResult result = MessageBox.Show("Are You Sure Want to delete this EMB", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if(result==DialogResult.Yes)
                {
                    int i = 0;
                    MySqlDataAdapter da = new MySqlDataAdapter("select * from emb_consumption_header where emb_id='" + id_value + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    i=System.Convert.ToInt32(dt.Rows.Count.ToString());
                    if(i==0)
                    {
                        MySqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "delete from emb_master where id='" + id_value + "'";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("EMB Deleted Sucessfully");
                        reload();
                        textBox1.Clear();
                        id_value = 0;
                    }
                    else
                    {
                        MessageBox.Show("Consumption Entered Already");
                    }                    
                }
                else
                {

                }
            }           
        }
    }
}
