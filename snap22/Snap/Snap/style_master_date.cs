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
    public partial class style_master_date : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public style_master_date()
        {
            InitializeComponent();
        }

        private void style_master_date_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_data();
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from style_product_lead_time", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr["style_code"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["style_color"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr["description"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dr["fabric"].ToString();
                dataGridView1.Rows[i].Cells[5].Value = dr["dye"].ToString();
                dataGridView1.Rows[i].Cells[6].Value = dr["print"].ToString();
                dataGridView1.Rows[i].Cells[7].Value = dr["over_dye"].ToString();
                dataGridView1.Rows[i].Cells[8].Value = dr["cmc"].ToString();
                dataGridView1.Rows[i].Cells[9].Value = dr["highlight"].ToString();
                dataGridView1.Rows[i].Cells[10].Value = dr["stitichin"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from style_product_lead_time where style_code='"+textBox1.Text+ "' and style_color='"+textBox2.Text+"'",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            i = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Enter Style Code");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Enter Colour");
                }
                else
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into style_product_lead_time (style_code,style_color,description,fabric,dye,print,over_dye,cmc,highlight,stitichin) Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("DATA INSERTED");
                    dataGridView1.Rows.Clear();
                    fill_data();
                    Clear(); 
                }
            }
            else
            {
                MessageBox.Show("The Style Already Exist");
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

        private void button6_Click(object sender, EventArgs e)
        {
            if(id_value==0)
            {
                MessageBox.Show("Select the Row First");
            }
            else
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from style_product_lead_time where id='" + id_value + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    textBox1.Text = dr["style_code"].ToString();
                    textBox2.Text = dr["style_color"].ToString();
                    textBox3.Text = dr["description"].ToString();
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

        public void Clear()
        {
            textBox1.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(id_value==0)
            {
                MessageBox.Show("Select the Cell first");
            }
            else
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from style_product_lead_time where id='"+id_value+"'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Sucessfully");
                Clear();
                dataGridView1.Rows.Clear();
                fill_data();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Clear();
            dataGridView1.Rows.Clear();
            fill_data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(id_value==0)
            {
                MessageBox.Show("Retrive the Style First");
            }
            else
            {
                int i = 0;
                MySqlDataAdapter da = new MySqlDataAdapter("select * from style_product_lead_time where style_code='" + textBox1.Text + "' and style_color='" + textBox2.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                i = System.Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Enter Style Code");
                    }
                    else if (textBox2.Text == "")
                    {
                        MessageBox.Show("Enter Colour");
                    }
                    else
                    {
                        MySqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "update style_product_lead_time set style_code='"+textBox1.Text+ "',style_color='" + textBox2.Text + "',description='" + textBox3.Text + "',fabric='" + textBox4.Text + "',dye='" + textBox5.Text + "',print='" + textBox6.Text + "',over_dye='" + textBox7.Text + "',cmc='" + textBox8.Text + "',highlight='" + textBox9.Text + "',stitichin='" + textBox10.Text + "' where id='"+id_value+"'";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Style Updated Sucessfully");
                        Clear();
                        dataGridView1.Rows.Clear();
                        fill_data();
                    }
                }
                else
                {
                    MessageBox.Show("The Style Already Exist");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from style_product_lead_time where style_code like '%" + textBox11.Text + "%'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr["style_code"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["style_color"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr["description"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dr["fabric"].ToString();
                dataGridView1.Rows[i].Cells[5].Value = dr["dye"].ToString();
                dataGridView1.Rows[i].Cells[6].Value = dr["print"].ToString();
                dataGridView1.Rows[i].Cells[7].Value = dr["over_dye"].ToString();
                dataGridView1.Rows[i].Cells[8].Value = dr["cmc"].ToString();
                dataGridView1.Rows[i].Cells[9].Value = dr["highlight"].ToString();
                dataGridView1.Rows[i].Cells[10].Value = dr["stitichin"].ToString();
            }
        }
    }
}
