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
    public partial class grn_cart : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public grn_cart()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grn_cart_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            auto_complete_vendor();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_po where vendor='" + textBox1.Text + "' and pending_qty>0", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            i = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if(i==0)
            {
                MessageBox.Show("Data not Available to GRN against this Vendor", "Error", MessageBoxButtons.OK);
            }
            else
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Visible = true;
                button2.Visible = true;
                foreach(DataRow dr in dt.Rows)
                {
                    int j = dataGridView1.Rows.Add();
                    dataGridView1.Rows[j].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[j].Cells["select"].Value = false;
                    dataGridView1.Rows[j].Cells["po_number"].Value = dr["po_number"].ToString();
                    dataGridView1.Rows[j].Cells["item_code"].Value = dr["fabric_code"].ToString();
                    dataGridView1.Rows[j].Cells["actual_qty"].Value = dr["order_qty"].ToString();
                    dataGridView1.Rows[j].Cells["qty"].Value = dr["pending_qty"].ToString();
                    dataGridView1.Rows[j].Cells["rate"].Value = dr["rate"].ToString();
                }
            }
        }

        public void auto_complete_vendor()
        {
            MySqlCommand cmd = new MySqlCommand("select vendor_name from vendor where vendor_type='FABRIC'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection autocomplete = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                autocomplete.Add(dr.GetString(0));

            }
            textBox1.AutoCompleteCustomSource = autocomplete;
            dr.Close();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if((bool)dataGridView1.SelectedRows[0].Cells[1].Value==false)
            {
                dataGridView1.SelectedRows[0].Cells[1].Value = true;
            }
            else
            {
                dataGridView1.SelectedRows[0].Cells[1].Value = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow item in dataGridView1.Rows)
            {
                if((bool)item.Cells[1].Value==true)
                {
                    int n=dataGridView2.Rows.Add();
                    string check;
                    dataGridView2.Rows[n].Cells["po_line_id"].Value=item.Cells["id"].Value.ToString();
                    check = dataGridView2.Rows[n].Cells["po_line_id"].Value.ToString();
                    MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_po where id='" + check.ToString() + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach(DataRow dr in dt.Rows)
                    {
                        dataGridView2.Rows[n].Cells["item_code1"].Value = dr["fabric_code"].ToString();
                        dataGridView2.Rows[n].Cells["Item_name"].Value = dr["fabric_name"].ToString();
                        dataGridView2.Rows[n].Cells["rate1"].Value = dr["rate"].ToString();
                        dataGridView2.Rows[n].Cells["uom"].Value = dr["uom"].ToString();
                        dataGridView2.Rows[n].Cells["Qty1"].Value = dr["pending_qty"].ToString();
                        dataGridView2.Rows[n].Cells["order_qty"].Value = dr["order_qty"].ToString();
                        dataGridView2.Rows[n].Cells["amount"].Value = System.Convert.ToDouble(dataGridView2.Rows[n].Cells["rate1"].Value) * System.Convert.ToDouble(dataGridView2.Rows[n].Cells["Qty1"].Value);
                        dataGridView2.Rows[n].Cells["gst_per"].Value = dr["gst"].ToString();
                        dataGridView2.Rows[n].Cells["hsn"].Value = dr["hsn"].ToString();
                        dataGridView2.Rows[n].Cells["gst_amount"].Value = System.Convert.ToDouble(dataGridView2.Rows[n].Cells["amount"].Value) * System.Convert.ToDouble(dataGridView2.Rows[n].Cells["gst_per"].Value) / 100;
                        dataGridView2.Rows[n].Cells["total"].Value = System.Convert.ToDouble(dataGridView2.Rows[n].Cells["gst_amount"].Value) + System.Convert.ToDouble(dataGridView2.Rows[n].Cells["amount"].Value);
                    }
                }
            }
            total_amount_cal();
            dataGridView1.Visible = false;
            button2.Visible = false;
        }

        double sum_of_amt = 0;
        public void total_amount_cal()
        {
            try
            {
                
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    sum_of_amt += System.Convert.ToDouble(dataGridView2.Rows[i].Cells["total"].Value);
                }
                textBox5.Text = System.Convert.ToString(Math.Round(sum_of_amt, 2));
            }
            catch 
            {

            }
        }


        private void textBox4_Leave(object sender, EventArgs e)
        {
            //freight_amount_cal();
        }

        string prefix, f_y, grn_number;
        int last_number, next_number;
        private void button4_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = System.Convert.ToInt32(dataGridView2.Rows.Count.ToString());
            if(i==0)
            {
                MessageBox.Show("There is nothing to post for GRN", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from no_series where table_for='fabric_grn'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    prefix = dr["prefix"].ToString();
                    f_y = dr["f.y"].ToString();
                    last_number =System.Convert.ToInt32(dr["last_number"].ToString());
                }
                next_number = last_number + 1;
                grn_number = prefix + "/" + System.Convert.ToString(next_number) + "/" + f_y;
                textBox2.Text = grn_number;
                string grn_date, bill_date;
                grn_date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                bill_date = dateTimePicker2.Value.ToString("yyyy-MM-dd");

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into fabric_grn_header (vendor,grn_number,grn_date,bill_number,bill_date,freight,total,edit_status) Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + grn_date.ToString() + "','" + textBox3.Text + "','" + bill_date.ToString() + "','" + textBox4.Text + "','" + textBox5.Text + "','YES')";
                cmd.ExecuteNonQuery();

                for(int j=0;j<dataGridView2.Rows.Count;j++)
                {
                    MySqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "insert into fabric_grn_line (grn_number,item_code,item_name,rate,uom,qty,amount,gst,hsn,gst_amount,total_amount,than_status,po_id,order_qty) Values ('" + textBox2.Text + "','" + dataGridView2.Rows[j].Cells["item_code1"].Value + "','" + dataGridView2.Rows[j].Cells["Item_name"].Value + "','" + dataGridView2.Rows[j].Cells["rate1"].Value + "','" + dataGridView2.Rows[j].Cells["uom"].Value + "','" + dataGridView2.Rows[j].Cells["Qty1"].Value + "','" + dataGridView2.Rows[j].Cells["amount"].Value + "','" + dataGridView2.Rows[j].Cells["gst_per"].Value + "','" + dataGridView2.Rows[j].Cells["hsn"].Value + "','" + dataGridView2.Rows[j].Cells["gst_amount"].Value + "','" + dataGridView2.Rows[j].Cells["total"].Value + "','PENDING','" + dataGridView2.Rows[j].Cells["po_line_id"].Value + "','" + dataGridView2.Rows[j].Cells["order_qty"].Value + "')";
                    cmd1.ExecuteNonQuery();
                }

                for(int j=0;j<dataGridView2.Rows.Count;j++)
                {
                    MySqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "update fabric_po set pending_qty=pending_qty-'" + dataGridView2.Rows[j].Cells["Qty1"].Value + "' where id='" + dataGridView2.Rows[j].Cells["po_line_id"].Value + "'";
                    cmd1.ExecuteNonQuery();
                }

                for (int j = 0; j < dataGridView2.Rows.Count; j++)
                {
                    MySqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "update item set inventory=inventory+'" + dataGridView2.Rows[j].Cells["Qty1"].Value + "',last_purchase_price='"+dataGridView2.Rows[j].Cells["rate1"].Value+"' where item_code='" + dataGridView2.Rows[j].Cells["item_code1"].Value + "'";
                    cmd1.ExecuteNonQuery();
                }

                MySqlCommand cmd4 = con.CreateCommand();
                cmd4.CommandType = CommandType.Text;
                cmd4.CommandText = "update no_series set last_number ='" + next_number.ToString() + "' WHERE table_for='fabric_grn'";
                cmd4.ExecuteNonQuery();

                MessageBox.Show("GRN generated Sucessfully, Your GRN number is " + grn_number.ToString() , "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        public void reverse_transaction()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_grn_line where grn_number='" + textBox2.Text + "'", con);
            DataTable dt=new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i=dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells["po_line_id"].Value = dr["po_id"].ToString();
                dataGridView2.Rows[i].Cells["Item Code1"].Value = dr["item_code"].ToString();
                dataGridView2.Rows[i].Cells["Qty1"].Value = dr["qty"].ToString();
            }

            for(int j=0;j<dataGridView2.Rows.Count;j++)
            {
                MySqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update fabric_po set pending_qty=pending_qty+'" + dataGridView2.Rows[j].Cells["Qty1"].Value + "' where id='" + dataGridView2.Rows[j].Cells["po_line_id"].Value + "'";
                cmd1.ExecuteNonQuery();
            }

            for (int j = 0; j < dataGridView2.Rows.Count; j++)
            {
                MySqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update item set inventory=inventory-'" + dataGridView2.Rows[j].Cells["Qty1"].Value + "' where item_code='" + dataGridView2.Rows[j].Cells["item_code1"].Value + "'";
                cmd1.ExecuteNonQuery();
            }

            for (int j = 0; j < dataGridView2.Rows.Count; j++)
            {
                MySqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update fabric_grn_line set than_status='REVERSE' where grn_number='" + textBox2.Text + "'";
                cmd1.ExecuteNonQuery();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //freight_amount_cal();
            }
            catch
            {

            }
        }

        public void amount_cal()
        {
            try
            {
                foreach(DataGridViewRow row in dataGridView2.Rows)
                {
                    row.Cells[dataGridView2.Columns["amount"].Index].Value = System.Convert.ToDouble(row.Cells[dataGridView2.Columns["rate1"].Index].Value) * System.Convert.ToDouble(row.Cells[dataGridView2.Columns["Qty1"].Index].Value);
                    row.Cells[dataGridView2.Columns["gst_amount"].Index].Value = System.Convert.ToDouble(row.Cells[dataGridView2.Columns["amount"].Index].Value) * System.Convert.ToDouble(row.Cells[dataGridView2.Columns["gst_per"].Index].Value) / 100;
                    row.Cells[dataGridView2.Columns["total"].Index].Value = System.Convert.ToDouble(row.Cells[dataGridView2.Columns["amount"].Index].Value) + System.Convert.ToDouble(row.Cells[dataGridView2.Columns["gst_amount"].Index].Value);
                }
            }
            catch
            {

            }
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            sum_of_amt = 0;
            amount_cal();
            total_amount_cal();
        }
    }
}
