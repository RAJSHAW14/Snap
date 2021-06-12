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
    public partial class item_issue : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public item_issue()
        {
            InitializeComponent();
        }

        private void item_issue_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            auto_complete();
            maskedTextBox1.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        public void view_stock()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select inventory from item where item_code='" + textBox6.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox19.Text = dr["inventory"].ToString();
            }
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from acc_request where req_number='" + textBox1.Text + "' AND pending_qty>0", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr["req_number"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["batchcode"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr["department"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dr["designer"].ToString();
                dataGridView1.Rows[i].Cells[5].Value = dr["item_code"].ToString();
                dataGridView1.Rows[i].Cells[6].Value = dr["item_name"].ToString();
                dataGridView1.Rows[i].Cells[7].Value = dr["pending_qty"].ToString();
                dataGridView1.Rows[i].Cells[8].Value = dr["unit"].ToString();
                dataGridView1.Rows[i].Cells[9].Value = dr["req_date"].ToString();
                dataGridView1.Rows[i].Cells[10].Value = dr["for_vendor"].ToString();
                dataGridView1.Rows[i].Cells[11].Value = dr["p_code"].ToString();
                dataGridView1.Rows[i].Cells[11].Value = dr["item"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            fill_data();
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

        public void auto_complete()
        {
            MySqlCommand cmd = new MySqlCommand("select item_code from item where item_type='ACC'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection autocomplete = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                autocomplete.Add(dr.GetString(0));

            }
            textBox6.AutoCompleteCustomSource = autocomplete;
            dr.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (id_value == 0)
            {
                MessageBox.Show("Select the Row First");
            }
            else
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from acc_request where id='" + id_value + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    textBox2.Text = dr["req_number"].ToString();
                    textBox14.Text = dr["req_date"].ToString();
                    textBox3.Text = dr["batchcode"].ToString();
                    textBox4.Text = dr["department"].ToString();
                    textBox5.Text = dr["designer"].ToString();
                    textBox6.Text = dr["item_code"].ToString();
                    textBox7.Text = dr["item_name"].ToString();
                    textBox11.Text = dr["pending_qty"].ToString();
                    textBox9.Text = dr["unit"].ToString();
                    textBox13.Text = dr["for_vendor"].ToString();
                    textBox10.Text = dr["id"].ToString();
                    richTextBox1.Text = dr["p_code"].ToString();
                    textBox18.Text = dr["item"].ToString();
                }

                int i = 0;
                MySqlDataAdapter da1 = new MySqlDataAdapter("select * from item where item_code='" + textBox6.Text + "'", con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                i = System.Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    MessageBox.Show("Item Code Incorrect");
                }
                else
                {
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        textBox8.Text = dr1["unit_price"].ToString();
                    }
                    view_stock();
                }
                try
                {
                    textBox12.Text = System.Convert.ToString(System.Convert.ToDouble(textBox8.Text) * System.Convert.ToDouble(textBox11.Text));

                }
                catch
                {

                }
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            int i = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from item where item_code='" + textBox6.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            i = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                MessageBox.Show("Item Not Found");
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    textBox7.Text = dr["item_name"].ToString();
                    textBox8.Text = dr["unit_price"].ToString();
                    textBox9.Text = dr["uom"].ToString();
                }
                textBox19.Clear();
                view_stock();
            }
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            try
            {
                textBox12.Text = System.Convert.ToString(System.Convert.ToDouble(textBox8.Text) * System.Convert.ToDouble(textBox11.Text));
            }
            catch
            {

            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            try
            {
                textBox12.Text = System.Convert.ToString(System.Convert.ToDouble(textBox8.Text) * System.Convert.ToDouble(textBox11.Text));
            }
            catch
            {

            }
        }

        public void clear()
        {
            textBox2.Clear();
            textBox14.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox10.Clear();
            textBox19.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                MessageBox.Show("Enter Item Code");
            }
            else if (textBox11.Text == "")
            {
                MessageBox.Show("Enter Qty");
            }
            else
            {
                try
                {
                    textBox12.Text = System.Convert.ToString(System.Convert.ToDouble(textBox8.Text) * System.Convert.ToDouble(textBox11.Text));
                }
                catch
                {

                }
                try
                {
                    double final_stock = 0;
                    final_stock = System.Convert.ToDouble(textBox19.Text) - System.Convert.ToDouble(textBox11.Text);
                    if (final_stock < 0)
                    {
                        DialogResult result = MessageBox.Show("Stock Not Available. Do You Want to Issue", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            MySqlCommand cmd = con.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "insert into acc_item_issue (req_number,batchcode,department,designer,item_code,name,qty,rate,amount,unit,for_vendor,issue_date,p_code,item) Values ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox11.Text + "','" + textBox8.Text + "','" + textBox12.Text + "','" + textBox9.Text + "','" + textBox13.Text + "','" + maskedTextBox1.Text + "','" + richTextBox1.Text + "','" + textBox18.Text + "')";
                            cmd.ExecuteNonQuery();

                            MySqlCommand cmd2 = con.CreateCommand();
                            cmd2.CommandType = CommandType.Text;
                            cmd2.CommandText = "update item set inventory=inventory-'" + textBox11.Text + "' where item_code='" + textBox6.Text + "'";
                            cmd2.ExecuteNonQuery();

                            MySqlCommand cmd3 = con.CreateCommand();
                            cmd3.CommandType = CommandType.Text;
                            cmd3.CommandText = "update acc_request set pending_qty=pending_qty-'" + textBox11.Text + "' where id='" + textBox10.Text + "'";
                            cmd3.ExecuteNonQuery();

                            dataGridView1.Rows.Clear();
                            clear();
                            fill_data();
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        MySqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into acc_item_issue (req_number,batchcode,department,designer,item_code,name,qty,rate,amount,unit,for_vendor,issue_date,p_code,item) Values ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox11.Text + "','" + textBox8.Text + "','" + textBox12.Text + "','" + textBox9.Text + "','" + textBox13.Text + "','" + maskedTextBox1.Text + "','" + richTextBox1.Text + "','" + textBox18.Text + "')";
                        cmd.ExecuteNonQuery();

                        MySqlCommand cmd2 = con.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "update item set inventory=inventory-'" + textBox11.Text + "' where item_code='" + textBox6.Text + "'";
                        cmd2.ExecuteNonQuery();

                        MySqlCommand cmd3 = con.CreateCommand();
                        cmd3.CommandType = CommandType.Text;
                        cmd3.CommandText = "update acc_request set pending_qty=pending_qty-'" + textBox11.Text + "' where id='" + textBox10.Text + "'";
                        cmd3.ExecuteNonQuery();

                        dataGridView1.Rows.Clear();
                        clear();
                        fill_data();
                    }
                }
                catch
                {

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                MessageBox.Show("Enter Item Code");
            }
            else if (textBox11.Text == "")
            {
                MessageBox.Show("Enter Qty");
            }
            else
            {
                try
                {
                    textBox12.Text = System.Convert.ToString(System.Convert.ToDouble(textBox8.Text) * System.Convert.ToDouble(textBox11.Text));
                }
                catch
                {

                }
                try
                {
                    double final_stock = 0;
                    final_stock = System.Convert.ToDouble(textBox19.Text) - System.Convert.ToDouble(textBox11.Text);
                    if (final_stock < 0)
                    {
                        DialogResult result = MessageBox.Show("Stock Not Available. Do You Want to Issue", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            MySqlCommand cmd2 = con.CreateCommand();
                            cmd2.CommandType = CommandType.Text;
                            cmd2.CommandText = "update item set inventory=inventory+'" + textBox16.Text + "' where item_code='" + textBox17.Text + "'";
                            cmd2.ExecuteNonQuery();

                            MySqlCommand cmd = con.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "update acc_item_issue set req_number='" + textBox2.Text + "',batchcode='" + textBox3.Text + "',department='" + textBox4.Text + "',designer='" + textBox5.Text + "',item_code='" + textBox6.Text + "',name='" + textBox7.Text + "',qty='" + textBox11.Text + "',rate='" + textBox8.Text + "',amount='" + textBox12.Text + "',unit='" + textBox9.Text + "',for_vendor='" + textBox13.Text + "',issue_date='" + maskedTextBox1.Text + "',p_code='" + richTextBox1.Text + "',item='" + textBox18.Text + "' where id='" + textBox15.Text + "'";
                            cmd.ExecuteNonQuery();

                            MySqlCommand cmd3 = con.CreateCommand();
                            cmd3.CommandType = CommandType.Text;
                            cmd3.CommandText = "update item set inventory=inventory-'" + textBox11.Text + "' where item_code='" + textBox6.Text + "'";
                            cmd3.ExecuteNonQuery();

                            MessageBox.Show("Data Updated");
                            this.Close();
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        MySqlCommand cmd2 = con.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "update item set inventory=inventory+'" + textBox16.Text + "' where item_code='" + textBox17.Text + "'";
                        cmd2.ExecuteNonQuery();

                        MySqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "update acc_item_issue set req_number='" + textBox2.Text + "',batchcode='" + textBox3.Text + "',department='" + textBox4.Text + "',designer='" + textBox5.Text + "',item_code='" + textBox6.Text + "',name='" + textBox7.Text + "',qty='" + textBox11.Text + "',rate='" + textBox8.Text + "',amount='" + textBox12.Text + "',unit='" + textBox9.Text + "',for_vendor='" + textBox13.Text + "',issue_date='" + maskedTextBox1.Text + "',p_code='" + richTextBox1.Text + "',item='" + textBox18.Text + "' where id='" + textBox15.Text + "'";
                        cmd.ExecuteNonQuery();

                        MySqlCommand cmd3 = con.CreateCommand();
                        cmd3.CommandType = CommandType.Text;
                        cmd3.CommandText = "update item set inventory=inventory-'" + textBox11.Text + "' where item_code='" + textBox6.Text + "'";
                        cmd3.ExecuteNonQuery();

                        MessageBox.Show("Data Updated");
                        this.Close();
                    }
                }
                catch
                {
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do You want to delete this ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from acc_item_issue where id='" + textBox15.Text + "'";
                cmd.ExecuteNonQuery();

                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "update item set inventory=inventory+'" + textBox16.Text + "' where item_code='" + textBox17.Text + "'";
                cmd3.ExecuteNonQuery();

                MessageBox.Show("Deleted Sucessfully");

                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {
                MessageBox.Show("Retrive the Row First");
            }
            else
            {
                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "update acc_request set pending_qty=pending_qty-'" + textBox11.Text + "' where id='" + textBox10.Text + "'";
                cmd3.ExecuteNonQuery();

                dataGridView1.Rows.Clear();
                clear();
                fill_data();
            }
        }
    }
}
