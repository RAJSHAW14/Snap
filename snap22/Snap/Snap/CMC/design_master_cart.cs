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
    public partial class design_master_cart : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public design_master_cart()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void design_master_cart_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Enter Design Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (richTextBox1.Text == "")
            {
                MessageBox.Show("Please Enter Design Description", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int i = 0;
                MySqlDataAdapter da = new MySqlDataAdapter("select design_code from cmc_design where design_code='" + textBox1.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                i = System.Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into cmc_design (design_code,design_type,machine_type,design_description,stitiches,color,appx_mc_time,uom,emb_code,digital,remarks) Values ('" + textBox1.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + richTextBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + richTextBox2.Text + "')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Saved Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("CMC Code is Already Inserted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Please Enter Design Description", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update cmc_design set design_type='" + comboBox1.Text + "',machine_type='" + comboBox2.Text + "',design_description='" + richTextBox1.Text + "',stitiches='" + textBox2.Text + "',color='" + textBox3.Text + "',appx_mc_time='" + textBox4.Text + "',uom='" + textBox5.Text + "',emb_code='" + textBox6.Text + "',digital='" + textBox7.Text + "',remarks='" + richTextBox2.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_design where id='" + textBox9.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox1.Text = dr["design_code"].ToString();
                comboBox1.Text = dr["design_type"].ToString();
                comboBox2.Text = dr["machine_type"].ToString();
                richTextBox1.Text = dr["design_description"].ToString();
                textBox2.Text = dr["stitiches"].ToString();
                textBox3.Text = dr["color"].ToString();
                textBox4.Text = dr["appx_mc_time"].ToString();
                textBox5.Text = dr["uom"].ToString();
                textBox6.Text = dr["emb_code"].ToString();
                textBox7.Text = dr["digital"].ToString();
                richTextBox2.Text = dr["remarks"].ToString();
            }
        }
    }
}
