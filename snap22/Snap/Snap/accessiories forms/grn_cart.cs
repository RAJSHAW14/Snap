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
    public partial class grn_cart : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public grn_cart()
        {
            InitializeComponent();
        }

        private void grn_cart_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        public void data_fll()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from acc_grn where transaction_type='GRN' AND number='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                int j = dataGridView2.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["item_code"].ToString();                
                dataGridView1.Rows[i].Cells[1].Value = dr["item_name"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["item_catagory"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr["uom"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dr["rate"].ToString();
                dataGridView1.Rows[i].Cells[5].Value = dr["qty"].ToString();
                dataGridView1.Rows[i].Cells[6].Value = dr["ex_tax_mt"].ToString();
                dataGridView1.Rows[i].Cells[7].Value = dr["gst"].ToString();
                dataGridView1.Rows[i].Cells[8].Value = dr["hsn"].ToString();
                dataGridView1.Rows[i].Cells[9].Value = dr["inc_tax_amt"].ToString();
                dataGridView1.Rows[i].Cells[11].Value = dr["gst_amt"].ToString();
                textBox1.Text = dr["vendor"].ToString();
                textBox2.Text = dr["number"].ToString();
                maskedTextBox1.Text = dr["date"].ToString();
                textBox8.Text = dr["reff_po_number"].ToString();
                maskedTextBox3.Text = dr["bill_date"].ToString();
                textBox7.Text = dr["bill_number"].ToString();
                dataGridView2.Rows[j].Cells[0].Value = dr["item_code"].ToString();
                dataGridView2.Rows[j].Cells[1].Value = dr["qty"].ToString();
            }
            total_amt();
        }

        
        int max_number;
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Please enter the Vendor Name");
            }
            else
            {
                MySqlDataAdapter da=new MySqlDataAdapter("select MAX(number) as grn_number from acc_transactions where transaction_type='GRN'",con);
                DataTable dt=new DataTable();
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    max_number =System.Convert.ToInt32(dr["grn_number"].ToString());
                }
                textBox2.Text=System.Convert.ToString(max_number+1);

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into acc_transactions (transaction_type,number,item_code,rate,uom,qty,ex_tax_mt,reff_po_number,bill_number,bill_date,vendor,gst_amt,inc_tax_amt,date) Values ('GRN','" + textBox2.Text + "','" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[4].Value + "','" + dataGridView1.Rows[i].Cells[3].Value + "','" + dataGridView1.Rows[i].Cells[5].Value + "','" + dataGridView1.Rows[i].Cells[6].Value + "','" + textBox8.Text + "','" + textBox7.Text + "','" + maskedTextBox3.Text + "','" + textBox1.Text + "','" + dataGridView1.Rows[i].Cells[11].Value + "','" + dataGridView1.Rows[i].Cells[9].Value + "','"+maskedTextBox1.Text+"')";
                    cmd.ExecuteNonQuery();
                }

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    MySqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "update item set inventory=inventory+'" + dataGridView1.Rows[i].Cells[5].Value + "',last_purchase_price='" + dataGridView1.Rows[i].Cells[4].Value + "',unit_price='" + dataGridView1.Rows[i].Cells[4].Value + "' where item_code='" + dataGridView1.Rows[i].Cells[0].Value + "'";
                    cmd2.ExecuteNonQuery();
                }

                MessageBox.Show("GRN Saved Your GRN Number is " + textBox2.Text);
                this.Close();
            }
        }

        public void total_amt()
        {
            double sum_of_total = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {                
                sum_of_total += System.Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value);
            }
            textBox5.Text = System.Convert.ToString(Math.Round(sum_of_total, 2));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Insert Vendor");
            }
            else
            {
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    MySqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "update item set inventory=inventory-'" + dataGridView2.Rows[i].Cells[1].Value + "' where item_code='" + dataGridView2.Rows[i].Cells[0].Value + "'";
                    cmd2.ExecuteNonQuery();
                }

                MySqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "delete from acc_transactions where number='" + textBox2.Text + "' and transaction_type='GRN'";
                cmd1.ExecuteNonQuery();

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into acc_transactions (transaction_type,number,item_code,rate,uom,qty,ex_tax_mt,reff_po_number,bill_number,bill_date,vendor,gst_amt,inc_tax_amt,date) Values ('GRN','" + textBox2.Text + "','" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[4].Value + "','" + dataGridView1.Rows[i].Cells[3].Value + "','" + dataGridView1.Rows[i].Cells[5].Value + "','" + dataGridView1.Rows[i].Cells[6].Value + "','" + textBox8.Text + "','" + textBox7.Text + "','" + maskedTextBox3.Text + "','" + textBox1.Text + "','" + dataGridView1.Rows[i].Cells[11].Value + "','" + dataGridView1.Rows[i].Cells[9].Value + "','" + maskedTextBox1.Text + "')";
                    cmd.ExecuteNonQuery();
                }

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    MySqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "update item set inventory=inventory+'" + dataGridView1.Rows[i].Cells[5].Value + "' where item_code='" + dataGridView1.Rows[i].Cells[0].Value + "'";
                    cmd2.ExecuteNonQuery();
                }

                MessageBox.Show("GRN Updated");
                this.Close();
            }
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                total_amt();
            }
            catch (Exception)
            {

            }            
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                total_amt();
            }
            catch (Exception)
            {

            }
        }

        public AutoCompleteStringCollection AutoComplete_fabric_code()
        {
            MySqlCommand cmd = new MySqlCommand("select item_code from item where item_type='ACC'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection mycoll = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                mycoll.Add(dr["item_code"].ToString());
            }
            dr.Close();
            return mycoll;
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = dataGridView1.CurrentCell.ColumnIndex;
            string g = dataGridView1.Columns[column].HeaderText;
            if (g.Equals("Item Code"))
            {
                TextBox auto_text = e.Control as TextBox;
                if (auto_text != null)
                {
                    auto_text.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    auto_text.AutoCompleteCustomSource = AutoComplete_fabric_code();
                    auto_text.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            else
            {
                TextBox auto_text = e.Control as TextBox;
                if (auto_text != null)
                {
                    auto_text.AutoCompleteMode = AutoCompleteMode.None;
                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    string newvalue;
                    newvalue = (dataGridView1[e.ColumnIndex, e.RowIndex].Value).ToString();
                    MySqlDataAdapter da = new MySqlDataAdapter("select item_name,item_catagory,uom,gst,hsn,unit_price from item where item_code='" + newvalue + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.Rows[e.RowIndex].Cells[1].Value = dt.Rows[0][0].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value = dt.Rows[0][1].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = dt.Rows[0][2].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[7].Value = dt.Rows[0][3].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[8].Value = dt.Rows[0][4].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[4].Value = dt.Rows[0][5].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Choose Correct Item Code");
                dataGridView1.Rows[e.RowIndex].Cells[1].Value = "";
                dataGridView1.Rows[e.RowIndex].Cells[2].Value = "";
                dataGridView1.Rows[e.RowIndex].Cells[3].Value = "";
                dataGridView1.Rows[e.RowIndex].Cells[4].Value = "";
                dataGridView1.Rows[e.RowIndex].Cells[5].Value = "";
                dataGridView1.Rows[e.RowIndex].Cells[6].Value = "";
                dataGridView1.Rows[e.RowIndex].Cells[7].Value = "";
            }

            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[dataGridView1.Columns[6].Index].Value = System.Convert.ToDouble(row.Cells[dataGridView1.Columns[4].Index].Value) * System.Convert.ToDouble(row.Cells[dataGridView1.Columns[5].Index].Value);
                    row.Cells[dataGridView1.Columns[9].Index].Value = System.Convert.ToDouble(row.Cells[dataGridView1.Columns[6].Index].Value) * (System.Convert.ToDouble(row.Cells[dataGridView1.Columns[7].Index].Value) / 100) + System.Convert.ToDouble(row.Cells[dataGridView1.Columns[6].Index].Value);
                    row.Cells[dataGridView1.Columns[11].Index].Value = (System.Convert.ToDouble(row.Cells[dataGridView1.Columns[6].Index].Value) * System.Convert.ToDouble(row.Cells[dataGridView1.Columns[7].Index].Value))/100;
                }
                total_amt();
            }
            catch
            {

            }
        }
    }
}
