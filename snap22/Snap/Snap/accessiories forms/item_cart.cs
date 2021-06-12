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
    public partial class item_cart : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public item_cart()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Please Enter the Item Code");
                textBox1.Focus();
            }
            else
            {
                int i = 0;
                MySqlDataAdapter da = new MySqlDataAdapter("select * from item where item_code='" + textBox1.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                i = System.Convert.ToInt32(dt.Rows.Count.ToString());
                if(i==0)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into item (item_code,item_name,item_catagory,uom,gst,hsn,unit_price,color,item_type,inventory,last_purchase_price) Values ('" + textBox1.Text + "','" + comboBox5.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "','" + textBox3.Text + "','" + textBox2.Text + "','ACC','0.00','"+textBox3.Text+"')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Inserted Sucessfully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Item Code Already Taken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void item_cart_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update item set item_name='" + comboBox5.Text + "',item_catagory='" + comboBox1.Text + "',uom='" + comboBox2.Text + "',gst='" + comboBox3.Text + "',hsn='" + comboBox4.Text + "',unit_price='" + textBox3.Text + "',color='" + textBox2.Text + "',last_purchase_price='"+textBox3.Text+"' where item_code='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Updated Sucessfully");
            this.Close();
        }
    }
}
