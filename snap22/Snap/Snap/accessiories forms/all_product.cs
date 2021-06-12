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

namespace Snap.accessiories_forms
{
    public partial class all_product : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public all_product()
        {
            InitializeComponent();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                dataGridView1.Rows.Clear();
                fill_data();
            }
            else
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from acc_product where product_code like '%"+textBox1.Text+"%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["product_code"].Value = dr["product_code"].ToString();
                    dataGridView1.Rows[i].Cells["style_code"].Value = dr["style_code"].ToString();
                    dataGridView1.Rows[i].Cells["product"].Value = dr["product"].ToString();
                    dataGridView1.Rows[i].Cells["size"].Value = dr["size"].ToString();
                    dataGridView1.Rows[i].Cells["type"].Value = dr["type"].ToString();
                    dataGridView1.Rows[i].Cells["store"].Value = dr["store"].ToString();
                    dataGridView1.Rows[i].Cells["color"].Value = dr["color"].ToString();
                    dataGridView1.Rows[i].Cells["client"].Value = dr["client"].ToString();
                    dataGridView1.Rows[i].Cells["client"].Value = dr["client"].ToString();
                    dataGridView1.Rows[i].Cells["upload_date"].Value = dr["date"].ToString();
                }
            }
        }

        private void all_product_Load(object sender, EventArgs e)
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
            MySqlDataAdapter da = new MySqlDataAdapter("select * from acc_product", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells["product_code"].Value = dr["product_code"].ToString();
                dataGridView1.Rows[i].Cells["style_code"].Value = dr["style_code"].ToString();
                dataGridView1.Rows[i].Cells["product"].Value = dr["product"].ToString();
                dataGridView1.Rows[i].Cells["size"].Value = dr["size"].ToString();
                dataGridView1.Rows[i].Cells["type"].Value = dr["type"].ToString();
                dataGridView1.Rows[i].Cells["store"].Value = dr["store"].ToString();
                dataGridView1.Rows[i].Cells["color"].Value = dr["color"].ToString();
                dataGridView1.Rows[i].Cells["client"].Value = dr["client"].ToString();
                dataGridView1.Rows[i].Cells["client"].Value = dr["client"].ToString();
                dataGridView1.Rows[i].Cells["upload_date"].Value = dr["date"].ToString();
            }
        }

        int id_value=0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id_value = System.Convert.ToInt32(row.Cells["id"].Value.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(id_value==0)
            {
                MessageBox.Show("Please Select the cell to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Are You Sure want to delete this", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result==DialogResult.Yes)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete from acc_product where id='" + id_value.ToString() + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product deleted sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    id_value = 0;
                }
                else
                {

                }
            }
        }
        
    }
}
