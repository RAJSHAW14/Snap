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
    public partial class style_master_cart : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public style_master_cart()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
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
            if (textBox2.Text == "")
            {
                MessageBox.Show("Enter Style Code");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Style Colour");
            }
            else if (richTextBox1.Text == "")
            {
                MessageBox.Show("Enter Description");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Enter Catagory");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Enter Designed Year");
            }
            else
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into style_master (style_code,style_colour,description,catagory,fabric_status,emb_status,mat_status,designed_year) Values ('" + textBox2.Text + "','" + textBox1.Text + "','" + richTextBox1.Text + "','" + textBox4.Text + "','PENDING','PENDING','PENDING','" + textBox5.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted");
                this.Close();
                
            }
        }
    }
}
