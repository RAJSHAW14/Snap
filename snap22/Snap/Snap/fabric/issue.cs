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
    public partial class issue : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public issue()
        {
            InitializeComponent();
        }

        private void issue_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            auto_complete_fabric_code();
        }

        public void fill_req_data()
        {
            int j = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_requisition where req_number='" + textBox1.Text + "' AND pending_qty>0", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            j = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if (j == 0)
            {
                MessageBox.Show("No data Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["req_number"].Value = dr["req_number"].ToString();
                    dataGridView1.Rows[i].Cells["date"].Value = System.Convert.ToDateTime(dr["date"].ToString());
                    dataGridView1.Rows[i].Cells["batchcode"].Value = dr["batch_code"].ToString();
                    dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                    dataGridView1.Rows[i].Cells["fabric_code"].Value = dr["fabric_code"].ToString();
                    dataGridView1.Rows[i].Cells["qty"].Value = dr["pending_qty"].ToString();
                    dataGridView1.Rows[i].Cells["uom"].Value = dr["uom"].ToString();
                    dataGridView1.Rows[i].Cells["fab_qty_detail"].Value = dr["fab_qty_details"].ToString();
                    dataGridView1.Rows[i].Cells["remarks"].Value = dr["remarks"].ToString();
                }
            }  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if(textBox1.Text=="")
            {
                MessageBox.Show("Please Enter the Req Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                fill_req_data();
            }
        }

        string id_value = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id_value = row.Cells["id"].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(id_value=="")
            {
                MessageBox.Show("Please Select the cell to retrive", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                textBox13.Text = id_value.ToString();
                fill_retrive_data();
                fill_product_code();
                retrive_than_number();
                fill_fabric_rate();
                amount_cal();
            }
        }

        public void fill_retrive_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_requisition where id='" + textBox13.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                textBox2.Text = dr["req_number"].ToString();
                textBox14.Text = dr["date"].ToString();
                textBox3.Text = dr["batch_code"].ToString();
                textBox4.Text = dr["department"].ToString();
                textBox5.Text = dr["desinger"].ToString();
                textBox12.Text = dr["fab_qty_details"].ToString();
                textBox6.Text = dr["fabric_code"].ToString();
                textBox7.Text = dr["fabric_name"].ToString();
                textBox10.Text = dr["uom"].ToString();
                textBox9.Text = dr["pending_qty"].ToString();
                label20.Text = dr["pending_qty"].ToString();    
            }
        }

        public void fill_product_code()
        {
            MySqlDataAdapter da1 = new MySqlDataAdapter("select product_code from fabric_requisition_product where request_id='" + textBox2.Text + "'", con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            listBox1.Items.Clear();
            foreach (DataRow dr in dt1.Rows)
            {
                listBox1.Items.Add(dr["product_code"].ToString());
            }
        }

        

        public void retrive_than_number()
        {
            dataGridView2.Rows.Clear();
            MySqlDataAdapter da1 = new MySqlDataAdapter("select * from fabric_than_details where fabric_code='" + textBox6.Text + "' AND status ='CUTTING' and pending_than_qty>0", con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach(DataRow dr in dt1.Rows)
            {
                int i = dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells["than_id"].Value = dr["id"].ToString();
                dataGridView2.Rows[i].Cells["than_number"].Value = dr["than_number"].ToString();
                dataGridView2.Rows[i].Cells["pending_qty"].Value = dr["pending_than_qty"].ToString();                
            }
            
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            label16.Text = listBox1.SelectedIndices.Count.ToString();
        }

        
       

        public void auto_complete_fabric_code()
        {
            MySqlCommand cmd = new MySqlCommand("select item_code from item where item_type='FABRIC'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection autocomplete = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                autocomplete.Add(dr.GetString(0));

            }
            textBox6.AutoCompleteCustomSource = autocomplete;
            dr.Close();
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            int i = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from item where item_code='" + textBox6.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            i = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if(i==0)
            {
                MessageBox.Show("Item code not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fill_retrive_data();
                fill_product_code();
                retrive_than_number();
            }
            else
            {
                foreach(DataRow dr in dt.Rows)
                {
                    textBox7.Text = dr["item_name"].ToString();
                    textBox8.Text = dr["last_purchase_price"].ToString();
                    textBox10.Text = dr["uom"].ToString();                    
                }
                retrive_than_number();
            }
        }

        public void fill_fabric_rate()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("Select last_purchase_price from item where item_code ='" + textBox6.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                textBox8.Text = dr["last_purchase_price"].ToString();
            }
        }

        public void amount_cal()
        {
            try
            {
                textBox11.Text = System.Convert.ToString(System.Convert.ToDouble(textBox9.Text) * System.Convert.ToDouble(textBox8.Text));
            }
            catch
            {

            }            
        }

        int max_id;
        private void button4_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex ==-1)
            {
                MessageBox.Show("Please select prod to issue", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
            else if(textBox11.Text=="0"|| textBox11.Text=="")
            {
                MessageBox.Show("Amount Not Calculated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(System.Convert.ToDouble(textBox9.Text)>System.Convert.ToDouble(label20.Text))
            {
                MessageBox.Show("Issue Qty is greater than Than Qty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(textBox13.Text=="")
            {
                MessageBox.Show("Retrive the Request to post", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            else if(System.Convert.ToDouble(label20.Text)>0)
            {
                MessageBox.Show("Issue Qty Must Equal to Than Issue Qty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into fabric_issue (req_number,batchcode,department,designer,fab_qty_details,fabric_code,fabric_name,rate,uom,qty,amount,issue_date,req_id) Values ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox12.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox10.Text + "','" + textBox9.Text + "','" + textBox11.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + textBox13.Text + "')";
                cmd.ExecuteNonQuery();

                
                MySqlDataAdapter da = new MySqlDataAdapter("select max(id) as id from fabric_issue", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    max_id=System.Convert.ToInt32(dr["id"].ToString());
                }

                double p_qty, p_amount;
                p_qty = System.Convert.ToDouble(textBox9.Text) / System.Convert.ToDouble(label16.Text);
                p_amount = System.Convert.ToDouble(textBox11.Text) / System.Convert.ToDouble(label16.Text);
                for (int j = 0; j < listBox1.SelectedItems.Count; j++)
                {
                    MySqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "insert into fabric_issue_product (p_code,qty,amount,issue_id) Values ('" + listBox1.SelectedItems[j].ToString() + "','"+p_qty.ToString()+"','"+p_amount.ToString()+"','"+max_id.ToString()+"')";
                    cmd1.ExecuteNonQuery();
                }

                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "update item set inventory=inventory-'" + textBox9.Text + "' where item_code='" + textBox6.Text + "'";
                cmd2.ExecuteNonQuery();

                for (int v = 0; v < dataGridView2.Rows.Count; v++)
                {
                    if (string.Equals(dataGridView2[3, v].Value as string, "") || string.Equals(dataGridView2[3, v].Value as string, "0"))
                    {
                        dataGridView2.Rows.RemoveAt(v);
                        v--;
                    }
                }

                for (int j = 0; j < dataGridView2.Rows.Count; j++)
                {
                    MySqlCommand cmd3 = con.CreateCommand();
                    cmd3.CommandType = CommandType.Text;
                    cmd3.CommandText = "insert into fabric_than_issue (issue_id,than_number,than_issue_qty) Values ('" + max_id.ToString() + "','" + dataGridView2.Rows[j].Cells["than_number"].Value + "','" + dataGridView2.Rows[j].Cells["issue_qty"].Value + "')";
                    cmd3.ExecuteNonQuery();
                }

                for (int j = 0; j < dataGridView2.Rows.Count; j++)
                {
                    MySqlCommand cmd3 = con.CreateCommand();
                    cmd3.CommandType = CommandType.Text;
                    cmd3.CommandText = "update fabric_than_details set pending_than_qty='" + dataGridView2.Rows[j].Cells["issue_qty"].Value + "' where id='" + dataGridView2.Rows[j].Cells["than_id"].Value + "'";
                    cmd3.ExecuteNonQuery();
                }

                MySqlCommand cmd4 = con.CreateCommand();
                cmd4.CommandType = CommandType.Text;
                cmd4.CommandText = "update fabric_requisition set pending_qty=pending_qty-'" + textBox9.Text + "' where id='"+textBox13.Text+"'";
                cmd4.ExecuteNonQuery();

                clear();

                dataGridView1.Rows.Clear();
                fill_req_data();
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            amount_cal();
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            amount_cal();
        }

        public void product_code_selection_check()
        {
            if(listBox1.Items.Count>0)
            {
                if(label16.Text=="0")
                {
                    MessageBox.Show("Please Select the product Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
        }

        public void clear()
        {
            textBox2.Clear();
            textBox14.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox8.Clear();
            textBox5.Clear();
            textBox12.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox7.Clear();
            textBox10.Clear();
            textBox9.Clear();
            textBox11.Clear();
            listBox1.Items.Clear();
            dataGridView2.Rows.Clear();
            label16.Text = "0";
            label20.Text = "0";
            textBox3.Clear();
        }

        public void pending_than_qty_cal()
        {
            try
            {
                double sum_of_amt = 0, total_amount;
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    sum_of_amt += System.Convert.ToDouble(dataGridView2.Rows[i].Cells["issue_qty"].Value);
                }
                total_amount = Math.Round(sum_of_amt, 2);
                label20.Text = System.Convert.ToString(System.Convert.ToDouble(textBox9.Text) - total_amount);
            }
            catch
            {

            }
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if(System.Convert.ToDouble(row.Cells[dataGridView2.Columns[3].Index].Value)>System.Convert.ToDouble(row.Cells[dataGridView2.Columns[2].Index].Value))
                    {
                        MessageBox.Show("Issue Qty will not greater than Than Qty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        (row.Cells[dataGridView2.Columns[3].Index].Value) = "";
                    }
                }
            }
            catch(Exception)
            {

            }
            pending_than_qty_cal();
        }

               
    }
}
