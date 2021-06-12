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
    public partial class cmc_production_time : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public cmc_production_time()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox11.Text = dateTimePicker1.Value.ToShortDateString() + " " + maskedTextBox1.Text;
                textBox12.Text = dateTimePicker2.Value.ToShortDateString() + " " + maskedTextBox2.Text;
                DateTime start_date = System.Convert.ToDateTime(textBox11.Text);
                DateTime end_date = System.Convert.ToDateTime(textBox12.Text);
                TimeSpan diffrence = end_date.Subtract(start_date);
                double hour = diffrence.TotalHours;
                textBox13.Text = hour.ToString();
                try
                {
                    if (textBox14.Text == "")
                    {
                        textBox15.Text = System.Convert.ToString(System.Convert.ToDouble(textBox13.Text) - 0);
                    }
                    else
                    {
                        textBox15.Text = System.Convert.ToString(System.Convert.ToDouble(textBox13.Text) - System.Convert.ToDouble(textBox14.Text));
                    }
                    textBox19.Text = System.Convert.ToString(System.Convert.ToDouble(textBox18.Text) * System.Convert.ToDouble(textBox15.Text));
                }
                catch
                {

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmc_production_time_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            auto_complete_order_number();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_order_entry where order_number='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            i = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if(i==0)
            {
                MessageBox.Show("Order Number not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    textBox2.Text = dr["batchcode"].ToString();
                    textBox3.Text = dr["department"].ToString();
                    textBox4.Text = dr["designer"].ToString();
                    textBox5.Text = dr["fab_qty_details"].ToString();
                    textBox6.Text = dr["component"].ToString();
                    textBox17.Text = dr["fabric"].ToString();
                    textBox16.Text = dr["color"].ToString();
                    textBox7.Text = dr["design_code"].ToString();
                    MySqlDataAdapter da1 = new MySqlDataAdapter("select * from cmc_design where design_code='" + textBox7.Text + "'", con);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    foreach(DataRow dr1 in dt1.Rows)
                    {
                        richTextBox1.Text = dr1["design_description"].ToString();
                        textBox9.Text=dr1["design_type"].ToString();
                        textBox10.Text = dr1["machine_type"].ToString();
                    }
                }
                listBox1.Items.Clear();
                MySqlDataAdapter da2 = new MySqlDataAdapter("select p_code from cmc_order_p_code where order_number='"+textBox1.Text+"'",con);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                foreach(DataRow dr2 in dt2.Rows)
                {
                    listBox1.Items.Add(dr2["p_code"].ToString());
                }
                label19.Text = listBox1.Items.Count.ToString();
            }
            
        }
        public void auto_complete_order_number()
        {
            MySqlCommand cmd = new MySqlCommand("select order_number from cmc_order_entry", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection autocomplete = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                autocomplete.Add(dr.GetString(0));

            }
            textBox1.AutoCompleteCustomSource = autocomplete;
            dr.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox19.Text=="")
            {
                MessageBox.Show("Please calculate time and cost", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(textBox1.Text=="")
            {
                MessageBox.Show("Please Enter Order number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int j = 0;
                MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_production_time_calc where order_number='" + textBox1.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                j = System.Convert.ToInt32(dt.Rows.Count.ToString());
                if(j==0)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into cmc_production_time_calc (order_number,start_date,start_time,end_date,end_time,total_hour,non_working_hour,effective_time,non_working_remarks,per_hr_rate,total_cost) Values ('" + textBox1.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + maskedTextBox1.Text + "','" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "','" + maskedTextBox2.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + textBox15.Text + "','" + textBox8.Text + "','" + textBox18.Text + "','" + textBox19.Text + "')";
                    cmd.ExecuteNonQuery();

                    double per_unit_cost;
                    per_unit_cost = System.Convert.ToDouble(textBox19.Text) / System.Convert.ToDouble(label19.Text);

                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        MySqlCommand cmd1 = con.CreateCommand();
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = "insert into cmc_production_time_calc_p_code (order_number,p_code,cost) Values ('" + textBox1.Text + "','" + listBox1.Items[i].ToString() + "','" + per_unit_cost.ToString() + "')";
                        cmd1.ExecuteNonQuery();
                    }
                    MessageBox.Show("Inserted Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Order Number Already Inserted ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
        }
    }
}
