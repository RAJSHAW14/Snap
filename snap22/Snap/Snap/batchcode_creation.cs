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
    public partial class batchcode_creation : Form
    {

        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public batchcode_creation()
        {
            InitializeComponent();
        }

        private void batchcode_creation_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            maskedTextBox1.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox4.Text=="")
            {
                MessageBox.Show("Enter Product code to Generate");
            }
            else if(textBox1.Text=="")
            {
                MessageBox.Show("Enter Batchcode");
            }
            else if(textBox2.Text=="")
            {
                MessageBox.Show("Enter Batchsize");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Enter Style Code");
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Enter Style Colour");
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Enter Department");
            }
            else
            {
                int starting_number;
                int end_number;
                dataGridView1.Rows.Clear();
                starting_number = System.Convert.ToInt32(textBox7.Text);
                end_number = starting_number + System.Convert.ToInt32(textBox2.Text);
                for(int i =starting_number;i<end_number;i++ )
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                    dataGridView1.Rows[n].Cells[1].Value = textBox2.Text;
                    dataGridView1.Rows[n].Cells[2].Value = maskedTextBox1.Text;
                    dataGridView1.Rows[n].Cells[3].Value = textBox5.Text;
                    dataGridView1.Rows[n].Cells[4].Value = textBox6.Text;
                    dataGridView1.Rows[n].Cells[5].Value = comboBox1.Text;
                    dataGridView1.Rows[n].Cells[6].Value = textBox4.Text + i.ToString().PadLeft(4, '0');

                }

            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        string batch_id, check;
        private void button2_Click(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked == true)
            {
                check = "YES";
            }
            else
            {
                check = "NO";
            }
            DialogResult result = MessageBox.Show("Do You want to add the Batch and Product Code", "Confirm", MessageBoxButtons.YesNo);
            if(result==DialogResult.Yes)
            {
                int i = 0;
                MySqlDataAdapter da1 = new MySqlDataAdapter("select * from batch_code_master where batchcode='" + textBox1.Text + "'", con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                i = System.Convert.ToInt32(dt1.Rows.Count.ToString());
                if(i==0)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into batch_code_master (batchcode,batchsize,department,generation_date,style_code,style_colour,consumtion_require) Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + maskedTextBox1.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','"+check+"')";
                    cmd.ExecuteNonQuery();
                    //string batch_id;
                    MySqlDataAdapter da = new MySqlDataAdapter("select id from batch_code_master", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        batch_id = dr["id"].ToString();
                    }
                    for (int j = 0; j < dataGridView1.Rows.Count; j++)
                    {
                        MySqlCommand cmd1 = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into product_code_master (batcode_id,product_code) Values ('" + batch_id + "','" + dataGridView1.Rows[j].Cells[6].Value + "')";
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Data Inserted Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Batchode Already Present in Database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
