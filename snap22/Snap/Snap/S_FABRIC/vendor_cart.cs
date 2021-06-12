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

namespace Snap.S_FABRIC
{
    public partial class vendor_cart : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public vendor_cart()
        {
            InitializeComponent();
        }

        private void vendor_cart_Load(object sender, EventArgs e)
        {

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from vendor where id='" + textBox9.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox1.Text = dr["vendor_name"].ToString();
                textBox2.Text = dr["address"].ToString();
                textBox3.Text = dr["address_1"].ToString();
                textBox10.Text = dr["city"].ToString();
                textBox4.Text = dr["state"].ToString();
                textBox5.Text = dr["pincode"].ToString();
                textBox6.Text = dr["pan_number"].ToString();
                textBox7.Text = dr["gst_number"].ToString();
                textBox8.Text = dr["phone_number"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Vendor Name");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Enter Address");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Enter Pin Code");
            }
            else
            {
                int i = 0;
                MySqlDataAdapter da = new MySqlDataAdapter("select * from vendor where vendor_name='" + textBox1.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                i = System.Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into vendor (vendor_name,address,address_1,city,state,pincode,pan_number,gst_number,phone_number,vendor_type) Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox10.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','S-FABRIC')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Vendor Inserted Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Vendor Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update vendor set vendor_name='" + textBox1.Text + "',address='" + textBox2.Text + "',address_1='" + textBox3.Text + "',city='" + textBox10.Text + "',state='" + textBox4.Text + "',pincode='" + textBox5.Text + "',pan_number='" + textBox6.Text + "',gst_number='" + textBox7.Text + "',phone_number='" + textBox8.Text + "'  where id='" + textBox9.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Updated Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
