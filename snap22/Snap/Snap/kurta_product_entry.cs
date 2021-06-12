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
using System.Globalization;

namespace Snap
{
    public partial class kurta_product_entry : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public kurta_product_entry()
        {
            InitializeComponent();
        }
        
        private void kurta_product_entry_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            auto_complete_style();
            auto_complete_color();
            fill_data();
        }

        public void auto_complete_style()
        {
            MySqlCommand cmd = new MySqlCommand("select style_code from style_product_lead_time", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection autocomplete = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                autocomplete.Add(dr.GetString(0));
            }
            textBox1.AutoCompleteCustomSource = autocomplete;
            dr.Close();
        }

        public void auto_complete_color()
        {
            MySqlCommand cmd = new MySqlCommand("select style_color from style_product_lead_time where style_code='"+textBox1.Text+"'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection autocomplete = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                autocomplete.Add(dr.GetString(0));
            }
            textBox2.AutoCompleteCustomSource = autocomplete;
            dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from style_product_lead_time where style_code='" + textBox1.Text + "' and style_color='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            i = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if(i==0)
            {
                MessageBox.Show("Style and Color Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach(DataRow dr in dt.Rows)
                {
                    richTextBox1.Text = dr["description"].ToString();
                    textBox4.Text = dr["fabric"].ToString();
                    textBox5.Text = dr["dye"].ToString();
                    textBox6.Text = dr["print"].ToString();
                    textBox7.Text = dr["over_dye"].ToString();
                    textBox8.Text = dr["cmc"].ToString();
                    textBox9.Text = dr["highlight"].ToString();
                    textBox10.Text = dr["stitichin"].ToString();
                }
            }
        }

        public void calculate_date()
        {
            if (maskedTextBox1.Text == null)
            {
                MessageBox.Show("Enter Starting Date");
            }
            else
            {
                //fabric
                int fabric_time = System.Convert.ToInt32(textBox4.Text);
                DateTime fabric_date = System.Convert.ToDateTime(this.maskedTextBox1.Text.Trim(), new CultureInfo("en-GB"));
                textBox3.Text = fabric_date.AddDays(+fabric_time).ToString("dd-MM-yyyy");

                //dye
                int dye_time = System.Convert.ToInt32(textBox5.Text);
                DateTime dye_date = System.Convert.ToDateTime(this.textBox3.Text.Trim(), new CultureInfo("en-GB"));
                textBox12.Text = dye_date.AddDays(+dye_time).ToString("dd-MM-yyyy");

                //print
                int print_time = System.Convert.ToInt32(textBox6.Text);
                DateTime print_date = System.Convert.ToDateTime(this.textBox12.Text.Trim(), new CultureInfo("en-GB"));
                textBox14.Text = print_date.AddDays(+print_time).ToString("dd-MM-yyyy");

                //over dye
                int over_dye_time = System.Convert.ToInt32(textBox7.Text);
                DateTime over_dye_date = System.Convert.ToDateTime(this.textBox14.Text.Trim(), new CultureInfo("en-GB"));
                textBox16.Text = over_dye_date.AddDays(+over_dye_time).ToString("dd-MM-yyyy");

                //cmc_machine
                int cmc_machine_time = System.Convert.ToInt32(textBox8.Text);
                DateTime cmc_machin_date = System.Convert.ToDateTime(this.textBox16.Text.Trim(), new CultureInfo("en-GB"));
                textBox15.Text = cmc_machin_date.AddDays(+cmc_machine_time).ToString("dd-MM-yyyy");

                //highlight
                int highlight_time = System.Convert.ToInt32(textBox9.Text);
                DateTime highlight_date = System.Convert.ToDateTime(this.textBox15.Text.Trim(), new CultureInfo("en-GB"));
                textBox13.Text = cmc_machin_date.AddDays(+highlight_time).ToString("dd-MM-yyyy");

                //stitching
                int stitching_time = System.Convert.ToInt32(textBox10.Text);
                DateTime stitching_date = System.Convert.ToDateTime(this.textBox13.Text.Trim(), new CultureInfo("en-GB"));
                textBox11.Text = stitching_date.AddDays(+stitching_time).ToString("dd-MM-yyyy");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            calculate_date();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox17.Text=="")
            {
                MessageBox.Show("Enter Product code");
            }
            else
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into product_code_routing_date (product_code,stating_date,desinger,fabric_req,dye_req,print_req,over_dye_req,cmc_req,highlight_req,stitiching_req,color,style_code,final_status) Values ('" + textBox17.Text + "','" + maskedTextBox1.Text + "','" + textBox18.Text + "','" + textBox3.Text + "','" + textBox12.Text + "','" + textBox14.Text + "','" + textBox16.Text + "','" + textBox15.Text + "','" + textBox13.Text + "','" + textBox11.Text + "','" + textBox2.Text + "','" + textBox1.Text + "','OPEN')";
                cmd.ExecuteNonQuery();

                MessageBox.Show("Product inserted", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
                dataGridView1.Rows.Clear();
                fill_data();
            }
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from product_code_routing_date order by id DESC", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr["product_code"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["desinger"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr["color"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dr["stating_date"].ToString();
            }
        }

        int id_value = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id_value = System.Convert.ToInt32(row.Cells["id"].Value.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(id_value==0)
            {
                MessageBox.Show("Select Product First");
            }
            else
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from product_code_routing_date where id='" + id_value + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    textBox1.Text = dr["style_code"].ToString();
                    textBox2.Text = dr["color"].ToString();
                    textBox17.Text = dr["product_code"].ToString();
                    maskedTextBox1.Text = dr["stating_date"].ToString();
                    textBox18.Text = dr["desinger"].ToString();
                    textBox3.Text = dr["fabric_req"].ToString();
                    textBox12.Text = dr["dye_req"].ToString();
                    textBox14.Text = dr["print_req"].ToString();
                    textBox16.Text = dr["over_dye_req"].ToString();
                    textBox15.Text = dr["cmc_req"].ToString();
                    textBox13.Text = dr["highlight_req"].ToString();
                    textBox11.Text = dr["stitiching_req"].ToString();
                }

                MySqlDataAdapter da1 = new MySqlDataAdapter("select * from style_product_lead_time where style_code='" + textBox1.Text + "' and style_color='" + textBox2.Text + "'", con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                foreach (DataRow dr1 in dt1.Rows)
                {
                    richTextBox1.Text = dr1["description"].ToString();
                    textBox4.Text = dr1["fabric"].ToString();
                    textBox5.Text = dr1["dye"].ToString();
                    textBox6.Text = dr1["print"].ToString();
                    textBox7.Text = dr1["over_dye"].ToString();
                    textBox8.Text = dr1["cmc"].ToString();
                    textBox9.Text = dr1["highlight"].ToString();
                    textBox10.Text = dr1["stitichin"].ToString();
                }                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(id_value==0)
            {
                MessageBox.Show("Retrive Item First");


            }
            else
            {
                calculate_date();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update product_code_routing_date set product_code='" + textBox17.Text + "',desinger='" + textBox18.Text + "',fabric_req='" + textBox3.Text + "',dye_req='" + textBox12.Text + "',print_req='" + textBox14.Text + "',over_dye_req='" + textBox16.Text + "',cmc_req='" + textBox15.Text + "',highlight_req='" + textBox13.Text + "',stitiching_req='" + textBox11.Text + "',color='" + textBox2.Text + "',style_code='" + textBox1.Text + "',stating_date='"+maskedTextBox1.Text+"' where id='"+id_value+"'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated");
                clear();
                dataGridView1.Rows.Clear();
                fill_data();
            }
            
        }

        public void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();
            richTextBox1.Clear();
            maskedTextBox1.Clear();
            id_value = 0;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}