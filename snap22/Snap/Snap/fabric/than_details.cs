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
    public partial class than_details : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public than_details()
        {
            InitializeComponent();
        }

        private void than_details_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_grn where id='" + textBox5.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                textBox1.Text = dr["fabric_code"].ToString();
                textBox2.Text = dr["grn_number"].ToString();
                textBox3.Text = dr["qty"].ToString();
                textBox4.Text = dr["qty"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(textBox1.Text,textBox2.Text);
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double sum_of_amt = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sum_of_amt += System.Convert.ToDouble(dataGridView1.Rows[i].Cells["qty"].Value);
            }
            textBox4.Text = System.Convert.ToString(System.Convert.ToDouble(textBox3.Text) - sum_of_amt);
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            double sum_of_amt = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sum_of_amt += System.Convert.ToDouble(dataGridView1.Rows[i].Cells["qty"].Value);
            }
            textBox4.Text = System.Convert.ToString(System.Convert.ToDouble(textBox3.Text) - sum_of_amt);
        }

        double last_number, next_number;
        string prefix, than_number;
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from no_series where table_for='fabric_than'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    last_number = System.Convert.ToDouble(dr["last_number"].ToString());
                    prefix = dr["prefix"].ToString();
                }

                next_number = last_number + 1;
                than_number = prefix + System.Convert.ToString(next_number);
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into fabric_than_details (id_number,fabric_code,than_number,than_qty) Values ('" + textBox5.Text + "','" + dataGridView1.Rows[i].Cells["fabric_code"].Value + "','" + than_number.ToString() + "','" + dataGridView1.Rows[i].Cells["qty"].Value + "')";
                cmd.ExecuteNonQuery();
            }
            
        }
    }
}