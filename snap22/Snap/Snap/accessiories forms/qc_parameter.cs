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

namespace Snap.accessiories_forms
{
    public partial class qc_parameter : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public qc_parameter()
        {
            InitializeComponent();
        }

        private void qc_parameter_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 0;
            x = System.Convert.ToInt32(dataGridView1.Rows.Count.ToString());
            if(textBox1.Text=="")
            {
                MessageBox.Show("Enter Item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(x<1)
            {
                MessageBox.Show("Enter the parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int i = 0;
                MySqlDataAdapter da = new MySqlDataAdapter("select * from acc_qc_master where item_name='" + textBox1.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                i = System.Convert.ToInt32(dt.Rows.Count.ToString());
                if(i==0)
                {
                    for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                    {
                        MySqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into acc_qc_master (item_name,check_list,parameter,remarks) values ('" + textBox1.Text + "','" + dataGridView1.Rows[j].Cells[0].Value + "','" + dataGridView1.Rows[j].Cells[1].Value + "','" + dataGridView1.Rows[j].Cells[2].Value + "')";
                        cmd.ExecuteNonQuery();                        
                    }
                    MessageBox.Show("Data inserted sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                    
                }
                else
                {
                    MessageBox.Show("Item Alreary Inserted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from acc_qc_master where item_name='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["check_list"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr["parameter"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["remarks"].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from acc_qc_master where item_name='"+textBox1.Text+"'";
            cmd.ExecuteNonQuery();

            for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
            {
                MySqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "insert into acc_qc_master (item_name,check_list,parameter,remarks) values ('" + textBox1.Text + "','" + dataGridView1.Rows[j].Cells[0].Value + "','" + dataGridView1.Rows[j].Cells[1].Value + "','" + dataGridView1.Rows[j].Cells[2].Value + "')";
                cmd1.ExecuteNonQuery();                
            }
            MessageBox.Show("Data Updated sucessfully");
            this.Close();
        }

    }
}
