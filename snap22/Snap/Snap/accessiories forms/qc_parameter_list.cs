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
    public partial class qc_parameter_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public qc_parameter_list()
        {
            InitializeComponent();
        }

        string item_name_c = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                item_name_c = row.Cells["item_name"].Value.ToString();
            }
        }

        private void qc_parameter_list_Load(object sender, EventArgs e)
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
            MySqlDataAdapter da = new MySqlDataAdapter("select DISTINCT(item_name) from acc_qc_master", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["item_name"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            qc_parameter parameter = new qc_parameter();
            parameter.button2.Enabled = false;
            parameter.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(item_name_c=="")
            {
                MessageBox.Show("Select the cell");
            }
            else
            {
                qc_parameter para = new qc_parameter();
                para.textBox1.Text = item_name_c;
                para.textBox1.ReadOnly = true;
                para.button1.Enabled = false;
                para.fill_data();
                item_name_c = "";
                para.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (item_name_c == "")
            {
                MessageBox.Show("Select the cell");
            }
            else
            {
                DialogResult result = MessageBox.Show("Are You sure want to delete " + item_name_c, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result==DialogResult.Yes)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete from acc_qc_master where item_name='" + item_name_c + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Deleted Sucessfully");
                    item_name_c = "";
                    reload();
                }
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
    }
}
