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
    public partial class qc_check : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public qc_check()
        {
            InitializeComponent();
        }

        private void qc_check_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            auto_complete();
            auto_complete1();
        }

        public void auto_complete()
        {
            MySqlCommand cmd = new MySqlCommand("select DISTINCT(item_name) from acc_qc_master", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection autocomplete = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                autocomplete.Add(dr.GetString(0));

            }
            textBox7.AutoCompleteCustomSource = autocomplete;
            dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from acc_qc_master where item_name='" + textBox7.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            i = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                MessageBox.Show("Incorect Item Name");
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int j = dataGridView1.Rows.Add();
                    dataGridView1.Rows[j].Cells[0].Value = dr["check_list"].ToString();
                    dataGridView1.Rows[j].Cells[1].Value = dr["parameter"].ToString();
                    dataGridView1.Rows[j].Cells[2].Value = dr["remarks"].ToString();
                }
            }
            
        }


        int max, next_number;
        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Enter Product Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string final_status = "";
                int i = 0;
                MySqlDataAdapter da = new MySqlDataAdapter("select * from acc_qc_transaction_list where product_code='" + textBox1.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                i = System.Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    MySqlDataAdapter da1 = new MySqlDataAdapter("select MAX(id_number) as id_number from acc_qc_transaction_list", con);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        max = System.Convert.ToInt32(dr1["id_number"].ToString());
                    }
                    next_number = max + 1;
                    for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                    {
                        MySqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into acc_qc_transaction_list (product_code,date,style_code,product,size,type,client_store,check_list,parameter,d_remakrs,id_number,d_status,color,client) Values ('" + textBox1.Text + "','" + maskedTextBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + dataGridView1.Rows[j].Cells[0].Value + "','" + dataGridView1.Rows[j].Cells[1].Value + "','" + dataGridView1.Rows[j].Cells[2].Value + "','" + next_number.ToString() + "','OPEN','"+textBox9.Text+"','"+textBox10.Text+"')";
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Data Inserted Sucessfully");
                    this.Close();
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        final_status = dr["final_status"].ToString();
                    }
                    MySqlDataAdapter da1 = new MySqlDataAdapter("select MAX(id_number) as id_number from acc_qc_transaction_list", con);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        max = System.Convert.ToInt32(dr1["id_number"].ToString());
                    }
                    next_number = max + 1;
                    if (final_status == "REJECTED")
                    {
                        for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                        {
                            MySqlCommand cmd = con.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "insert into acc_qc_transaction_list (product_code,date,style_code,product,size,type,client_store,check_list,parameter,d_remakrs,id_number,d_status,color,client) Values ('" + textBox1.Text + "','" + maskedTextBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + dataGridView1.Rows[j].Cells[0].Value + "','" + dataGridView1.Rows[j].Cells[1].Value + "','" + dataGridView1.Rows[j].Cells[2].Value + "','" + next_number.ToString() + "','OPEN','"+textBox9.Text+"','"+textBox10.Text+"')";
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Data Inserted Sucessfully");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Product Already Inserted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from acc_qc_transaction_list where id_number='" + textBox8.Text + "'";
            cmd.ExecuteNonQuery();
            
            for(int i=0;i<dataGridView1.Rows.Count-1;i++)
            {
                MySqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "insert into acc_qc_transaction_list (product_code,date,style_code,product,size,type,client_store,check_list,parameter,d_remakrs,id_number,d_status,color,client) Values ('" + textBox1.Text + "','" + maskedTextBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + textBox8.Text + "','OPEN','" + textBox9.Text + "','" + textBox10.Text + "')";
                cmd1.ExecuteNonQuery();
            }

            MessageBox.Show("Data Updated Sucessfully");
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from acc_qc_transaction_list where id_number='" + textBox8.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["check_list"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr["parameter"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["d_remakrs"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr["id"].ToString();
                textBox1.Text = dr["product_code"].ToString();
                maskedTextBox1.Text = dr["date"].ToString();
                textBox2.Text = dr["style_code"].ToString();
                textBox3.Text = dr["product"].ToString();
                textBox4.Text = dr["size"].ToString();
                textBox5.Text = dr["type"].ToString();
                textBox6.Text = dr["client_store"].ToString();
                textBox9.Text = dr["color"].ToString();
                textBox10.Text = dr["client"].ToString();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            int i = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from acc_product where product_code='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            i = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if(i==0)
            {
                MessageBox.Show("Incorrect Product Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach(DataRow dr in dt.Rows)
                {
                    textBox2.Text = dr["style_code"].ToString();
                    textBox3.Text = dr["product"].ToString();
                    textBox4.Text = dr["size"].ToString();
                    textBox5.Text = dr["type"].ToString();
                    textBox6.Text = dr["store"].ToString();
                    textBox9.Text = dr["color"].ToString();
                    textBox10.Text = dr["client"].ToString();
                }
            }
            
        }

        public void auto_complete1()
        {
            MySqlCommand cmd = new MySqlCommand("select product_code from acc_product", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection autocomplete = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                autocomplete.Add(dr.GetString(0));

            }
            textBox1.AutoCompleteCustomSource = autocomplete;
            dr.Close();
        }
    }
}
