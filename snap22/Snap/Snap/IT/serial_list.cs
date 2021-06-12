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

namespace Snap.IT
{
    public partial class serial_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public serial_list()
        {
            InitializeComponent();
        }

        private void serial_list_Load(object sender, EventArgs e)
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
            MySqlDataAdapter da = new MySqlDataAdapter("select * from it_item", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells["serial_numer"].Value = dr["serial_number"].ToString();
                dataGridView1.Rows[i].Cells["Catagory"].Value = dr["catagory"].ToString();
                dataGridView1.Rows[i].Cells["Company"].Value = dr["brand"].ToString();
                dataGridView1.Rows[i].Cells["purchase_date"].Value = System.Convert.ToDateTime(dr["purchase_date"].ToString());
                dataGridView1.Rows[i].Cells["warrenty"].Value = System.Convert.ToDateTime(dr["warrenty_valid"].ToString());
                dataGridView1.Rows[i].Cells["bill_number"].Value = dr["bill_number"].ToString();
                dataGridView1.Rows[i].Cells["vendor"].Value = dr["vendor"].ToString();
                dataGridView1.Rows[i].Cells["assign_user"].Value = dr["assign_user"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IT.add_stock stock = new add_stock();
            stock.button2.Enabled = false;
            stock.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(id_value==0)
            {
                MessageBox.Show("Please select the cell to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                IT.add_stock stock = new add_stock();
                stock.button1.Enabled = false;
                stock.textBox5.Text = id_value.ToString();
                stock.fill_data();
                stock.comboBox1.Enabled = false;
                id_value = 0;
                stock.Show();
            }
        }

        int id_value=0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id_value = System.Convert.ToInt32(row.Cells["id"].Value.ToString());
            }
        }

        string assign_user1 = "", cat = "";

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            fill_data();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "SERIAL NUMBER")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from it_item where serial_number like '%"+textBox1.Text+"%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["serial_numer"].Value = dr["serial_number"].ToString();
                    dataGridView1.Rows[i].Cells["Catagory"].Value = dr["catagory"].ToString();
                    dataGridView1.Rows[i].Cells["Company"].Value = dr["brand"].ToString();
                    dataGridView1.Rows[i].Cells["purchase_date"].Value = System.Convert.ToDateTime(dr["purchase_date"].ToString());
                    dataGridView1.Rows[i].Cells["warrenty"].Value = System.Convert.ToDateTime(dr["warrenty_valid"].ToString());
                    dataGridView1.Rows[i].Cells["bill_number"].Value = dr["bill_number"].ToString();
                    dataGridView1.Rows[i].Cells["vendor"].Value = dr["vendor"].ToString();
                    dataGridView1.Rows[i].Cells["assign_user"].Value = dr["assign_user"].ToString();
                }
            }
            else if (comboBox1.Text == "CATEGORY")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from it_item where catagory like '%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["serial_numer"].Value = dr["serial_number"].ToString();
                    dataGridView1.Rows[i].Cells["Catagory"].Value = dr["catagory"].ToString();
                    dataGridView1.Rows[i].Cells["Company"].Value = dr["brand"].ToString();
                    dataGridView1.Rows[i].Cells["purchase_date"].Value = System.Convert.ToDateTime(dr["purchase_date"].ToString());
                    dataGridView1.Rows[i].Cells["warrenty"].Value = System.Convert.ToDateTime(dr["warrenty_valid"].ToString());
                    dataGridView1.Rows[i].Cells["bill_number"].Value = dr["bill_number"].ToString();
                    dataGridView1.Rows[i].Cells["vendor"].Value = dr["vendor"].ToString();
                    dataGridView1.Rows[i].Cells["assign_user"].Value = dr["assign_user"].ToString();
                }
            }
            else if (comboBox1.Text == "COMPANY")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from it_item where brand like '%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["serial_numer"].Value = dr["serial_number"].ToString();
                    dataGridView1.Rows[i].Cells["Catagory"].Value = dr["catagory"].ToString();
                    dataGridView1.Rows[i].Cells["Company"].Value = dr["brand"].ToString();
                    dataGridView1.Rows[i].Cells["purchase_date"].Value = System.Convert.ToDateTime(dr["purchase_date"].ToString());
                    dataGridView1.Rows[i].Cells["warrenty"].Value = System.Convert.ToDateTime(dr["warrenty_valid"].ToString());
                    dataGridView1.Rows[i].Cells["bill_number"].Value = dr["bill_number"].ToString();
                    dataGridView1.Rows[i].Cells["vendor"].Value = dr["vendor"].ToString();
                    dataGridView1.Rows[i].Cells["assign_user"].Value = dr["assign_user"].ToString();
                }
            }
            else if (comboBox1.Text == "VENDOR")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from it_item where vendor like '%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["serial_numer"].Value = dr["serial_number"].ToString();
                    dataGridView1.Rows[i].Cells["Catagory"].Value = dr["catagory"].ToString();
                    dataGridView1.Rows[i].Cells["Company"].Value = dr["brand"].ToString();
                    dataGridView1.Rows[i].Cells["purchase_date"].Value = System.Convert.ToDateTime(dr["purchase_date"].ToString());
                    dataGridView1.Rows[i].Cells["warrenty"].Value = System.Convert.ToDateTime(dr["warrenty_valid"].ToString());
                    dataGridView1.Rows[i].Cells["bill_number"].Value = dr["bill_number"].ToString();
                    dataGridView1.Rows[i].Cells["vendor"].Value = dr["vendor"].ToString();
                    dataGridView1.Rows[i].Cells["assign_user"].Value = dr["assign_user"].ToString();
                }
            }
            else if (comboBox1.Text == "ASSIGN USER")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from it_item where assign_user like '%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["serial_numer"].Value = dr["serial_number"].ToString();
                    dataGridView1.Rows[i].Cells["Catagory"].Value = dr["catagory"].ToString();
                    dataGridView1.Rows[i].Cells["Company"].Value = dr["brand"].ToString();
                    dataGridView1.Rows[i].Cells["purchase_date"].Value = System.Convert.ToDateTime(dr["purchase_date"].ToString());
                    dataGridView1.Rows[i].Cells["warrenty"].Value = System.Convert.ToDateTime(dr["warrenty_valid"].ToString());
                    dataGridView1.Rows[i].Cells["bill_number"].Value = dr["bill_number"].ToString();
                    dataGridView1.Rows[i].Cells["vendor"].Value = dr["vendor"].ToString();
                    dataGridView1.Rows[i].Cells["assign_user"].Value = dr["assign_user"].ToString();
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
                fill_data();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(id_value==0)
            {
                MessageBox.Show("Please select the Item to Issue", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from it_item where id='" + id_value.ToString() + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    assign_user1 = dr["assign_user"].ToString();
                }

                if(assign_user1=="IT")
                {
                    IT.issue_item item = new issue_item();
                    item.textBox2.Text = id_value.ToString();
                    id_value = 0;
                    item.Show();
                }
                else
                {
                    MessageBox.Show("Item Already Issued", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (id_value == 0)
            {
                MessageBox.Show("Please select the Item to Issue", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from it_item where id='" + id_value.ToString() + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    assign_user1 = dr["assign_user"].ToString();
                    cat = dr["catagory"].ToString();
                }

                if (assign_user1 == "IT")
                {
                    MessageBox.Show("Item Already in Stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update it_item set assign_user = 'IT' where id = '" + id_value.ToString() + "'";
                    cmd.ExecuteNonQuery();

                    MySqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "update it_item_catagory set it_stock = it_stock+1, user_stock=user_stock-1 where Catagory = '" + cat.ToString() + "'";
                    cmd1.ExecuteNonQuery();

                    MessageBox.Show("Item Taken Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.Clear();
                    fill_data();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(id_value==0)
            {                
                MessageBox.Show("Please select the cell to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from it_item where id='" + id_value.ToString() + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    assign_user1 = dr["assign_user"].ToString();
                    cat = dr["catagory"].ToString();
                }

                if(assign_user1=="IT")
                {
                    DialogResult result = MessageBox.Show("Are you sure want to delete this item", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(result==DialogResult.Yes)
                    {
                        MySqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "delete from it_item where id ='"+id_value.ToString()+"'";
                        cmd.ExecuteNonQuery();

                        MySqlCommand cmd1 = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "update it_item_catagory set total_stock=total_stock-1, it_stock=it_stock-1 where Catagory='"+cat.ToString()+"'";
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Item Deleted sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.Rows.Clear();
                        fill_data();
                        id_value = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Item Already Issued to user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
