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
    public partial class update_order_status : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public update_order_status()
        {
            InitializeComponent();
        }

        private void update_order_status_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_order_entry where id='" + textBox3.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                textBox1.Text=dr["order_number"].ToString();
                textBox2.Text = dr["status"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text==comboBox1.Text)
            {
                MessageBox.Show("The Status are same", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(comboBox1.Text=="")
                {
                    MessageBox.Show("Update Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update cmc_order_entry set status='" + comboBox1.Text + "' where id='"+textBox3.Text+"'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Status Updated Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
    }
}
