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

namespace Snap.CMC
{
    public partial class order_cart : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public order_cart()
        {
            InitializeComponent();
        }

        private void order_cart_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            auto_complete_batch_code();
            auto_complete_Design_code();
        }

        string batch_id;
        private void textBox2_Leave(object sender, EventArgs e)
        {
            int i = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from batch_code_master where batchcode='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            i = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                MessageBox.Show("Batchcode not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    textBox3.Text = dr["department"].ToString();
                    textBox4.Text = dr["designer"].ToString();
                    batch_id = dr["id"].ToString();
                }
                MySqlDataAdapter da1 = new MySqlDataAdapter("select * from product_code_master where batcode_id='" + batch_id.ToString() + "'", con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                listBox1.Items.Clear();
                foreach (DataRow dr in dt1.Rows)
                {
                    listBox1.Items.Add(dr["product_code"].ToString());
                }
            }
        }

        public void auto_complete_batch_code()
        {
            MySqlCommand cmd = new MySqlCommand("select batchcode from batch_code_master", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection autocomplete = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                autocomplete.Add(dr.GetString(0));

            }
            textBox2.AutoCompleteCustomSource = autocomplete;
            dr.Close();
        }

        public void auto_complete_Design_code()
        {
            MySqlCommand cmd = new MySqlCommand("select design_code from cmc_design", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection autocomplete = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                autocomplete.Add(dr.GetString(0));

            }
            textBox5.AutoCompleteCustomSource = autocomplete;
            dr.Close();
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            int i = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_design where design_code='" + textBox5.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            i = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                MessageBox.Show("The design Code not found in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox5.Clear();
                textBox5.Focus();
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    textBox6.Text = dr["design_type"].ToString();
                    richTextBox1.Text = dr["design_description"].ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter order number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Please enter the design code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int i = 0;
                string order_date;
                MySqlDataAdapter da = new MySqlDataAdapter("select order_number from cmc_order_entry where order_number='" + textBox1.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                i = System.Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    order_date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into cmc_order_entry (order_number,batchcode,department,designer,design_code,fabric,color,component,date,status,fab_qty_details,mat) Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + order_date.ToString() + "','IN-STOCK','" + textBox11.Text + "','"+richTextBox2.Text+"')";
                    cmd.ExecuteNonQuery();

                    for (int j = 0; j < listBox1.SelectedItems.Count; j++)
                    {
                        MySqlCommand cmd2 = con.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "insert into cmc_order_p_code (p_code,order_number) Values ('" + listBox1.SelectedItems[j].ToString() + "','" + textBox1.Text + "')";
                        cmd2.ExecuteNonQuery();
                    }

                    MessageBox.Show("Order Inserted Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Order Number is already in the system", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_order_view where id='" + textBox10.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                textBox1.Text = dr["order_number"].ToString();
                dateTimePicker1.Value = System.Convert.ToDateTime(dr["date"].ToString());
                textBox2.Text = dr["batchcode"].ToString();
                textBox3.Text = dr["department"].ToString();
                textBox4.Text = dr["designer"].ToString();
                textBox5.Text = dr["design_code"].ToString();
                textBox6.Text = dr["design_type"].ToString();
                textBox7.Text = dr["fabric"].ToString();
                textBox8.Text = dr["color"].ToString();
                textBox9.Text = dr["component"].ToString();
                richTextBox1.Text = dr["design_description"].ToString();
            }

            MySqlDataAdapter da3= new MySqlDataAdapter("select * from batch_code_master where batchcode='" + textBox2.Text + "'", con);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            foreach (DataRow dr3 in dt3.Rows)
            {
                batch_id = dr3["id"].ToString();
            }
            
            MySqlDataAdapter da4 = new MySqlDataAdapter("select * from product_code_master where batcode_id='" + batch_id.ToString() + "'", con);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            listBox1.Items.Clear();
            foreach (DataRow dr4 in dt4.Rows)
            {
                listBox1.Items.Add(dr4["product_code"].ToString());
            }

            MySqlDataAdapter da1 = new MySqlDataAdapter("select * from cmc_order_p_code where order_number='"+textBox1.Text+"'",con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach(DataRow dr in dt1.Rows)
            {
                listBox2.Items.Add(dr["p_code"].ToString());
            }

            for(int i=0;i<listBox2.Items.Count;i++)
            {
                int index = listBox1.FindString(listBox2.Items[i].ToString());
                if(index != -1)
                {
                    listBox1.SetSelected(index, true);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter order number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Please enter the design code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "delete from cmc_order_entry where id='" + textBox10.Text + "'";
                cmd3.ExecuteNonQuery();

                MySqlCommand cmd4 = con.CreateCommand();
                cmd4.CommandType = CommandType.Text;
                cmd4.CommandText = "delete from cmc_order_p_code where order_number='" + textBox1.Text + "'";
                cmd4.ExecuteNonQuery();
                
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into cmc_order_entry (order_number,batchcode,department,designer,design_code,fabric,color,component,date,status,fab_qty_details,mat) Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + dateTimePicker1.Value.ToString("dd-MM-yyyy") + "','IN-STOCK','" + textBox11.Text + "','" + richTextBox2.Text + "')";
                cmd.ExecuteNonQuery();

                for (int j = 0; j < listBox1.SelectedItems.Count; j++)
                {
                    MySqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "insert into cmc_order_p_code (p_code,order_number) Values ('" + listBox1.SelectedItems[j].ToString() + "','" + textBox1.Text + "')";
                    cmd2.ExecuteNonQuery();
                }

                MessageBox.Show("Order Sucessfully Updated ", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
