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

namespace Snap.costing
{
    public partial class emb_master_cart : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public emb_master_cart()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text=="")
            {
                MessageBox.Show("Enter EMB Name");
            }
            else if(comboBox1.Text=="")
            {
                MessageBox.Show("Enter UoM");
            }
            else if(comboBox2.Text=="")
            {
                MessageBox.Show("Enter EMB Type");
            }
            else
            {
                int i = 0;
                MySqlDataAdapter da = new MySqlDataAdapter("select emb_name from emb_master where emb_name='" + richTextBox1.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                i = System.Convert.ToInt32(dt.Rows.Count.ToString());
                if(i==0)
                {
                    MySqlCommand cmd=con.CreateCommand();
                    cmd.CommandType=CommandType.Text;
                    cmd.CommandText = "insert into emb_master (emb_code,emb_name,uom,na_rate,fixed_rate,emb_type,costing_rate) Values ('" + textBox1.Text + "','" + richTextBox1.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox2.Text + "','"+textBox4.Text+"')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Inserted Sucessfully");
                    clear();
                }
                else
                {
                    MessageBox.Show("EMB Name Already Inserted");
                }
            }
        }

        private void emb_master_cart_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_combobox_uom();
            fill_combobox_type();
            fill_data();
        }

        public void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            richTextBox1.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from emb_master where id='"+textBox5.Text+"'",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                textBox1.Text = dr["emb_code"].ToString();
                textBox2.Text = dr["na_rate"].ToString();
                textBox3.Text = dr["fixed_rate"].ToString();
                textBox4.Text = dr["costing_rate"].ToString();
                comboBox1.Text = dr["uom"].ToString();
                richTextBox1.Text = dr["emb_name"].ToString();
                comboBox2.Text = dr["emb_type"].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Enter EMB Name");
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Enter UoM");
            }
            else if (comboBox2.Text == "")
            {
                MessageBox.Show("Enter EMB Type");
            }
            else
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update emb_master set emb_code='" + textBox1.Text + "',emb_name='" + richTextBox1.Text + "',uom='" + comboBox1.Text + "',na_rate='" + textBox2.Text + "',fixed_rate='" + textBox3.Text + "',emb_type='" + comboBox2.Text + "',costing_rate='"+textBox4.Text+"' where id='" + textBox5.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated Sucessfully");
                clear();
                this.Close();
            }
        }

        public void fill_combobox_uom()
        {
            comboBox1.Items.Clear();
            MySqlDataAdapter da = new MySqlDataAdapter("select DISTINCT uom from emb_drop_down", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["uom"].ToString());
            }
        }

        public void fill_combobox_type()
        {
            comboBox2.Items.Clear();
            MySqlDataAdapter da = new MySqlDataAdapter("select DISTINCT type from emb_drop_down", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox2.Items.Add(dr["type"].ToString());
            }
        }
    }
}
