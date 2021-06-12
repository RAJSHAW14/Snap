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
    public partial class than_generation_cart : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public than_generation_cart()
        {
            InitializeComponent();
        }

        private void than_generation_cart_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        int than_last_number, than_next_number,erp_last_than_number,erp_next_than_number;
        string prefix;
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox5.Text=="")
            {
                MessageBox.Show("Please Enter the Number of Than", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from no_series where table_for='fabric_than'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    than_last_number = System.Convert.ToInt32(dr["last_number"].ToString()) + 1;
                    prefix = dr["prefix"].ToString();
                }
                erp_last_than_number = System.Convert.ToInt32(textBox7.Text);
                erp_next_than_number = erp_last_than_number + 1;
                than_next_number = than_last_number + System.Convert.ToInt32(textBox5.Text);
                for (int i = than_last_number; i < than_next_number; i++)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells["than_number"].Value = prefix + i.ToString();
                    dataGridView1.Rows[n].Cells["erp_than_number"].Value = prefix + erp_next_than_number.ToString();
                    erp_next_than_number++;
                }
                pending_qty_cal();
            }
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_than where id='" + textBox6.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                textBox1.Text = dr["grn_number"].ToString();
                textBox3.Text = dr["item_code"].ToString();
                textBox4.Text = dr["qty"].ToString();
                textBox2.Text = dr["qty"].ToString();
            }
            
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            pending_qty_cal();
        }

        public void pending_qty_cal()
        {
            try
            {
                double sum_of_amt = 0, total_amount;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    sum_of_amt += System.Convert.ToDouble(dataGridView1.Rows[i].Cells["qty"].Value);
                }
                total_amount = Math.Round(sum_of_amt, 2);
                textBox4.Text = System.Convert.ToString(System.Convert.ToDouble(textBox2.Text) - total_amount);
            }
            catch
            {

            }
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            pending_qty_cal();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            pending_qty_cal();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox4.Text=="0")
            {
                for(int i=0;i<dataGridView1.Rows.Count;i++)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into fabric_than_details (grn_line_number,fabric_code,than_number,than_qty,grn_number,pending_than_qty,status,erp_than_number) Values ('" + textBox6.Text + "','" + textBox3.Text + "','" + dataGridView1.Rows[i].Cells["than_number"].Value + "','" + dataGridView1.Rows[i].Cells["qty"].Value + "','" + textBox1.Text + "','" + dataGridView1.Rows[i].Cells["qty"].Value + "','RECEIVE','" + dataGridView1.Rows[i].Cells["erp_than_number"].Value + "')  ";
                    cmd.ExecuteNonQuery();
                }

                MySqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update fabric_grn_line set than_status='DONE' WHERE id='" + textBox6.Text + "'";
                cmd1.ExecuteNonQuery();

                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "update fabric_grn_header set edit_status='NO' where grn_number='" + textBox1.Text + "'";
                cmd2.ExecuteNonQuery();

                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "update no_series set last_number='" + than_next_number.ToString() + "' where table_for='fabric_than'";
                cmd3.ExecuteNonQuery();

                MessageBox.Show("Than Enter Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {

            }

        }
    }
}
