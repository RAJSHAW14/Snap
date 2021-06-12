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
    public partial class add_fabric_comsumption : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public add_fabric_comsumption()
        {
            InitializeComponent();
        }

        private void add_fabric_comsumption_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from style_consumption_fabric where style_code='"+textBox4.Text+ "' and style_colour='"+textBox5.Text+"'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            i = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if(i==0)
            {
                MessageBox.Show("Cosumption of the style not done", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                button3.Enabled = true;
                dataGridView1.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = textBox2.Text;
                    dataGridView1.Rows[n].Cells[1].Value = batch_department;
                    dataGridView1.Rows[n].Cells[2].Value = textBox4.Text;
                    dataGridView1.Rows[n].Cells[3].Value = textBox5.Text;
                    dataGridView1.Rows[n].Cells[4].Value = dr["component"].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = dr["fabric_code"].ToString();
                    dataGridView1.Rows[n].Cells[6].Value = dr["fabric_name"].ToString();
                    dataGridView1.Rows[n].Cells[7].Value = dr["unit"].ToString();
                    dataGridView1.Rows[n].Cells[8].Value = dr["qty"].ToString();
                    dataGridView1.Rows[n].Cells[9].Value = textBox6.Text;
                    dataGridView1.Rows[n].Cells[10].Value = System.Convert.ToDouble(dataGridView1.Rows[n].Cells[8].Value) * System.Convert.ToDouble(dataGridView1.Rows[n].Cells[9].Value);
                    dataGridView1.Rows[n].Cells[11].Value = dr["id"].ToString();
                }

                MySqlDataAdapter da1 = new MySqlDataAdapter("select id from product_code_master where batcode_id='"+batch_id+"'", con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dataGridView2.Rows.Clear();
                foreach (DataRow dr1 in dt1.Rows)
                {
                    int r = dataGridView2.Rows.Add();
                    dataGridView2.Rows[r].Cells[0].Value = dr1["id"].ToString();
                }
            }

        }

        string batch_department, batch_id;
        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from batch_code_master where batchcode='"+textBox2.Text+"'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            i = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                MessageBox.Show("Batchcode Not found");
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    textBox4.Text = dr["style_code"].ToString();
                    textBox5.Text = dr["style_colour"].ToString();
                    textBox6.Text = dr["batchsize"].ToString();
                    batch_department = dr["department"].ToString();
                    batch_id = dr["id"].ToString();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to add consumption", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result==DialogResult.Yes)
            {
                MySqlDataAdapter da2 = new MySqlDataAdapter("select * from batch_fabric_consumption where id='" + batch_id + "'", con);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                int check = 0;
                check = System.Convert.ToInt32(dt2.Rows.Count.ToString());
                if(check==0)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        MySqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into batch_fabric_consumption (batch_id,sty_fabric_consumption_id,toal_consumption_qty,pending_qty) Values ('" + System.Convert.ToInt32(batch_id) + "','" + dataGridView1.Rows[i].Cells[11].Value + "','" + dataGridView1.Rows[i].Cells[10].Value + "','" + dataGridView1.Rows[i].Cells[10].Value + "')";
                        cmd.ExecuteNonQuery();
                    }

                    for (int r = 0; r < dataGridView2.Rows.Count; r++)
                    {
                        for (int j = 0; j < dataGridView1.Rows.Count; j++)
                        {
                            MySqlCommand cmd1 = con.CreateCommand();
                            cmd1.CommandType = CommandType.Text;
                            cmd1.CommandText = "insert into product_fabric_consumption (batch_id,product_code_id,style_consumption_id,total_qty,pending_qty) Values ('" + System.Convert.ToInt32(batch_id) + "','" + dataGridView2.Rows[r].Cells[0].Value + "','" + dataGridView1.Rows[j].Cells[11].Value + "','" + dataGridView1.Rows[j].Cells[8].Value + "','" + dataGridView1.Rows[j].Cells[8].Value + "')";
                            cmd1.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Consumption Inserted Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Consumption already added");
                }                
            }
            else
            {

            }
        }
    }
}
