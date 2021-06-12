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
    public partial class non_fabric_purchase_return_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public non_fabric_purchase_return_list()
        {
            InitializeComponent();
        }

        private void non_fabric_purchase_return_list_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_gride();
        }

        public void fill_gride()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("Select * from non_fabric_p_return_header", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr["return_number"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["return_date"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr["vendor"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dr["against_grn"].ToString();
                dataGridView1.Rows[i].Cells[5].Value = dr["against_bill_number"].ToString();
                dataGridView1.Rows[i].Cells[6].Value = dr["remarks"].ToString();
                dataGridView1.Rows[i].Cells[7].Value = dr["amount"].ToString();
            }
        }

        int return_id = 0, p_return_number = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                return_id = System.Convert.ToInt32(row.Cells["id"].Value.ToString());
                p_return_number = System.Convert.ToInt32(row.Cells["return_number"].Value.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            fill_gride();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            non_fabric_p_return_cart cart = new non_fabric_p_return_cart();
            cart.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            non_fabric_p_return_cart cart = new non_fabric_p_return_cart();
            cart.textBox6.Text = p_return_number.ToString();
            cart.datagride_fill_header();
            cart.datagride_fill_line();
            cart.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (p_return_number == 0)
            {
                MessageBox.Show("Select the GRN to Delete");
            }
            else
            {
                DialogResult result = MessageBox.Show("Do You want to delete this GRN Number " + p_return_number, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    non_fabric_p_return_cart cart = new non_fabric_p_return_cart();
                    cart.delete_grn();
                    cart.datagride_fill_line();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete from non_fabric_p_return_header where return_number='" + p_return_number + "'";
                    cmd.ExecuteNonQuery();

                    MySqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "delete from non_fabric_p_return_line where return_number='" + p_return_number + "'";
                    cmd1.ExecuteNonQuery();

                    MessageBox.Show("Return Number " + p_return_number + " Deleted Sucessfully");
                }
                else
                {

                }
            }
        }
    }
}
