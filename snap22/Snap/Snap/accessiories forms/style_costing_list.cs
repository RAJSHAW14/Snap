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
    public partial class style_costing_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public style_costing_list()
        {
            InitializeComponent();
        }

        private void style_costing_list_Load(object sender, EventArgs e)
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
            MySqlDataAdapter da = new MySqlDataAdapter("select * from acc_style_cositng", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["ID"].Value = dr["style_id"].ToString();
                dataGridView1.Rows[i].Cells["style_code"].Value = dr["style_code"].ToString();
                dataGridView1.Rows[i].Cells["style_color"].Value = dr["style_colour"].ToString();
                dataGridView1.Rows[i].Cells["description"].Value = dr["description"].ToString();
                dataGridView1.Rows[i].Cells["mrp"].Value = dr["mrp"].ToString();
                dataGridView1.Rows[i].Cells["hardware"].Value = dr["hardware"].ToString();
                dataGridView1.Rows[i].Cells["hand_emb"].Value = dr["hand_emb"].ToString();
                dataGridView1.Rows[i].Cells["machine_emb"].Value = dr["machine_emb"].ToString();
                dataGridView1.Rows[i].Cells["fabrication"].Value = dr["fabrication"].ToString();
                dataGridView1.Rows[i].Cells["digital_print"].Value = dr["digital_print"].ToString();
                dataGridView1.Rows[i].Cells["lining_quilting"].Value = dr["lining_quilting"].ToString();
                dataGridView1.Rows[i].Cells["leather"].Value = dr["leather"].ToString();
                dataGridView1.Rows[i].Cells["fabric"].Value = dr["fabric"].ToString();
                dataGridView1.Rows[i].Cells["dye"].Value = dr["dye"].ToString();
                dataGridView1.Rows[i].Cells["emb_mat"].Value = dr["emb_mat"].ToString();
                dataGridView1.Rows[i].Cells["other"].Value = dr["others"].ToString();
                dataGridView1.Rows[i].Cells["hardware_polish"].Value = dr["hardware_polish"].ToString();
                dataGridView1.Rows[i].Cells["packing"].Value = dr["packing"].ToString();
                dataGridView1.Rows[i].Cells["overhead"].Value = dr["overhead"].ToString();
                dataGridView1.Rows[i].Cells["total"].Value = dr["grand_total"].ToString();
                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            fill_data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(id_value==0)
            {
                MessageBox.Show("Please Style to Updated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                costing cost = new costing();
                cost.button1.Visible = false;
                cost.textBox24.Text = id_value.ToString();
                cost.fill_style_details();
                cost.fill_data();
                cost.Show();
            }
        }

        int id_value = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id_value = System.Convert.ToInt32(row.Cells["ID"].Value.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(id_value==0)
            {
                MessageBox.Show("Please select the style to delete ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Are You Sure want to Delete this Style Costing", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result==DialogResult.Yes)
                {
                    MySqlCommand cmd6 = con.CreateCommand();
                    cmd6.CommandType = CommandType.Text;
                    cmd6.CommandText = "delete from acc_style_summery where style_id='" + id_value.ToString() + "'";
                    cmd6.ExecuteNonQuery();

                    MySqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "delete from acc_style_leather_details where style_id='" + id_value.ToString() + "'";
                    cmd1.ExecuteNonQuery();

                    MySqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "delete from acc_style_hardware_details where style_id='" + id_value.ToString() + "'";
                    cmd2.ExecuteNonQuery();

                    MySqlCommand cmd3 = con.CreateCommand();
                    cmd3.CommandType = CommandType.Text;
                    cmd3.CommandText = "delete from acc_style_fabric_details where style_id='" + id_value.ToString() + "'";
                    cmd3.ExecuteNonQuery();

                    MySqlCommand cmd4 = con.CreateCommand();
                    cmd4.CommandType = CommandType.Text;
                    cmd4.CommandText = "delete from acc_style_emb_mat_details where style_id='" + id_value.ToString() + "'";
                    cmd4.ExecuteNonQuery();

                    MySqlCommand cmd5 = con.CreateCommand();
                    cmd5.CommandType = CommandType.Text;
                    cmd5.CommandText = "update style_master set consumption_status='PENDING' WHERE id='" + id_value.ToString() + "'";
                    cmd5.ExecuteNonQuery();

                    MessageBox.Show("Style Deleted Sucessfully", "Scuess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.Clear();
                    fill_data();
                }
            }
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
                MySqlDataAdapter da = new MySqlDataAdapter("select * from acc_style_cositng where style_code like '%"+textBox1.Text+"%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["ID"].Value = dr["style_id"].ToString();
                    dataGridView1.Rows[i].Cells["style_code"].Value = dr["style_code"].ToString();
                    dataGridView1.Rows[i].Cells["style_color"].Value = dr["style_colour"].ToString();
                    dataGridView1.Rows[i].Cells["description"].Value = dr["description"].ToString();
                    dataGridView1.Rows[i].Cells["mrp"].Value = dr["mrp"].ToString();
                    dataGridView1.Rows[i].Cells["hardware"].Value = dr["hardware"].ToString();
                    dataGridView1.Rows[i].Cells["hand_emb"].Value = dr["hand_emb"].ToString();
                    dataGridView1.Rows[i].Cells["machine_emb"].Value = dr["machine_emb"].ToString();
                    dataGridView1.Rows[i].Cells["fabrication"].Value = dr["fabrication"].ToString();
                    dataGridView1.Rows[i].Cells["digital_print"].Value = dr["digital_print"].ToString();
                    dataGridView1.Rows[i].Cells["lining_quilting"].Value = dr["lining_quilting"].ToString();
                    dataGridView1.Rows[i].Cells["leather"].Value = dr["leather"].ToString();
                    dataGridView1.Rows[i].Cells["fabric"].Value = dr["fabric"].ToString();
                    dataGridView1.Rows[i].Cells["dye"].Value = dr["dye"].ToString();
                    dataGridView1.Rows[i].Cells["emb_mat"].Value = dr["emb_mat"].ToString();
                    dataGridView1.Rows[i].Cells["other"].Value = dr["others"].ToString();
                    dataGridView1.Rows[i].Cells["hardware_polish"].Value = dr["hardware_polish"].ToString();
                    dataGridView1.Rows[i].Cells["packing"].Value = dr["packing"].ToString();
                    dataGridView1.Rows[i].Cells["overhead"].Value = dr["overhead"].ToString();
                    dataGridView1.Rows[i].Cells["total"].Value = dr["grand_total"].ToString();

                }
            }
        }
    }
}
