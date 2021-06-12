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
    public partial class inhouse_emb_receive : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public inhouse_emb_receive()
        {
            InitializeComponent();
        }

        private void inhouse_emb_receive_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            maskedTextBox2.Text = DateTime.Now.ToString("dd/MM/yyyy");
            auto_complete_order_number();

        }

        public void auto_complete_order_number()
        {
            MySqlCommand cmd = new MySqlCommand("select order_number from emb_tracker where order_number like '%" + textBox22.Text + "%' and order_type='IN-HOUSE'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                mycollection.Add(dr.GetString(0));
            }
            textBox22.AutoCompleteCustomSource = mycollection;
            dr.Close();
        }

        public void emb_calculate()
        {
            try
            {
                if (comboBox5.Text == "2.75")
                {
                    textBox16.ReadOnly = false;
                    textBox10.ReadOnly = false;
                    textBox13.ReadOnly = false;
                    textBox17.Text = System.Convert.ToString(Math.Round(System.Convert.ToDouble(textBox13.Text) / 44 * System.Convert.ToDouble(textBox16.Text) * System.Convert.ToDouble(textBox10.Text), 2));
                    textBox2.Text = System.Convert.ToString(Math.Round(System.Convert.ToDouble(textBox3.Text) / 2.75 * System.Convert.ToDouble(textBox17.Text), 2));
                }

                else if (comboBox5.Text == "1760 SQ INCH")
                {
                    textBox10.ReadOnly = false;
                    textBox13.ReadOnly = false;
                    textBox14.ReadOnly = false;
                    textBox15.ReadOnly = false;
                    if (textBox15.Text == "")
                    {
                        textBox17.Text = System.Convert.ToString(Math.Round(System.Convert.ToDouble(textBox13.Text) * System.Convert.ToDouble(textBox14.Text) * System.Convert.ToDouble(textBox10.Text), 2));
                        textBox2.Text = System.Convert.ToString(Math.Round(System.Convert.ToDouble(textBox3.Text) / 1760 * System.Convert.ToDouble(textBox17.Text), 2));
                    }
                    else
                    {
                        double inch1, inch2, inch3;
                        inch1 = System.Convert.ToDouble(textBox13.Text);
                        inch2 = System.Convert.ToDouble(textBox14.Text);
                        inch3 = System.Convert.ToDouble(textBox15.Text);
                        if (inch1 > inch2 & inch1 > inch3)
                        {
                            MessageBox.Show("Inch-1 must be less that Inch-2 and Inch-3");
                        }
                        else if (inch2 < inch1 || inch2 > inch3)
                        {
                            MessageBox.Show("Inch-2 must be less that Inch-3 and Greater than Inch-1");
                        }
                        else if (inch3 < inch1 & inch3 < inch2)
                        {
                            MessageBox.Show("Inch-3 Must be Greater than Inch-1 and Inch-2");
                        }
                        else
                        {
                            textBox17.Text = System.Convert.ToString((((inch1 + inch2) / 2) * inch3) * System.Convert.ToDouble(textBox10.Text));
                            textBox2.Text = System.Convert.ToString(System.Convert.ToDouble(textBox3.Text) / 1760 * System.Convert.ToDouble(textBox17.Text));
                        }
                    }
                }

                else if (comboBox5.Text == "MTR")
                {
                    textBox16.ReadOnly = false;
                    textBox12.ReadOnly = false;
                    textBox13.ReadOnly = false;
                    if (textBox16.Text == "")
                    {
                        textBox17.Text = System.Convert.ToString((System.Convert.ToDouble(textBox13.Text) / 40) * System.Convert.ToDouble(textBox12.Text));
                        textBox2.Text = System.Convert.ToString(System.Convert.ToDouble(textBox3.Text) * System.Convert.ToDouble(textBox17.Text));
                    }
                    else if (textBox13.Text == "")
                    {
                        textBox17.Text = System.Convert.ToString(System.Convert.ToDouble(textBox16.Text) * System.Convert.ToDouble(textBox12.Text));
                        textBox2.Text = System.Convert.ToString(System.Convert.ToDouble(textBox3.Text) * System.Convert.ToDouble(textBox17.Text));
                    }
                    else if (textBox16.Text != "" && textBox13.Text != "")
                    {
                        MessageBox.Show("Enter either in Inch-1 or Meter");
                    }
                    else
                    {

                    }
                }

                else if (comboBox5.Text == "PCS")
                {
                    textBox10.ReadOnly = false;
                    textBox2.Text = System.Convert.ToString(System.Convert.ToDouble(textBox17.Text) * System.Convert.ToDouble(textBox3.Text));
                }

                else if (comboBox5.Text == "SET")
                {
                    textBox11.ReadOnly = false;
                    textBox2.Text = System.Convert.ToString(System.Convert.ToDouble(textBox17.Text) * System.Convert.ToDouble(textBox3.Text));
                }
            }
            catch (Exception)
            {

            }
        }

        int order_id = 0;
        public void fetch_order_details()
        {
            int i = 0;
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from emb_tracker where order_number='" + textBox22.Text + "' and order_type='IN-HOUSE'";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            i = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                MessageBox.Show("Order number not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    order_id = System.Convert.ToInt32(dr["id"].ToString());
                    textBox23.Text = dr["department"].ToString();
                    maskedTextBox1.Text = dr["date"].ToString();
                    richTextBox1.Text = dr["design_description"].ToString();
                    textBox1.Text = dr["design_code"].ToString();
                    comboBox5.Text = dr["emb_unit"].ToString();
                    textBox3.Text = dr["rate"].ToString();
                    textBox4.Text = dr["batchcode"].ToString();
                    textBox5.Text = dr["designer"].ToString();
                    comboBox2.Text = dr["rate_type"].ToString();
                    textBox6.Text = dr["v_emb_code"].ToString();
                    textBox9.Text = dr["fab_qty_detail"].ToString();
                    textBox24.Text = dr["karigar_name"].ToString();
                    textBox7.Text = dr["fabric"].ToString();
                    textBox25.Text = dr["item"].ToString();
                    textBox8.Text = dr["colour"].ToString();
                    textBox12.Text = dr["line_1"].ToString();
                    textBox16.Text = dr["meter"].ToString();
                    textBox10.Text = dr["pieces"].ToString();
                    textBox11.Text = dr["set"].ToString();
                    textBox13.Text = dr["inch_1"].ToString();
                    textBox14.Text = dr["inch_2"].ToString();
                    textBox15.Text = dr["inch_3"].ToString();
                    textBox21.Text = dr["pending_job_issue"].ToString();
                    textBox20.Text = dr["item_pending_qty"].ToString();
                    textBox19.Text = dr["amount"].ToString();
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            emb_calculate();
        }

        double total_job_receive = 0, total_item_qty = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            fetch_order_details();
            emb_calculate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                emb_calculate();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into emb_receive (`order_id`,`line`,`meter`,`pieces`,`set`,`inch_1`,`inch_2`,`inch_3`,`total_job_receive`,`Item_qty_receive`,`total_receiving_amount`,`receive_date`) Values ('" + order_id + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + textBox15.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + textBox2.Text + "','" + maskedTextBox2.Text + "')";
                cmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter("select * from emb_receive_comparision where order_id='" + order_id + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    total_job_receive = System.Convert.ToDouble(dr["total job receive"].ToString());
                    total_item_qty = System.Convert.ToDouble(dr["total qty receive"].ToString());
                }

                if (total_job_receive <= System.Convert.ToDouble(textBox17.Text))
                {
                    double item_pending_qty, pending_job_issue;
                    pending_job_issue = System.Convert.ToDouble(textBox21.Text) - System.Convert.ToDouble(textBox17.Text);
                    item_pending_qty = System.Convert.ToDouble(textBox20.Text) - System.Convert.ToDouble(textBox18.Text);
                    MySqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "UPDATE emb_tracker set item_pending_qty='" + item_pending_qty + "',pending_job_issue='" + pending_job_issue + "',status='CLOSED' where id='" + order_id + "'";
                    cmd1.ExecuteNonQuery();
                }
                else if (total_item_qty <= System.Convert.ToDouble(textBox18.Text))
                {
                    double item_pending_qty, pending_job_issue;
                    pending_job_issue = System.Convert.ToDouble(textBox21.Text) - System.Convert.ToDouble(textBox17.Text);
                    item_pending_qty = System.Convert.ToDouble(textBox20.Text) - System.Convert.ToDouble(textBox18.Text);
                    MySqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "UPDATE emb_tracker set item_pending_qty='" + item_pending_qty + "',pending_job_issue='" + pending_job_issue + "',status='CLOSED' where id='" + order_id + "'";
                    cmd1.ExecuteNonQuery();
                }
                else
                {
                    double item_pending_qty, pending_job_issue;
                    pending_job_issue = System.Convert.ToDouble(textBox21.Text) - System.Convert.ToDouble(textBox17.Text);
                    item_pending_qty = System.Convert.ToDouble(textBox20.Text) - System.Convert.ToDouble(textBox18.Text);
                    MySqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "UPDATE emb_tracker set item_pending_qty='" + item_pending_qty + "',pending_job_issue='" + pending_job_issue + "' where id='" + order_id + "'";
                    cmd1.ExecuteNonQuery();
                }

                MessageBox.Show("Item Received");
                this.Close();
            }
            catch
            { }
        }
    }
}
