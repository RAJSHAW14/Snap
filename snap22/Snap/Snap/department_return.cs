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
    public partial class non_fabric_department_return : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public non_fabric_department_return()
        {
            InitializeComponent();
        }

        private void non_fabric_department_return_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }            
            con.Open();
            auto_complete_item_code();
            auto_complete_batchcode();
        }

        public void auto_complete_item_code()
        {
            MySqlCommand cmd = new MySqlCommand("select item_code from item where item_type='NON-FABRIC'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection autocomplete = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                autocomplete.Add(dr.GetString(0));

            }
            textBox4.AutoCompleteCustomSource = autocomplete;
            dr.Close();
        }

        public void auto_complete_batchcode()
        {
            MySqlCommand cmd = new MySqlCommand("select batchcode from batch_code_master", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection autocomplete = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                autocomplete.Add(dr.GetString(0));

            }
            textBox1.AutoCompleteCustomSource = autocomplete;
            dr.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Please Enter Text to retrive", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int i = 0;
                MySqlDataAdapter da = new MySqlDataAdapter("select * from batch_code_master where batchcode='" + textBox1.Text + "'",con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                i = System.Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    MessageBox.Show("There is no details against this batchcode");
                }
                else
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        textBox2.Text = dr["department"].ToString();
                        textBox3.Text = dr["designer"].ToString();
                    }
                }

            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Please Enter Text to retrive", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int i = 0;
                MySqlDataAdapter da = new MySqlDataAdapter("select * from item where item_code='" + textBox4.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                i = System.Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    MessageBox.Show("Incorrect NON-fabric code","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        textBox5.Text = dr["item_name"].ToString();
                        textBox6.Text = dr["item_catagory"].ToString();
                        textBox7.Text = dr["last_purchase_price"].ToString();
                        textBox9.Text = dr["uom"].ToString();
                    }
                }

            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            double rate;
            if(textBox7.Text=="")
            {
                rate = 0;
            }
            else
            {
                rate = System.Convert.ToDouble(textBox7.Text);
            }
            try
            {
                textBox10.Text = System.Convert.ToString(rate * System.Convert.ToDouble(textBox8.Text));
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox4.Text=="")
            {
                MessageBox.Show("PLease enter Non-fabric Item code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into non_fabric_d_return (batchcode,department,designer,remarks,return_from,non_fabric_code,categories,sub_categories,uom,rate,qty,amount,date,p_code) Values ('" + textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+richTextBox1.Text+"','"+comboBox1.Text+"','"+textBox4.Text+"','"+textBox5.Text+"','"+textBox6.Text+"','"+textBox9.Text+"','"+textBox7.Text+ "','" + textBox8.Text + "','" + textBox10.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','"+richTextBox2.Text+"')";
                cmd.ExecuteNonQuery();

                MySqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update item set inventory=inventory+'"+textBox8.Text+ "' where item_code='"+textBox4.Text+"'";
                cmd1.ExecuteNonQuery();

                MessageBox.Show("Item Inserted Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        public void fill_Data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from non_fabric_d_return where id='"+textBox11.Text+"'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                dateTimePicker1.Value = System.Convert.ToDateTime(dr["date"].ToString());
                textBox1.Text = dr["batchcode"].ToString();
                textBox2.Text = dr["department"].ToString();
                textBox3.Text = dr["designer"].ToString();
                richTextBox1.Text = dr["remarks"].ToString();
                comboBox1.Text = dr["return_from"].ToString();
                textBox4.Text = dr["non_fabric_code"].ToString();
                textBox12.Text = dr["non_fabric_code"].ToString();
                textBox5.Text = dr["categories"].ToString();
                textBox6.Text = dr["sub_categories"].ToString();
                textBox9.Text = dr["uom"].ToString();
                textBox7.Text = dr["rate"].ToString();
                textBox8.Text = dr["qty"].ToString();
                textBox13.Text = dr["qty"].ToString();
                textBox10.Text = dr["amount"].ToString();
                richTextBox2.Text = dr["p_code"].ToString();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Please enter Non-fabric Item code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update non_fabric_d_return set batchcode='"+textBox1.Text+ "',department='" + textBox2.Text + "',designer='" + textBox3.Text + "',remarks='" + richTextBox1.Text + "',return_from='" + comboBox1.Text + "',non_fabric_code='" + textBox4.Text + "',categories='" + textBox5.Text + "',sub_categories='" + textBox6.Text + "',uom='" + textBox9.Text + "',rate='" + textBox7.Text + "',qty='" + textBox8.Text + "',amount='" + textBox10.Text + "',date='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "',p_code='"+richTextBox2.Text+"' where id='"+textBox11.Text+"'";
                cmd.ExecuteNonQuery();

                MySqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update item set inventory=inventory-'"+textBox13.Text+ "' where item_code='"+textBox12.Text+"'";
                cmd1.ExecuteNonQuery();

                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "update item set inventory=inventory+'" + textBox8.Text + "' where item_code='" + textBox4.Text + "'";
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Data Updated Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }

        public void fill_Data_delete()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from non_fabric_d_return where id='" + textBox11.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {                
                textBox12.Text = dr["non_fabric_code"].ToString();                
                textBox13.Text = dr["qty"].ToString();                
            }

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from non_fabric_d_return where id='"+textBox11.Text+"'";
            cmd.ExecuteNonQuery();

            MySqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "update item set inventory = inventory-'"+textBox13.Text+ "' where item_code='"+textBox12.Text+"'";
            cmd1.ExecuteNonQuery();

            this.Close();
        }
    }
}