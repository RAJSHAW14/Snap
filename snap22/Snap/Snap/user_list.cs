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
    public partial class user_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public user_list()
        {
            InitializeComponent();
        }

        private void user_list_Load(object sender, EventArgs e)
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
            MySqlDataAdapter da = new MySqlDataAdapter("select * from users", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells["user_id"].Value = dr["user_id"].ToString();
                dataGridView1.Rows[i].Cells["password"].Value = dr["user_password"].ToString();
                dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                dataGridView1.Rows[i].Cells["user_permission"].Value = dr["user_permission"].ToString();
                dataGridView1.Rows[i].Cells["Name"].Value = dr["name"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user_cart cart = new user_cart();
            cart.MdiParent = this;
            cart.button2.Enabled = false;
            cart.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            fill_data();
        }
    }
}
