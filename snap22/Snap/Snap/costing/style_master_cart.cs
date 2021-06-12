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
using System.IO;

namespace Snap.costing
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
            if (con.State == ConnectionState.Open)
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
            else if(comboBox1.Text=="")
            {
                MessageBox.Show("Select the Type of Item");
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
                    cmd.CommandText = "insert into style_master (style_code,style_colour,description,catagory,designed_year,style_type,mrp,item_type) Values ('" + textBox2.Text + "','" + textBox1.Text + "','" + richTextBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','APP','" + textBox6.Text + "','"+comboBox1.Text+"')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Inserted Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Style Code and Color Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image files | *.jpg";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox3.Text = openFileDialog1.FileName;
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }
    }
}
