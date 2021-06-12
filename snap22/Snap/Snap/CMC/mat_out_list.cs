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
    public partial class mat_out_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public mat_out_list()
        {
            InitializeComponent();
        }

        private void mat_out_list_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_data();
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_mat_stock_transaction where entry_type='OUT'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells["date"].Value = System.Convert.ToDateTime(dr["date"].ToString());
                dataGridView1.Rows[i].Cells["mat_code"].Value = dr["mat_code"].ToString();
                dataGridView1.Rows[i].Cells["uom"].Value = dr["uom"].ToString();
                dataGridView1.Rows[i].Cells["qty"].Value = dr["stock"].ToString();
                dataGridView1.Rows[i].Cells["for_order"].Value = dr["for_order_number"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string start_date, end_date;
            start_date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            end_date = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_mat_stock_transaction where entry_type='OUT' and date between '" + start_date.ToString() + "' and '" + end_date.ToString() + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells["date"].Value = System.Convert.ToDateTime(dr["date"].ToString());
                dataGridView1.Rows[i].Cells["mat_code"].Value = dr["mat_code"].ToString();
                dataGridView1.Rows[i].Cells["uom"].Value = dr["uom"].ToString();
                dataGridView1.Rows[i].Cells["qty"].Value = dr["stock"].ToString();
                dataGridView1.Rows[i].Cells["for_order"].Value = dr["for_order_number"].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            fill_data();
        }

        string id_value = "",mat_code_chcek="",stock_in="";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {                
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id_value = row.Cells["id"].Value.ToString();
                mat_code_chcek = row.Cells["mat_code"].Value.ToString();
                stock_in = row.Cells["qty"].Value.ToString();
            }  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(id_value=="")
            {
                MessageBox.Show("Please select the cell to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from cmc_mat_stock_transaction where id='"+id_value.ToString()+"'";
                cmd.ExecuteNonQuery();

                MySqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update cmc_mat set stock=stock+'" + stock_in.ToString() + "' where mat_code='" + mat_code_chcek.ToString() + "'";
                cmd1.ExecuteNonQuery();

                MessageBox.Show("Item deleted Sucessfully", "Sucess", MessageBoxButtons.OK);
            }

        }
    }
}
