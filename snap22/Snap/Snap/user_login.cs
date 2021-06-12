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
    public partial class user_login : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public user_login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            string user_permission, name;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from users where user_id='" + textBox1.Text + "' and user_password='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            i = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if(i==0)
            {
                MessageBox.Show("User Id and Password Incorect", "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            foreach(DataRow dr in dt.Rows)
            {
                parent parent1 = new parent();
                user_permission = dr["user_permission"].ToString();
                name = dr["name"].ToString();
                if(user_permission=="EMB")
                {
                    parent1.emb_tracker.Visible = true;
                    parent1.Welcome.Text = "Welcome " + name;
                    parent1.Show();
                    this.Hide();
                }
                if (user_permission == "DPR")
                {
                    parent1.dpr.Visible = true;
                    parent1.Welcome.Text = "Welcome " + name;
                    parent1.Show();
                    this.Hide();
                }
                if (user_permission == "IT")
                {
                    parent1.it.Visible = true;
                    parent1.Welcome.Text = "Welcome " + name;
                    parent1.Show();
                    this.Hide();
                }
                if (user_permission == "ADMIN")
                {
                    parent1.emb_tracker.Visible = true;
                    parent1.it.Visible = true;
                    parent1.dpr.Visible = true;
                    parent1.fabric.Visible = true;
                    parent1.non_fabirc.Visible = true;
                    parent1.ISSUE_NON_FABIRC.Visible = true;
                    parent1.production.Visible = true;
                    parent1.accessiories.Visible = true;
                    parent1.final_qc.Visible = true;
                    parent1.cmc.Visible = true;
                    parent1.s_fabric.Visible = true;
                    parent1.Welcome.Text = "Welcome " + name;
                    parent1.Show();
                    this.Hide();
                }
                if (user_permission == "FABRIC")
                {
                    parent1.fabric.Visible = true;
                    parent1.Welcome.Text = "Welcome " + name;
                    parent1.Show();
                    this.Hide();
                }
                if (user_permission == "NON-FABIRC")
                {
                    parent1.non_fabirc.Visible = true;
                    parent1.Welcome.Text = "Welcome " + name;
                    parent1.Show();
                    this.Hide();
                }
                if (user_permission == "REQUEST")
                {
                    parent1.ISSUE_NON_FABIRC.Visible = true;
                    parent1.Welcome.Text = "Welcome " + name;
                    parent1.Show();
                    this.Hide();
                }
                if (user_permission == "KURTA")
                {
                    parent1.production.Visible = true;
                    parent1.Welcome.Text = "Welcome " + name;
                    parent1.Show();
                    this.Hide();
                }
                if (user_permission == "ACC")
                {
                    parent1.accessiories.Visible = true;
                    parent1.Welcome.Text = "Welcome " + name;
                    parent1.Show();
                    this.Hide();
                }
                if (user_permission == "FINAL_QC")
                {
                    parent1.final_qc.Visible= true;
                    parent1.Welcome.Text = "Welcome " + name;
                    parent1.Show();
                    this.Hide();
                }
                if(user_permission=="CMC")
                {
                    parent1.cmc.Visible = true;
                    parent1.Welcome.Text = "Welcome " + name;
                    parent1.Show();
                    this.Hide();
                }

            }
        }

        private void user_login_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }
    }
}