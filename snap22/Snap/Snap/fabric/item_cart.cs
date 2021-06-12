using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Snap.fabric
{
    public partial class item_cart : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public item_cart()
        {
            InitializeComponent();
        }

        private void item_cart_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from item where ID='" + textBox9.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                textBox1.Text = dr["item_code"].ToString();
                textBox2.Text = dr["color"].ToString();
                textBox3.Text = dr["width"].ToString();
                textBox7.Text = dr["last_purchase_price"].ToString();
                textBox8.Text = dr["unit_price"].ToString();
                textBox5.Text = dr["gst"].ToString();
                textBox4.Text = dr["hsn"].ToString();
                textBox6.Text = dr["inventory"].ToString();
                textBox10.Text = dr["uom"].ToString();
                comboBox1.Text = dr["item_name"].ToString();
                comboBox2.Text = dr["item_catagory"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Enter Fabric Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(textBox8.Text=="")
            {
                MessageBox.Show("Enter Fabric Rate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Enter Fabric GST", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Enter Fabric HSN", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    cmd.CommandText = "insert into item (item_code,item_name,item_catagory,uom,gst,hsn,unit_price,last_purchase_price,inventory,color,width,item_type) Values ('"+textBox1.Text+"','"+comboBox1.Text+"','"+comboBox2.Text+"','"+textBox10.Text+"','"+textBox5.Text+"','"+textBox4.Text+"','"+textBox8.Text+"','"+textBox8.Text+"','0.00','"+textBox2.Text+"','"+textBox3.Text+"','FABRIC')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Added Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Item Code Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Fabric Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox8.Text == "")
            {
                MessageBox.Show("Enter Fabric Rate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Enter Fabric GST", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Enter Fabric HSN", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update item set item_name='" + comboBox1.Text + "',item_catagory='" + comboBox2.Text + "',uom='" + textBox10.Text + "',gst='" + textBox5.Text + "',hsn='" + textBox4.Text + "',unit_price='" + textBox8.Text + "',color='" + textBox2.Text + "',width='" + textBox3.Text + "' where ID='"+textBox9.Text+"'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item Updated Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
