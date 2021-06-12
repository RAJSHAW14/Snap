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

namespace Snap.fabric
{
    public partial class qc_checking_cart : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public qc_checking_cart()
        {
            InitializeComponent();
        }

        private void qc_checking_cart_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            
        }

        public void fill_gride()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select check_list from fabric_qc_check_list", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["check_list"].Value = dr["check_list"].ToString();
            }
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_than_details_view where id='" + textBox7.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                textBox1.Text = dr["fabric_code"].ToString();
                textBox2.Text = dr["vendor"].ToString();
                textBox3.Text = dr["than_number"].ToString();
                textBox4.Text = dr["than_qty"].ToString();
            }
        }

        int max_id;
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox5.Text=="")
            {
                MessageBox.Show("Please Enter QC Persone Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Are You Sure Want to Approve this Than", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result==DialogResult.Yes)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into fabric_qc_header (than_id,qc_person_name,remarks,for_department,date,status) Values ('"+textBox7.Text+"','"+textBox5.Text+"','"+richTextBox1.Text+"','"+comboBox1.Text+"','"+dateTimePicker1.Value.ToString("yyyy-MM-dd")+"','APPROVE')";
                    cmd.ExecuteNonQuery();

                    
                    MySqlDataAdapter da = new MySqlDataAdapter("select max(id) as id from fabric_qc_header", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach(DataRow dr in dt.Rows)
                    {
                        max_id=System.Convert.ToInt32(dr["id"].ToString());
                    }

                    for(int i=0;i<dataGridView1.Rows.Count;i++)
                    {
                        MySqlCommand cmd1 = con.CreateCommand();
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = "insert into fabric_qc_line (fabric_qc_header_id,check_list,parameter,remarks) Values ('" + max_id.ToString() + "','" + dataGridView1.Rows[i].Cells["check_list"].Value + "','" + dataGridView1.Rows[i].Cells["parameter"].Value + "','" + dataGridView1.Rows[i].Cells["remarks"].Value + "')";
                        cmd1.ExecuteNonQuery();
                    }

                    MySqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "update fabric_than_details set status='APPROVE' WHERE id='"+textBox7.Text+"'";
                    cmd2.ExecuteNonQuery();

                    MessageBox.Show("Than Approve Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                MessageBox.Show("Please Enter QC Persone Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(richTextBox1.Text=="")
            {
                MessageBox.Show("Please Enter Remarks Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Are You Sure Want to Reject this Than", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into fabric_qc_header (than_id,qc_person_name,remarks,for_department,date,status) Values ('" + textBox7.Text + "','" + textBox5.Text + "','" + richTextBox1.Text + "','" + comboBox1.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','REJECT')";
                    cmd.ExecuteNonQuery();


                    MySqlDataAdapter da = new MySqlDataAdapter("select max(id) as id from fabric_qc_header", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        max_id = System.Convert.ToInt32(dr["id"].ToString());
                    }

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        MySqlCommand cmd1 = con.CreateCommand();
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = "insert into fabric_qc_line (fabric_qc_header_id,check_list,parameter,remarks) Values ('" + max_id.ToString() + "','" + dataGridView1.Rows[i].Cells["check_list"].Value + "','" + dataGridView1.Rows[i].Cells["parameter"].Value + "','" + dataGridView1.Rows[i].Cells["remarks"].Value + "')";
                        cmd1.ExecuteNonQuery();
                    }

                    MySqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "update fabric_than_details set status='REJECT' WHERE id='" + textBox7.Text + "'";
                    cmd2.ExecuteNonQuery();

                    MessageBox.Show("Than Rejected Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {

                }
            }
        }
    }
}
