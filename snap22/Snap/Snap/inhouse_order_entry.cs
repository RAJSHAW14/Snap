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
    public partial class inhouse_order_entry : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public inhouse_order_entry()
        {
            InitializeComponent();
        }

        private void inhouse_order_entry_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_combobox();
            auto_complete_batchcode();
        }

        public void fill_combobox()
        {
            comboBox1.Items.Clear();
            MySqlDataAdapter da = new MySqlDataAdapter("select unit_name from emb_unit where type='IN-HOUSE' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["unit_name"].ToString());
            }
        }

        public void auto_complete_batchcode()
        {
            MySqlCommand cmd = new MySqlCommand("select batchcode from batchcode_id_product_code where batchcode like '%" + textBox2.Text + "%'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            while(dr.Read())
            {
                mycollection.Add(dr.GetString(0));
            }
            textBox2.AutoCompleteCustomSource = mycollection;
            dr.Close();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from batchcode_id_product_code where batchcode='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            i = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if(i==0)
            {
                MessageBox.Show("Incorrect Batchcode");
            }
            else
            {
                listBox1.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    listBox1.Items.Add(dr["product_code"].ToString());
                }
            }

            
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            label10.Text = listBox1.SelectedIndices.Count.ToString();
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            int i = 0;
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from emb_master where emb_code='" + textBox5.Text + "'";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            i = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    richTextBox1.Text = dr["emb_name"].ToString();
                    textBox4.Text = dr["uom"].ToString();
                }
                richTextBox1.ReadOnly = true;
                
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Enter Order Number");
            }
            else
            {
                insert_data();
                MessageBox.Show("Order Inserted");
                this.Close();
            }
        }
        string order_id;
        public void insert_data()
        {
            
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into emb_order (order_number,fab_qty_detail,uom,emb_code,emb_name,unit,unit_type,remarks,batchcode,qty,number_of_p_code) Values ('" + textBox1.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"','"+richTextBox1.Text+"','"+
                comboBox1.Text+"','IN-HOUSE','"+richTextBox2.Text+"','"+textBox2.Text+"','"+textBox6.Text+"','"+label10.Text+"')";
            cmd.ExecuteNonQuery();

            /*MySqlDataAdapter da = new MySqlDataAdapter("select * from emb_order where order_number='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                order_id = dr["id"].ToString();
            }

            double product_qty;
            product_qty = System.Convert.ToDouble(textBox6.Text) / System.Convert.ToDouble(label10.Text);
            for (int i = 0; i < listBox1.SelectedItems.Count; i++)
            {
                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "insert into emb_order_product_code (emb_order_id,product_code,qty,uom,status) Values ('" + order_id.ToString()+"','"+listBox1.SelectedItems[i].ToString()+"','"+product_qty+"','"+textBox4.Text+"','OPEN') ";
                cmd2.ExecuteNonQuery();
            }*/

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
