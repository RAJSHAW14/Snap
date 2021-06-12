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
    public partial class non_fabric_item_cart : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public non_fabric_item_cart()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {   
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update item set item_code='" + textBox1.Text + "',item_name='" + textBox2.Text + "',item_catagory='" + comboBox1.Text + "',uom='" + comboBox2.Text + "',gst='" + comboBox3.Text + "',hsn='" + comboBox4.Text + "',unit_price='" + textBox3.Text + "',type_of_item='"+comboBox5.Text+"' where ID='" + item_id.ToString() + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Item Updated");
            item_list_new list = new item_list_new();                       
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from item where item_code = '"+textBox1.Text+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i =System.Convert.ToInt32(dt.Rows.Count.ToString());
            if(i==0)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Enter Item Code");
                    textBox1.Focus();
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Enter Item Description");
                    textBox2.Focus();
                }
                else if (comboBox1.Text == "")
                {
                    MessageBox.Show("Select Catagory");
                    comboBox1.Focus();
                }
                else if (comboBox2.Text == "")
                {
                    MessageBox.Show("Enter UOM");
                    comboBox2.Focus();
                }
                else if (textBox3.Text == "" && textBox3.Text == "0")
                {
                    MessageBox.Show("Unit Price cannot be 0 or empty");
                    textBox3.Focus();
                }
                else if (comboBox3.Text == "")
                {
                    MessageBox.Show("Select GST Percentage");
                    comboBox3.Focus();
                }
                else if (comboBox4.Text == "")
                {
                    MessageBox.Show("Select HSN Code");
                    comboBox4.Focus();
                }

                else
                {
                    MySqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "insert into item (item_code,item_name,item_catagory,uom,gst,hsn,unit_price,item_type,inventory,type_of_item) Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "','" + textBox3.Text + "','NON-FABRIC','0.00','"+comboBox5.Text+"')";
                    cmd1.ExecuteNonQuery();

                    MessageBox.Show("Item Added Sucessfully");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    comboBox3.Text = "";
                    comboBox4.Text = "";
                    this.Close();
                }
                
            }
            else
            {
                MessageBox.Show("Item Code Already taken");
            } 
        }

        public string item_id;

        private void item_cart_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();            
            }
            con.Open();

        }
    }
}
