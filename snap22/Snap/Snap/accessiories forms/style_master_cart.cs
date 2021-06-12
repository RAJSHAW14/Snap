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
    public partial class style_master_cart : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public style_master_cart()
        {
            InitializeComponent();
        }

        private void style_master_cart_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox2.Text=="")
            {
                MessageBox.Show("Please Type Style Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(textBox1.Text=="")
            {
                MessageBox.Show("Please Type Style Color", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int i = 0;
                MySqlDataAdapter da = new MySqlDataAdapter("select * from style_master where style_code='" + textBox2.Text + "' and style_colour='" + textBox1.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                i = System.Convert.ToInt32(dt.Rows.Count.ToString());
                if(i==0)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into style_master(style_code,style_colour,description,catagory,mrp,style_type) Values ('" + textBox2.Text + "','" + textBox1.Text + "','" + richTextBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','ACC')";
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Style Inserted Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The Style Code and Color is Already Inserted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from style_master where id='" + textBox3.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                textBox2.Text = dr["style_code"].ToString();
                textBox1.Text = dr["style_colour"].ToString();
                textBox4.Text = dr["catagory"].ToString();
                textBox5.Text = dr["mrp"].ToString();
                richTextBox1.Text = dr["description"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please Type Style Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Please Type Style Color", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update style_master set style_code='" + textBox2.Text + "',style_colour='" + textBox1.Text + "',catagory='" + textBox4.Text + "',mrp='" + textBox5.Text + "',description='" + richTextBox1.Text + "' where id='" + textBox3.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Style Code Updated Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
