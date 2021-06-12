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

namespace Snap.IT
{
    public partial class add_stock : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public add_stock()
        {
            InitializeComponent();
        }

        private void add_stock_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        public void fill_cat()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select Catagory from it_item_catagory", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["Catagory"].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text=="")
            {
                MessageBox.Show("Please select the category", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if(textBox1.Text=="")
            {
                MessageBox.Show("Please select the category", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                int i = 0;
                MySqlDataAdapter da = new MySqlDataAdapter("select serial_number from it_item where serial_number='" + textBox1.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                i = System.Convert.ToInt32(dt.Rows.Count.ToString());
                if(i==0)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into it_item (serial_number,catagory,brand,purchase_date,warrenty_valid,vendor,bill_number) Values ('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "','" + textBox4.Text + "','" + textBox3.Text + "')";
                    cmd.ExecuteNonQuery();

                    MySqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "update it_item_catagory set it_stock=it_stock+'1', total_stock=total_stock+'1' where Catagory='" + comboBox1.Text + "'";
                    cmd1.ExecuteNonQuery();

                    MessageBox.Show("Data Inserted Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    
                }
                else
                {
                    MessageBox.Show("Serial Number Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void fill_data()
        {
            fill_cat();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from it_item where id='" + textBox5.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                comboBox1.Text = dr["catagory"].ToString();
                textBox1.Text = dr["serial_number"].ToString();
                textBox2.Text = dr["brand"].ToString();
                textBox3.Text = dr["bill_number"].ToString();
                textBox4.Text = dr["vendor"].ToString();
                dateTimePicker1.Value = System.Convert.ToDateTime(dr["purchase_date"].ToString());
                dateTimePicker2.Value = System.Convert.ToDateTime(dr["warrenty_valid"].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Please select the category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Please select the category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int i = 0;
                MySqlDataAdapter da = new MySqlDataAdapter("select serial_number from it_item where serial_number='" + textBox1.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                i = System.Convert.ToInt32(dt.Rows.Count.ToString());
                if (i > 1)
                {
                    MessageBox.Show("Serial Number Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update it_item set serial_number='"+textBox1.Text+ "',catagory='"+comboBox1.Text+ "',brand='" + textBox2.Text + "',purchase_date='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "',warrenty_valid='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "',vendor='" + textBox4.Text + "',bill_number='" + textBox3.Text + "' where id='"+textBox5.Text+"'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Updated sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            fill_cat();
        }
    }
}
