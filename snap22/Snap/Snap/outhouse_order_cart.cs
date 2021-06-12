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
    public partial class outhouse_order_cart : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public outhouse_order_cart()
        {
            InitializeComponent();
        }

        private void outhouse_order_cart_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            auto_complete_batchcode();
            fill_combobox();
            fill_combobox_component();
            emb_calculation();
            maskedTextBox1.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        public void fetch_all_details()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from emb_tracker where id='" + textBox19.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                comboBox1.Text = dr["department"].ToString();
                textBox1.Text = dr["design_code"].ToString();
                maskedTextBox1.Text = dr["date"].ToString();
                richTextBox1.Text = dr["design_description"].ToString();
                textBox3.Text = dr["rate"].ToString();
                textBox4.Text = dr["batchcode"].ToString();
                comboBox5.Text = dr["emb_unit"].ToString();
                comboBox2.Text = dr["rate_type"].ToString();
                textBox6.Text = dr["v_emb_code"].ToString();
                comboBox3.Text = dr["karigar_name"].ToString();
                textBox7.Text = dr["fabric"].ToString();
                textBox5.Text = dr["designer"].ToString();
                comboBox4.Text = dr["item"].ToString();
                textBox8.Text = dr["colour"].ToString();
                textBox9.Text = dr["fab_qty_detail"].ToString();
                textBox12.Text = dr["line_1"].ToString();
                textBox16.Text = dr["meter"].ToString();
                textBox10.Text = dr["pieces"].ToString();
                textBox11.Text = dr["set"].ToString();
                textBox13.Text = dr["inch_1"].ToString();
                textBox14.Text = dr["inch_2"].ToString();
                textBox15.Text = dr["inch_3"].ToString();
                textBox17.Text = dr["total_job_issue"].ToString();
                textBox18.Text = dr["item_qty"].ToString();
                textBox2.Text = dr["amount"].ToString();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            string fixed_rate, na_rate;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from emb_master where emb_code='"+textBox1.Text+"'",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                richTextBox1.Text = dr["emb_name"].ToString();
                comboBox5.Text = dr["uom"].ToString();
                fixed_rate = dr["fixed_rate"].ToString();
                na_rate = dr["na_rate"].ToString();
                if(fixed_rate==""||fixed_rate=="0")
                {                    
                    textBox3.Text = na_rate.ToString();
                    comboBox2.Text = "N.A";
                }
                else
                {
                    textBox3.Text = fixed_rate.ToString();
                    comboBox2.Text = "FIXED";
                }
                emb_calculation();
            }
        }

        public void auto_complete_batchcode()
        {
            MySqlCommand cmd = new MySqlCommand("select batchcode from batchcode_id_product_code where batchcode like '%" + textBox4.Text + "%'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                mycollection.Add(dr.GetString(0));
            }
            textBox4.AutoCompleteCustomSource = mycollection;
            dr.Close();
        }


        public void fill_combobox()
        {
            comboBox3.Items.Clear();
            MySqlDataAdapter da = new MySqlDataAdapter("select unit_name from emb_unit where type='OUT-HOUSE' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox3.Items.Add(dr["unit_name"].ToString());
            }
        }

        public void fill_combobox_component()
        {
            comboBox4.Items.Clear();
            MySqlDataAdapter da = new MySqlDataAdapter("select component from component_master", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox4.Items.Add(dr["component"].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from batchcode_id_product_code where batchcode='" + textBox4.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            MySqlDataAdapter da1 = new MySqlDataAdapter("select * from batch_code_master where batchcode='" + textBox4.Text + "'", con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                textBox5.Text = dr1["designer"].ToString();
            }

            i = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
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

        public void emb_calculation()
        {
            try {
                if (comboBox5.Text == "2.75")
                {
                    textBox16.ReadOnly = false;
                    textBox10.ReadOnly = false;
                    textBox13.ReadOnly = false;
                    textBox17.Text = System.Convert.ToString(Math.Round(System.Convert.ToDouble(textBox13.Text) / 44 * System.Convert.ToDouble(textBox16.Text) * System.Convert.ToDouble(textBox10.Text),2));
                    textBox2.Text = System.Convert.ToString(Math.Round(System.Convert.ToDouble(textBox3.Text) / 2.75 * System.Convert.ToDouble(textBox17.Text),2));
                }

                else if (comboBox5.Text == "1760 SQ INCH")
                {
                    textBox10.ReadOnly = false;
                    textBox13.ReadOnly = false;
                    textBox14.ReadOnly = false;
                    textBox15.ReadOnly = false;
                    if (textBox15.Text == "")
                    {
                        textBox17.Text = System.Convert.ToString(Math.Round(System.Convert.ToDouble(textBox13.Text) * System.Convert.ToDouble(textBox14.Text) * System.Convert.ToDouble(textBox10.Text),2));
                        textBox2.Text = System.Convert.ToString(Math.Round(System.Convert.ToDouble(textBox3.Text) / 1760 * System.Convert.ToDouble(textBox17.Text),2));
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
                            textBox2.Text = System.Convert.ToString(Math.Round(System.Convert.ToDouble(textBox3.Text) / 1760 * System.Convert.ToDouble(textBox17.Text),2));
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
                        textBox17.Text = System.Convert.ToString(Math.Round((System.Convert.ToDouble(textBox13.Text) / 40) * System.Convert.ToDouble(textBox12.Text),2));
                        textBox2.Text = System.Convert.ToString(Math.Round(System.Convert.ToDouble(textBox3.Text) * System.Convert.ToDouble(textBox17.Text),2));
                    }
                    else if (textBox13.Text == "")
                    {
                        textBox17.Text = System.Convert.ToString(Math.Round(System.Convert.ToDouble(textBox16.Text) * System.Convert.ToDouble(textBox12.Text),2));
                        textBox2.Text = System.Convert.ToString(Math.Round(System.Convert.ToDouble(textBox3.Text) * System.Convert.ToDouble(textBox17.Text),2));
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
                    textBox2.Text = System.Convert.ToString(Math.Round(System.Convert.ToDouble(textBox17.Text) * System.Convert.ToDouble(textBox3.Text),2));
                }

                else if (comboBox5.Text == "SET")
                {
                    textBox11.ReadOnly = false;
                    textBox2.Text = System.Convert.ToString(Math.Round(System.Convert.ToDouble(textBox17.Text) * System.Convert.ToDouble(textBox3.Text),2));
                }
            }
            catch(Exception)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            emb_calculation();
        }

        private void comboBox5_Leave(object sender, EventArgs e)
        {
            emb_calculation();
        }

        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            emb_calculation();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            label10.Text = listBox1.SelectedIndices.Count.ToString();
        }

        string prefix, f_y, order_number, designer, i;

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE emb_tracker SET `date` = '" + maskedTextBox1.Text+ "',`batchcode` = '"+textBox4.Text+ "',`v_emb_code` = '" + textBox6.Text + "',`karigar_name` ='" + comboBox3.Text + "',`design_code` ='" + textBox1.Text + "',`design_description` = '" + richTextBox1.Text + "',`emb_unit` = '" + comboBox5.Text + "',`no_of_p_code` = '" + label10.Text + "',`item` ='" + comboBox4.Text + "',`fabric`='" + textBox7.Text + "',`colour`='" + textBox8.Text + "',`fab_qty_detail`='" + textBox9.Text + "',`meter`='" + textBox16.Text + "',`pieces`='" + textBox10.Text + "',`set`='" + textBox11.Text + "',`line_1`='" + textBox12.Text + "',`inch_1`='" + textBox13.Text + "',`inch_2`='" + textBox14.Text + "',`inch_3`='" + textBox15.Text + "',`item_qty`='" + textBox18.Text + "',`total_job_issue`='" + textBox17.Text + "',`item_pending_qty`='" + textBox18.Text + "',`pending_job_issue`='" + textBox17.Text + "',`rate`='" + textBox3.Text + "',`rate_type`='" + comboBox2.Text + "',`amount`='" + textBox2.Text + "' where `id`='"+textBox19.Text+"'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Updated");
            this.Close();
        }

        int last_unsed, next_number;
        private void button2_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from no_series where department='" + comboBox1.Text+ "' and order_type='OUT-HOUSE' AND table_for='emb_tracker'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                last_unsed = System.Convert.ToInt32(dr["last_number"].ToString());
                f_y = dr["f.y"].ToString();
                prefix = dr["prefix"].ToString();
                next_number = last_unsed + 1;
                i = next_number.ToString().PadLeft(4, '0');
            }

            MySqlDataAdapter da1 = new MySqlDataAdapter("select * from designer_master where desinger_name='" + textBox5.Text + "' and department='" + comboBox1.Text + "'", con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach(DataRow dr1 in dt1.Rows)
            {
                designer = dr1["designer_code"].ToString();
            }

            order_number = prefix + "/" + designer + "/" + f_y + "/" + i;

            int check = 0;
            MySqlDataAdapter da2 = new MySqlDataAdapter("select * from emb_tracker where order_number='" + order_number + "' and order_type='OUT-HOUSE'", con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            check = System.Convert.ToInt32(dt2.Rows.Count.ToString());
            if(check==0)
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into emb_tracker (`order_number`,`order_type`,`date`,`department`,`batchcode`,`v_emb_code`,`karigar_name`,`designer`,`design_code`,`design_description`,`emb_unit`,`no_of_p_code`,`item`,`fabric`,`colour`,`fab_qty_detail`,`meter`,`pieces`,`set`,`line_1`,`inch_1`,`inch_2`,`inch_3`,`item_qty`,`total_job_issue`,`item_pending_qty`,`pending_job_issue`,`status`,`rate`,`rate_type`,`amount`) Values ('" + order_number + "','OUT-HOUSE','" + maskedTextBox1.Text + "','" + comboBox1.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + comboBox3.Text + "','" + textBox5.Text + "','" + textBox1.Text + "','" + richTextBox1.Text + "','" + comboBox5.Text + "','" + label10.Text + "','" + comboBox4.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox16.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + textBox15.Text + "','" + textBox18.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + textBox17.Text + "','OPEN','" + textBox3.Text + "','" + comboBox2.Text + "','" + textBox2.Text + "')";
                cmd.ExecuteNonQuery();

                MySqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update no_series set last_number='" + i+"' where department='"+comboBox1.Text+ "' and order_type='OUT-HOUSE' AND table_for='emb_tracker'";
                cmd1.ExecuteNonQuery();

                for (int j = 0; j < listBox1.SelectedItems.Count; j++)
                {
                    MySqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "insert into emb_p_code (p_code,order_id) Values ('" + listBox1.SelectedItems[j].ToString() + "','" + order_number + "')";
                    cmd2.ExecuteNonQuery();
                }

                MessageBox.Show("Order Generated! Your Order Number is " + order_number, "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                emb_outhouse_list emb = new emb_outhouse_list();
                emb.dataGridView1.Rows.Clear();
                emb.fill_datagrid();
                this.Close();
            }
            else
            {
                MessageBox.Show("Order number Already taken");
            } 
        }
    }
}
